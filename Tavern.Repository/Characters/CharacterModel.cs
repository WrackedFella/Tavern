using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq.Expressions;
using Shared;
using Tavern.Domain.Characters;

namespace Tavern.Repository.Characters
{
	public class CharacterModel : ModelBase, IEquatable<Character>
	{
		[Required, MinLength(2), MaxLength(100)]
		[DisplayName("Character Name")]
		public string Name { get; set; }

		[MaxLength(255)]
		[DisplayName("Describe Them!")]
		public string Description { get; set; }

		public Expression<Func<Character, bool>> BuildPredicate()
		{
			return x => x.Name.StartsWith(this.Name);
		}

		protected bool Equals(CharacterModel other)
		{
			return string.Equals(this.Name, other.Name) && string.Equals(this.Description, other.Description);
		}

		public bool Equals(Character other)
		{
			return this.Name == other.Name;
		}

		public override int GetHashCode()
		{
			return this.Name.GetHashCode();
		}
	}
}
