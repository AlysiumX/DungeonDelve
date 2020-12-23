using DungeonDelve.Core;
using System;
using System.Collections.Generic;
using System.Linq;

namespace DungeonDelve.Application
{
	public class BattleSystem
	{
		private readonly Encounter _encounter;
		public BattleSystem( Encounter encounter )
		{
			_encounter = encounter;
		}

		public void StartBattleWithPlayers( IEnumerable<Entity> players )
		{
			Console.WriteLine( "Battle Started..." );
			_encounter.LoadEnemies();
			_encounter.Start();
		}
	}
}
