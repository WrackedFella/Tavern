using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNet.OData;
using Microsoft.AspNetCore.Mvc;
using Taver.OData.Models;

namespace Taver.OData.Controllers
{
	public class BooksController : ODataController
	{
		private BookStoreContext _db;

		public BooksController(BookStoreContext context)
		{
			this._db = context;
			if (!context.Books.Any())
			{
				foreach (var b in DataSource.GetBooks())
				{
					context.Books.Add(b);
					context.Presses.Add(b.Press);
				}

				context.SaveChanges();
			}
		}

		[EnableQuery]
		public IActionResult Get()
		{
			return Ok(this._db.Books);
		}

		[EnableQuery]
		public IActionResult Get(int key)
		{
			return Ok(this._db.Books.FirstOrDefault(c => c.Id == key));
		}
	}
}
