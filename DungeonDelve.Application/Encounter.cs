using DungeonDelve.Core;
using System;
using System.Collections.Generic;
using System.Text;

namespace DungeonDelve.Application
{
	public class Encounter
	{
		private readonly EntityManager _entityManager;
		private IEnumerable<Entity> _enemies;

		public Encounter( EntityManager entityManager )
		{
			_entityManager = entityManager;
		}

		public void LoadEnemies()
		{
			_enemies = GetRandomEnemies();
		}

		public void Start()
		{
			throw new NotImplementedException();
		}

		private IEnumerable<Entity> GetRandomEnemies()
		{
			var enemies = _entityManager.GetRandomEnemiesXTimes( 3 );
			return enemies;
		}
	}
}
