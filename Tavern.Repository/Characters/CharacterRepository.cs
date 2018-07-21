using System;
using System.Linq.Expressions;
using AutoMapper;
using LinqKit;
using Tavern.Domain;
using Tavern.Domain.Characters;

namespace Tavern.Repository.Characters
{
	public class CharacterRepository : RepositoryBase<Character, CharacterModel>, IDisposable
	{
		private readonly TavernIdentityContext _context;

		public CharacterRepository(TavernIdentityContext context) : base(context)
		{
			this._context = context;
			Mapper.Initialize(x => {
				x.CreateMap<Character, CharacterModel>()
					.ForMember(dest => dest.Id, opt => opt.MapFrom(src => src.CharacterId));
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
