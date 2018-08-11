using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNet.OData;
using Microsoft.AspNetCore.JsonPatch;
using Microsoft.AspNetCore.Mvc;
using Shared;
using Tavern.Services;

namespace Tavern.Ui.Core
{
	public abstract class TavernControllerBase<TModel> : ODataController
		where TModel : ModelBase
	{
		private readonly IService<TModel> _service;

		protected TavernControllerBase(IService<TModel> service)
		{
			this._service = service;
		}

		[HttpGet]
		[EnableQuery]
		[ProducesResponseType(200)]
		[ProducesResponseType(404)]
		public virtual async Task<ActionResult<IEnumerable<TModel>>> Get()
		{
			return Ok(await this._service.Get());
		}

		[HttpGet("{id}")]
		[EnableQuery]
		[ProducesResponseType(200)]
		[ProducesResponseType(400)]
		[ProducesResponseType(404)]
		public async Task<ActionResult<TModel>> Get(Guid id)
		{
			var model = await this._service.Get(id);
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
			var result = (await this._service.Insert(model)).FirstOrDefault();
			if (result == null)
			{
				return BadRequest();
			}

			return CreatedAtRoute(new { id = result.Id }, result);
		}

		[HttpPut("{id}")]
		[ProducesResponseType(202)]
		[ProducesResponseType(404)]
		public async Task<ActionResult<AcceptedAtRouteResult>> Put(Guid id, [FromBody] TModel model)
		{
			var target = await this._service.Get(id);
			if (target == null)
			{
				return NotFound();
			}

			var result = await this._service.Update(id, model);
			return AcceptedAtRoute(new { id = result.Id }, result);
		}

		[HttpPatch("{id}")]
		public async Task<ActionResult<AcceptedAtRouteResult>> Patch(Guid id, [FromBody]JsonPatchDocument<TModel> patch)
		{
			var target = await this._service.Get(id);
			if (target == null)
			{
				return NotFound();
			}

			patch.ApplyTo(target);
			var result = await this._service.Update(id, target);
			return AcceptedAtRoute(new { id = result.Id }, result);
		}

		[HttpDelete("{id}")]
		[ProducesResponseType(200)]
		[ProducesResponseType(400)]
		public async Task<ActionResult<OkResult>> Delete(Guid id)
		{
			await this._service.Delete(id);
			return Ok();
		}
	}
}
