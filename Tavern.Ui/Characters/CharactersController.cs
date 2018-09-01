using Tavern.Domain;
using Tavern.Domain.Characters;
using Tavern.Ui.Core;

namespace Tavern.Ui.Characters
{
	public class CharactersController : TavernControllerBase<Character>
	{
		public CharactersController(TavernDbContext context) : base(context)
		{
		}
	}
}
