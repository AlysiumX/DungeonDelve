using DungeonDelve.Core;
using System;
using System.Collections.Generic;
using System.Text;

namespace DungeonDelve.Application
{
	public class Game
	{
		private readonly BattleSystem _battleSystem;
		private readonly EntityManager _entityManager;
		private readonly List<Entity> _players;
		public Game( BattleSystem battleSystem, EntityManager entityManager )
		{
			_battleSystem = battleSystem;
			_entityManager = entityManager;
			_players = CreatePlayers();
		}

		private List<Entity> CreatePlayers()
		{
			//TODO : Implement character creation.
			var players = new List<Entity>();
			var warrior = _entityManager.GetEntityByName( "Warrior" );
			var rogue = _entityManager.GetEntityByName( "Rogue" );
			var ranger = _entityManager.GetEntityByName( "Ranger" );
			var mage = _entityManager.GetEntityByName( "Mage" );
			var priest = _entityManager.GetEntityByName( "Priest" );

			players.AddRange( new List<Entity>() { warrior, rogue, ranger, mage, priest } );

			return players;
		}

		public void Start()
		{
			//Note : Right now we are jumping straight into battle but in the future we would have the battle system check for random encounters.
			_battleSystem.StartBattleWithPlayers( _players );
		}

	}
}
