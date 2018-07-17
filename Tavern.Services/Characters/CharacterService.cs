using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Tavern.Repository.Characters.Models;
using Tavern.Repository.Characters.Repositories;

namespace Tavern.Services.Characters
{
	public class CharacterService
	{
		private readonly CharacterRepository _repo;

		public CharacterService(DbContext context)
		{
			this._repo = new CharacterRepository(context);
		}

		public async Task<IEnumerable<CharacterModel>> CreateCharacters(params CharacterModel[] characters)
		{
			return await this._repo.Insert(characters);
		}
	}
}
