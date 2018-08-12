using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Tavern.Ui.Demo
{
	public class Trip
	{
		[Key] public String ID { get; set; }
		[Required] public String Name { get; set; }
	}
}
