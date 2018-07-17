﻿using System;
using System.ComponentModel.DataAnnotations;
using System.Linq.Expressions;
using Shared;
using Tavern.Domain.Characters;

namespace Tavern.Repository.Characters.Models
{
	public class CharacterModel : IPredicateBuilder<Character>
	{
		[Required, MinLength(2), MaxLength(100)]
		public string Name { get; set; }

		[MaxLength(255)]
		public string Description { get; set; }

		public Expression<Func<Character, bool>> BuildPredicate()
		{
			return x => x.Name.StartsWith(this.Name);
		}
	}
}
