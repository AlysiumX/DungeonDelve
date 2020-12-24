using DungeonDelve.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace DungeonDelve.Application
{
	public class Encounter
	{
		private readonly MessageLog _messageLog;
		private readonly EntityManager _entityManager;
		private readonly TurnSystem _turnSystem;
		private readonly EntityAI _entityAI;
		private IEnumerable<Entity> _enemies;

		public Encounter( MessageLog messageLog, EntityManager entityManager, TurnSystem turnSystem, EntityAI entityAI )
		{
			_messageLog = messageLog;
			_entityManager = entityManager;
			_turnSystem = turnSystem;
			_entityAI = entityAI;
		}

		public void LoadEnemies()
		{
			_enemies = GetRandomEnemies();
		}

		public async void StartWithPlayers( IEnumerable<Entity> players )
		{
			_messageLog.Add( "Encounter Started..." );

			var playersText = string.Join( ",", players.Select( x => x.Name ) );
			_messageLog.Add( $"Players are {playersText}" );

			var enemiesText = string.Join( ",", _enemies.Select( x => x.Name ) );
			_messageLog.Add( $"Enemies are {enemiesText}" );

			var allEntities = players.Concat( _enemies );

			_turnSystem.AddEntities( allEntities );

			await Task.Run( () => StartCombatLoopWithPlayers( players ) );
		}

		private void StartCombatLoopWithPlayers( IEnumerable<Entity> players )
		{
			while( _enemies.Where( x => x.Stats.Health > 0 ).Any() )
			{
				var entityForCurrentTurn = _turnSystem.GetEntityForCurrentTurn();
				_messageLog.Add( $"Current turn is for {entityForCurrentTurn.Name}" );

				//TODO : This should probably be moved to a sub class of entity.
				if( entityForCurrentTurn.Type == EntityType.Enemy )
				{
					var abilityToUse = _entityAI.GetEntityAction( entityForCurrentTurn );
					var target = _entityAI.SetTargetPlayer( players );
					_messageLog.Add( $"{entityForCurrentTurn.Name} uses {abilityToUse.Name} on {target.Name}" );
				}

				Thread.Sleep( 1000 );
				_turnSystem.GoToNextTurn();
			}
		}

		private IEnumerable<Entity> GetRandomEnemies()
		{
			var enemies = _entityManager.GetRandomEnemiesXTimes( 3 );
			return enemies;
		}
	}
}
