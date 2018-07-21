using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using AutoMapper;
using AutoMapper.QueryableExtensions;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Shared;
using Tavern.Domain;

namespace Tavern.Repository
{
	public abstract class RepositoryBase<TEntity, TModel> : IRepository<TModel>
		where TEntity : EntityBase
		where TModel : ModelBase, IEquatable<TEntity>
	{
		protected readonly TavernIdentityContext Context;

		protected RepositoryBase(TavernIdentityContext context)
		{
			this.Context = context;
		}
		
		public virtual async Task<TModel> Get(Guid id)
		{
			var entity = await this.Context.Set<TEntity>().FindAsync(id);
			return entity == null ? null : Mapper.Map<TModel>(entity);
		}

		public virtual async Task<IEnumerable<TModel>> List()
		{
			// ToDo | Task | Paging
			return await this.Context.Set<TEntity>()
				.Take(1000)
				.ProjectTo<TModel>()
				.ToListAsync();
		}

		public virtual async Task<IEnumerable<TModel>> Search(TModel model)
		{
			List<TModel> results = await this.Context.Set<TEntity>()
				.Where(BuildPredicate(model))
				.ProjectTo<TModel>()
				.ToListAsync();

			return results;
		}

		public virtual async Task<TModel> Update(Guid id, TModel model)
		{
			var entity = await this.Context.Set<TEntity>().FindAsync(id);
			if (entity == null)
			{
				throw new NullReferenceException();
			}

			Mapper.Map(model, entity);
			await this.Context.SaveChangesAsync();
			return Mapper.Map<TModel>(entity);
		}

		public virtual async Task<IEnumerable<TModel>> Insert(params TModel[] models)
		{
			List<TEntity> entities = models.Select(Mapper.Map<TEntity>).ToList();
			await this.Context.AddRangeAsync(entities);
			await this.Context.SaveChangesAsync();
			return entities.Select(Mapper.Map<TModel>);
		}

		public virtual async Task Delete(Guid id)
		{
			var entity = await this.Context.Set<TEntity>().FindAsync(id);
			this.Context.Set<TEntity>().Remove(entity);
			this.Context.Remove(entity);
			await this.Context.SaveChangesAsync();
		}

		protected abstract Expression<Func<TEntity, bool>> BuildPredicate(TModel model);

	}
}
