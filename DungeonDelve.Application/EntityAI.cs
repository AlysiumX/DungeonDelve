using DungeonDelve.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DungeonDelve.Application
{
	/// <summary>
	/// The basic AI for entities is to have a percentage of chance to use an ability other than attack.
	/// </summary>
	public class EntityAI
	{
		private readonly Random _random;
		public EntityAI( Random random )
		{
			_random = random;
		}

		public Ability GetEntityAction( Entity entity )
		{
			var abilityToUse = GetAbilityIfUsagePercentageSucceeds( entity );
			if( abilityToUse != null )
				return abilityToUse;
			else
				return new Ability() { Name = "Basic Attack", DamageValue = entity.BaseDamageValue };
		}

		private Ability GetAbilityIfUsagePercentageSucceeds( Entity entity )
		{
			var abilities = entity.Abilities.ToList();
			foreach( var ability in abilities.OrderBy( x => x.PriorityOrder ) )
			{
				int chance = _random.Next( 1, 100 );

				if( chance <= ability.UsagePercentage )
					return ability;

			}

			return null;
		}

		public Entity SetTargetPlayer( IEnumerable<Entity> players )
		{
			int playerNumber = _random.Next( 0, players.Count() );

			var playerList = players.ToList();
			return playerList[playerNumber];
		}
	}
}
