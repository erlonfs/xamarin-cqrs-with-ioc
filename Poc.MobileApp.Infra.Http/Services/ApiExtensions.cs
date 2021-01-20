using Polly;
using Polly.Retry;
using Polly.Wrap;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;

namespace Poc.MobileApp.Infra.Http.Services
{
	public static class ApiExtensions
	{
		public static HttpResponseMessage ExecuteWithToken(this RetryPolicy<HttpResponseMessage> retryPolicy, Token token, Func<Context, HttpResponseMessage> action)
		{
			return retryPolicy.Execute(action, new Dictionary<string, object> { { "AccessToken", token?.Value ?? string.Empty } });
		}

		public static  HttpResponseMessage ExecuteWithToken(this PolicyWrap<HttpResponseMessage> wrap, Token token, Func<Context, HttpResponseMessage> action)
		{
			return wrap.Execute(action, new Dictionary<string, object> { { "AccessToken", token?.Value ?? string.Empty } });
		}

		public static HttpClient CreateHttpClient(string acessToken)
		{
			var urlBase = "http://10.0.0.254/";

			var httpClient = new HttpClient();
			httpClient.BaseAddress = new Uri(urlBase);
			httpClient.DefaultRequestHeaders.Accept.Clear();
			httpClient.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
			httpClient.DefaultRequestHeaders.Add("KeyAuthentication", acessToken);

			return httpClient;
		}


	}
}
