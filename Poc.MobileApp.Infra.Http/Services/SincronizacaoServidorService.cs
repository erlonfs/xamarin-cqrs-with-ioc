using Newtonsoft.Json;
using Poc.MobileApp.Domain.Services;
using Poc.MobileApp.Shared.Data;
using Polly;
using Polly.Wrap;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;

namespace Poc.MobileApp.Infra.Http.Services
{
	public class SincronizacaoServidorService : ISincronizacaoServidorService
	{
		private PolicyWrap<HttpResponseMessage> _policies;
		private Token _token;

		private readonly TimeSpan[] _retryTimes = new[] { TimeSpan.FromSeconds(1), TimeSpan.FromSeconds(2),
														  TimeSpan.FromSeconds(4), TimeSpan.FromSeconds(8),
														  TimeSpan.FromSeconds(16) };

		private HttpStatusCode[] _statusCodesIgnoredInPolicieHandlerError = new[] { HttpStatusCode.OK,
																					HttpStatusCode.Unauthorized,
																					HttpStatusCode.BadRequest };

		public SincronizacaoServidorService()
		{
			var retryPolicies = Policy.HandleResult<HttpResponseMessage>(message => message.StatusCode == HttpStatusCode.Unauthorized)
						.WaitAndRetry(_retryTimes, (response, timeSpan, retryCount, context) =>
						{
							Autenticar();

							if (retryCount == _retryTimes.Length)
							{
								if (!(_token?.Authenticated ?? false))
								{
									throw new Exception($"Numero de tentativas de retry excedido {retryCount}");
								}
							}

							context["AccessToken"] = _token?.Value ?? string.Empty;

						});

			var othersPolicies = Policy.HandleResult<HttpResponseMessage>(message => !_statusCodesIgnoredInPolicieHandlerError.Contains(message.StatusCode))
							.WaitAndRetry(new TimeSpan[] { TimeSpan.FromSeconds(2) }, (response, timeSpan, retryCount, context) =>
							{
								throw new Exception(response.Exception?.Message);
							});

			_policies = Policy.Wrap(retryPolicies, othersPolicies);
		}

		public void Autenticar()
		{
			//TODO
		}

		public async Task<IEnumerable<TEntity>> Read<TEntity>(DateTime ultimaSincronizacao) where TEntity : Entity
		{
			var response = _policies.ExecuteWithToken(_token, context =>
			{
				var requestMessage = new HttpRequestMessage(HttpMethod.Get, $"mobileapp/");

				using (var client = ApiExtensions.CreateHttpClient(context["AccessToken"].ToString()))
				{
					return client.SendAsync(requestMessage).GetAwaiter().GetResult();
				}
			});

			var json = await response.Content.ReadAsStringAsync();

			var objects = JsonConvert.DeserializeObject<IEnumerable<TEntity>>(json);

			return objects;

		}

		public Task Write(IEnumerable<Entity> entity)
		{
			return Task.CompletedTask;
		}
	}
}
