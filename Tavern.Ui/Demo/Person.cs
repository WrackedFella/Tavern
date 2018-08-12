using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Tavern.Ui.Demo
{
	public class Person
	{
		[Key] public String ID { get; set; }
		[Required] public String Name { get; set; }
		public String Description { get; set; }
		public List<Trip> Trips { get; set; }
	}
}
