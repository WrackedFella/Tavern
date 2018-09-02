using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNet.OData;
using Microsoft.AspNetCore.JsonPatch;
using Microsoft.AspNetCore.Mvc;
using Shared;
using Tavern.Domain;

namespace Tavern.Ui.Core
{
	public abstract class TavernControllerBase<TModel> : ODataController
		where TModel : ModelBase
	{
		private readonly TavernDbContext _context;

		protected TavernControllerBase(TavernDbContext context)
		{
			this._context = context;
			// ToDo: Implement the below items.
			// this._logger = logger;
			// this.currentUser = currentUser; // Audit purposes.
		}

		[HttpGet]
		[EnableQuery]
		[ProducesResponseType(200)]
		[ProducesResponseType(404)]
		public virtual ActionResult<IEnumerable<TModel>> Get()
		{
			return Ok(this._context.Set<TModel>());
		}

		[HttpGet("{id}")]
		[EnableQuery]
		[ProducesResponseType(200)]
		[ProducesResponseType(400)]
		[ProducesResponseType(404)]
		public async Task<ActionResult<TModel>> Get(Guid id)
		{
			var model = await this._context.Set<TModel>().FindAsync(id);
			if (model == null)
			{
				return NotFound();
			}

			return Ok(model);
		}

		[HttpPost]
		[ProducesResponseType(201)]
		[ProducesResponseType(400)]
		public async Task<ActionResult<CreatedAtRouteResult>> Post([FromBody] TModel model)
		{
			await this._context.Set<TModel>().AddAsync(model);
			await this._context.SaveChangesAsync();

			return CreatedAtRoute(new { id = model.GetId() }, model);
		}

		[HttpPut("{id}")]
		[ProducesResponseType(202)]
		[ProducesResponseType(404)]
		public async Task<ActionResult<AcceptedAtRouteResult>> Put(Guid id, [FromBody] TModel model)
		{
			var target = await this._context.Set<TModel>().FindAsync(id);
			if (target == null)
			{
				return NotFound();
			}

			var result = Mapper.Map(model, target);
			await this._context.SaveChangesAsync();
			return AcceptedAtRoute(new { id = result.GetId() }, result);
		}

		[HttpPatch("{id}")]
		public async Task<ActionResult<AcceptedAtRouteResult>> Patch(Guid id, [FromBody]JsonPatchDocument<TModel> patch)
		{
			var target = await this._context.Set<TModel>().FindAsync(id);
			if (target == null)
			{
				return NotFound();
			}

			patch.ApplyTo(target);
			await this._context.SaveChangesAsync();
			return AcceptedAtRoute(new { id = target.GetId() }, target);
		}

		[HttpDelete("{id}")]
		[ProducesResponseType(200)]
		[ProducesResponseType(400)]
		public async Task<ActionResult<OkResult>> Delete(Guid id)
		{
			var target = await this._context.Set<TModel>().FindAsync(id);
			this._context.Set<TModel>().Remove(target);
			await this._context.SaveChangesAsync();

			return Ok();
		}

		public object ResourceRenderData()
		{
			return new object();
		}
	}
}
