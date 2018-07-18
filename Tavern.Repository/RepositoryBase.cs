using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using AutoMapper.QueryableExtensions;
using Microsoft.EntityFrameworkCore;
using Shared;

namespace Tavern.Repository
{
	public class RepositoryBase<TEntity, TModel> : IRepository<TModel>
		where TEntity : EntityBase
		where TModel : IPredicateBuilder<TEntity>
	{
		protected readonly DbContext Context;

		public RepositoryBase(DbContext context)
		{
			this.Context = context;
		}

		public virtual async Task<TModel> Get(Guid id)
		{
			var entity = await this.Context.Set<TEntity>().FindAsync(id);
			return Mapper.Map<TModel>(entity);
		}

		public virtual async Task<IEnumerable<TModel>> List()
		{
			return await this.Context.Set<TEntity>()
				.ProjectTo<TModel>()
				.ToListAsync();
		}

		public virtual async Task<IEnumerable<TModel>> Search(TModel model)
		{
			List<TModel> results = await this.Context.Set<TEntity>()
				.Where(model.BuildPredicate())
				.ProjectTo<TModel>()
				.ToListAsync();

			return results;
		}

		public virtual async Task<TModel> Update(TModel model)
		{
			var entity = await this.Context.Set<TEntity>().FirstOrDefaultAsync(model.BuildPredicate());
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
			List<TEntity> entities = models.Select(model => Mapper.Map<TEntity>(model)).ToList();
			await this.Context.AddRangeAsync(entities);
			await this.Context.SaveChangesAsync();
			return entities.Select(Mapper.Map<TModel>);
		}

		public virtual async Task Delete(int id)
		{
			var entity = await this.Context.Set<TEntity>().FindAsync(id);
			this.Context.Set<TEntity>().Remove(entity);
			this.Context.Remove(entity);
			await this.Context.SaveChangesAsync();
		}
	}
}
