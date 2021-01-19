using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using Poc.MobileApp.Shared.Common;

namespace Poc.MobileApp.WebApi.Controllers
{
	public class ApiExceptionFilter : ExceptionFilterAttribute
	{
		public override void OnException(ExceptionContext context)
		{
			if (context.Exception != null)
			{

				var statusCode = context.Exception is BusinessException ?
								 StatusCodes.Status400BadRequest :
								 StatusCodes.Status500InternalServerError;

				var objectResult = new ObjectResult(new
				{
					StatusCode = statusCode,
					Value = context.Exception.Message,
					InnerException = context.Exception?.InnerException?.Message
				});

				context.Result = objectResult;

			}
		}
	}
}
