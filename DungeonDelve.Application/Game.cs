using DungeonDelve.Core;
using System;
using System.Collections.Generic;
using System.Text;

namespace DungeonDelve.Application
{
	public class Game
	{
		private readonly BattleSystem _BattleSystem;
		private readonly List<Entity> _Players;
		public Game( BattleSystem battleSystem )
		{
			_BattleSystem = battleSystem;
			_Players = CreatePlayers();
		}

		private List<Entity> CreatePlayers()
		{
			//TODO : Implement character creation.
			throw new NotImplementedException();
		}

		public void Start()
		{
			//Note : Right now we are jumping straight into battle but in the future we would have the battle system check for random encounters.
			_BattleSystem.StartBattleWithPlayers( _Players );
		}

	}
}
