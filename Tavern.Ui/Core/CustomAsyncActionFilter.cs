using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using Newtonsoft.Json;
using Tavern.Ui.Json.Serialization;

namespace Tavern.Ui.Core
{
	public class CustomAsyncActionFilter : IAsyncActionFilter
	{
        /// <summary>
        /// Validator Extensions - Provides notification to the system that validators are requested upon response for the current model.
        /// </summary>
		private const string _VALIDATORKEY = "validators";

        /// <summary>
        /// On Action Execute on a Controller for a given Request.
        /// 
        /// Further Reading:
        /// ASP.NET Core MVC includes many features like Model Binding, Content Negotiation, and Response Formatting. (https://msdn.microsoft.com/en-us/magazine/mt767699.aspx)
        /// </summary>
        /// <param name="context"></param>
        /// <param name="next"></param>
        /// <returns></returns>
		public async Task OnActionExecutionAsync(ActionExecutingContext context, ActionExecutionDelegate next)
		{
			var request = context.HttpContext.Request;

            if( !context.ModelState.IsValid )
            {
                context.Result = new BadRequestObjectResult(context.ModelState);
            }



            // Test for validator request
            var includeValidators = request.Headers.Keys.Contains(_VALIDATORKEY);
			var executedContext = (await next.Invoke());
			if (includeValidators)
			{

                // Build validator information from model type.
                var baseType = context.Controller.GetType().BaseType;
				var validatorHeader = "";
				if (baseType.IsGenericType)
				{
					var modelType = baseType.GenericTypeArguments[0];

                    var tmpobj = Activator.CreateInstance(modelType);

                    //Notes: Control characters are not allowed in headers. DO NOT PROVIDE FORMATTING.
                    validatorHeader = JsonConvert.SerializeObject(tmpobj, Formatting.None, new MetaValidatorConverter());
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
				response.Headers.Add(_VALIDATORKEY, validatorHeader);
			}

		}
	}
}
