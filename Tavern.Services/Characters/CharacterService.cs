using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Tavern.Domain;
using Tavern.Repository.Characters.Models;
using Tavern.Repository.Characters.Repositories;

namespace Tavern.Services.Characters
{
	public class CharacterService : IService<CharacterModel>
	{
		private readonly TavernIdentityContext _context;

		public CharacterService(TavernIdentityContext context)
		{
			this._context = context;
		}

		public async Task<IEnumerable<CharacterModel>> Get()
		{
			IEnumerable<CharacterModel> result;
			using (var repo = new CharacterRepository(this._context))
			{
				result = await repo.List();
			}
			return result;
		}

		public async Task<CharacterModel> Get(Guid id)
		{
			CharacterModel result;
			using (var repo = new CharacterRepository(this._context))
			{
				result = await repo.Get(id);
			}
			return result;
		}

		public async Task<IEnumerable<CharacterModel>> Search(CharacterModel model)
		{
			IEnumerable<CharacterModel> result;
			using (var repo = new CharacterRepository(this._context))
			{
				result = await repo.Search(model);
			}
			return result;
		}

		public async Task<CharacterModel> Update(Guid id, CharacterModel model)
		{
			CharacterModel result;
			using (var repo = new CharacterRepository(this._context))
			{
				result = await repo.Update(id, model);
			}

			return result;
		}

		public async Task<IEnumerable<CharacterModel>> Insert(params CharacterModel[] models)
		{
			IEnumerable<CharacterModel> result;
			using (var repo = new CharacterRepository(this._context))
			{
				result = await repo.Insert(models);
			}

			return result;
		}

		public async Task Delete(Guid id)
		{
			using (var repo = new CharacterRepository(this._context))
			{
				await repo.Delete(id);
			}
		}
	}
}
