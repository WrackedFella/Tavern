using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNet.OData;
using Microsoft.AspNetCore.Mvc;

namespace Tavern.Ui.Demo
{
	[EnableQuery]
	public class PeopleController : ODataController
	{
		public IActionResult Get()
		{
			return Ok(DemoDataSources.Instance.People.AsQueryable());
		}
	}
}
