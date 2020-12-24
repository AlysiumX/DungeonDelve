using System;
using System.Collections.Generic;
using System.Text;

namespace DungeonDelve.Core
{
	public class Entity
	{
		public string Name { get; set; }
		public EntityType Type { get; set; }
		public int BaseDamageValue { get; set; }
		public Stats Stats { get; set; }
		public IEnumerable<Ability> Abilities { get; set; }

		//TODO : Equipment.
	}
}
