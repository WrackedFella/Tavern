using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc.Filters;

namespace Tavern.Ui.Core
{
	public class CustomAsyncActionFilter : IAsyncActionFilter
	{
		private const string ValidatorKey = "validators";

		public async Task OnActionExecutionAsync(ActionExecutingContext context, ActionExecutionDelegate next)
		{
			var request = context.HttpContext.Request;
			var includeValidators = request.Headers.Keys.Contains(ValidatorKey);
			var executedContext = (await next.Invoke());
			if (includeValidators)
			{
				var baseType = context.Controller.GetType().BaseType;
				var validatorHeader = "";
				if (baseType.IsGenericType)
				{
					var modelType = baseType.GenericTypeArguments[0];
					validatorHeader = modelType.Name;
				}
				else
				{
					// ???
					// Is this an option?
				}
				// ToDo:
				// 1: Use reflection on type T to get the custom attributes on each property
				// 2: Add said attributes to the 'validators' response header
				var response = executedContext.HttpContext.Response;
				executedContext.HttpContext.Response.Headers.Add(ValidatorKey, validatorHeader);
			}
			throw new NotImplementedException();
		}
	}
}
