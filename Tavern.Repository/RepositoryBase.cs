using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using AutoMapper;
using AutoMapper.QueryableExtensions;
using Microsoft.EntityFrameworkCore;
using Shared;

namespace Tavern.Repository
{
	public abstract class RepositoryBase<TEntity, TModel, TKey> : IRepository<TModel>
		where TEntity : EntityBase
		where TModel : ModelBase<TKey>, IEquatable<TEntity>
	{
		protected readonly DbContext Context;

		protected RepositoryBase(DbContext context)
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
				.Where(BuildPredicate(model))
				.ProjectTo<TModel>()
				.ToListAsync();

			return results;
		}

		public virtual async Task<TModel> Update(TModel model)
		{
			var entity = await this.Context.Set<TEntity>()
				.SingleAsync(x => model.Equals(x));
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

		public virtual async Task Delete(int id)
		{
			var entity = await this.Context.Set<TEntity>().FindAsync(id);
			this.Context.Set<TEntity>().Remove(entity);
			this.Context.Remove(entity);
			await this.Context.SaveChangesAsync();
		}

		protected abstract Expression<Func<TEntity, bool>> BuildPredicate(TModel model);

	}
}
