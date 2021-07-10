using System;
using System.Threading.Tasks;
using Tavern.DataAccess;
using Tavern.Domain.Shadowrun.Models;

namespace Tavern.Domain.Shadowrun.Services
{
    public interface ICharacterService
    {
        Task<CharacterModel> GenerateCharacter();
    }

    public class CharacterService : ICharacterService
    {
        private readonly ITavernDbContext _dbContext;

        public CharacterService(ITavernDbContext dbContext)
        {
            this._dbContext = dbContext;
        }

        public Task<CharacterModel> GenerateCharacter()
        {
            // ToDo: Figure out how we want to do 'advanced' generation.
            //  We can do an options struct that has various flags and properties
            //  OR we can simply pass an enum type (Ganger, MafiaEnforcer, Fixer, Barkeep)
            
            // Also, do we want to save these characters to the DB or just generate them
            //  and leave the concern of adding them up to the implementer (make another Service call)?

            throw new NotImplementedException();
        }
    }
}
