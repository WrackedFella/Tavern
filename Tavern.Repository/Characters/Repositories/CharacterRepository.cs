using System;
using System.Linq.Expressions;
using AutoMapper;
using LinqKit;
using Microsoft.EntityFrameworkCore;
using Tavern.Domain.Characters;
using Tavern.Repository.Characters.Models;
using Tavern.Repository.Characters.Profiles;

namespace Tavern.Repository.Characters.Repositories
{
	public class CharacterRepository : RepositoryBase<Character, CharacterModel>, IDisposable
	{
		private readonly DbContext _context;

		public CharacterRepository(DbContext context) : base(context)
		{
			this._context = context;
			Mapper.Initialize(x => {
				x.CreateMap<Character, CharacterModel>();
				x.CreateMap<CharacterModel, Character>();
			});
		}
		

		public void Dispose()
		{
			if (this._context.ChangeTracker.HasChanges())
			{
				this._context.SaveChanges();
			}

			Mapper.Reset();
		}

		protected override Expression<Func<Character, bool>> BuildPredicate(CharacterModel model)
		{
			ExpressionStarter<Character> predicate = PredicateBuilder.New<Character>(x => x.Name == model.Name);
			return predicate;
		}
	}
}
