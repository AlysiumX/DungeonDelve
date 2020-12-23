using DungeonDelve.Core;
using System;
using System.Collections.Generic;
using System.Text;

namespace DungeonDelve.Application
{
	public class Encounter
	{
		private readonly MessageLog _messageLog;
		private readonly EntityManager _entityManager;
		private IEnumerable<Entity> _enemies;

		public Encounter( MessageLog messageLog, EntityManager entityManager )
		{
			_messageLog = messageLog;
			_entityManager = entityManager;
		}

		public void LoadEnemies()
		{
			_enemies = GetRandomEnemies();
		}

		public void Start()
		{
			_messageLog.Add( "Encounter Started..." );
		}

		private IEnumerable<Entity> GetRandomEnemies()
		{
			var enemies = _entityManager.GetRandomEnemiesXTimes( 3 );
			return enemies;
		}
	}
}
