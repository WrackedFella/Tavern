using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc.Filters;

namespace Tavern.Ui.Core
{
	public class CustomResourceFilter : IResourceFilter
	{
		public void OnResourceExecuting(ResourceExecutingContext context)
		{
			throw new NotImplementedException();
		}

		public void OnResourceExecuted(ResourceExecutedContext context)
		{
			throw new NotImplementedException();
		}
	}
	
	public class AsyncCustomResourceFilter : IAsyncResourceFilter
    {
	    public async Task OnResourceExecutionAsync(ResourceExecutingContext context, ResourceExecutionDelegate next)
	    {
		    var request = context.HttpContext.Request;

			var includeValidators = request.Headers.Keys.Contains("validators");
			var executedContext = (await next.Invoke());
		    if (includeValidators)
			{
				var response = executedContext.HttpContext.Response;
				//executedContext.HttpContext.Response.Headers.Add(???);
			}

			throw new NotImplementedException();
	    }
    }
}
