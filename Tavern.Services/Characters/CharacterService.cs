using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Tavern.Repository.Characters.Models;
using Tavern.Repository.Characters.Repositories;

namespace Tavern.Services.Characters
{
	public class CharacterService : IService<CharacterModel>
    {
		private readonly CharacterRepository _repo;

		public CharacterService(DbContext context)
		{
			this._repo = new CharacterRepository(context);
		}
        
        public async Task<CharacterModel> Get(Guid id)
        {
            return await this._repo.Get(id);
        }

        public async Task<IEnumerable<CharacterModel>> List()
        {
            return await this._repo.List();
        }

        public async Task<IEnumerable<CharacterModel>> Search(CharacterModel model)
        {
            return await this._repo.Search(model);
        }

        public async Task<CharacterModel> Update(CharacterModel model)
        {
            return await this._repo.Update(model);
        }

        public async Task<IEnumerable<CharacterModel>> Insert(params CharacterModel[] models)
        {
            return await this._repo.Insert(models);
        }

        public async Task Delete(int id)
        {
            await this._repo.Delete(id);
        }
    }
}
