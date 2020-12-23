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
		private IEnumerable<Entity> _enemies;

		public Encounter( MessageLog messageLog, EntityManager entityManager, TurnSystem turnSystem )
		{
			_messageLog = messageLog;
			_entityManager = entityManager;
			_turnSystem = turnSystem;
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

			await Task.Run( () => StartCombatLoop() );
		}

		private void StartCombatLoop()
		{
			while( _enemies.Where( x => x.Health > 0 ).Any() )
			{
				var entityForCurrentTurn = _turnSystem.GetEntityForCurrentTurn();
				//Execute enemy AI or Allow Player turn.
				_messageLog.Add( $"Current turn is for {entityForCurrentTurn.Name}" );
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
