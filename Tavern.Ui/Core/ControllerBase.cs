using Microsoft.AspNetCore.Mvc;

namespace Tavern.Ui.Core
{
    [ApiController]
    public abstract class ControllerBase : Controller
    {
        //[HttpGet]
        //public virtual async Task<ActionResult<IEnumerable<TModel>>> Get()
        //{
        //    return await this.Context.Set<TEntity>().ProjectTo<TModel>().ToListAsync();
        //}

        //[HttpGet("{id}")]
        //public async Task<ActionResult<TModel>> Get(Guid id)
        //{
        //    var record = await this.Context.Set<TEntity>().FindAsync(id);
        //    if (record == null)
        //    {
        //        return NotFound();
        //    }

        //    var result = Mapper.Map<TModel>(record);
        //    return result;
        //}

        //[HttpPost]
        //public async Task<ActionResult<CreatedAtRouteResult>> Post([FromBody] TModel model)
        //{
        //    var record = Mapper.Map<TEntity>(model);
        //    record.SetAuditDetails(CurrentUsername);
        //    this.Context.Set<TEntity>().Add(record);
        //    await this.Context.SaveChangesAsync();
        //    return CreatedAtRoute(new { id = record.Id }, record);
        //}

        //[HttpPut("{id}")]
        //public async Task<ActionResult<AcceptedAtRouteResult>> Put(Guid id, [FromBody] TModel model)
        //{
        //    var record = await this.Context.Set<TEntity>().FindAsync(id);
        //    if (record == null)
        //    {
        //        return NotFound();
        //    }

        //    Mapper.Map(model, record);
        //    record.SetAuditDetails(CurrentUsername);
        //    this.Context.Set<TEntity>().Update(record);
        //    await this.Context.SaveChangesAsync();
        //    return AcceptedAtRoute(new { id = record.Id }, model);
        //} 

        //[HttpPatch("{id}")]
        //public async Task<ActionResult<AcceptedAtRouteResult>> Patch(Guid id, [FromBody]JsonPatchDocument<TModel> patch)
        //{
        //    var record = await this.Context.Set<TEntity>().FindAsync(id);
        //    var mappedRecord = Mapper.Map<TModel>(record);
        //    patch.ApplyTo(mappedRecord, this.ModelState);

        //    Mapper.Map(mappedRecord, record);
        //    record.SetAuditDetails(CurrentUsername);
        //    await this.Context.SaveChangesAsync();
        //    return AcceptedAtRoute(new { id = record.Id }, record);
        //}

        //[HttpDelete("{id}")]
        //public async Task<ActionResult<NoContentResult>> Delete(Guid id)
        //{
        //    var record = await this.Context.Set<TEntity>().FindAsync(id);
        //    if (record == null)
        //    {
        //        return NotFound();
        //    }
        //    // ToDo: Soft delete
        //    this.Context.Set<TEntity>().Remove(record);
        //    await this.Context.SaveChangesAsync();
        //    return NoContent();
        //}
    }
}
