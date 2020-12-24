using DungeonDelve.Application.Data;
using DungeonDelve.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DungeonDelve.Application
{
	public class EntityManager
	{
		private readonly IEnumerable<Entity> _LoadedEntities;
		private readonly Random _random;
		public EntityManager( IEntityLoader entityLoader, Random random )
		{
			_LoadedEntities = entityLoader.RetrieveEntities();
			_random = random;
		}

		public IEnumerable<Entity> GetRandomEnemiesXTimes( int enemyCount )
		{
			var enemiesList = _LoadedEntities.Where( x => x.Type == EntityType.Enemy ).ToList();
			for( var i = 0; i < enemyCount; i++ )
			{
				int number = _random.Next( 0, enemiesList.Count() );
				yield return enemiesList[number];
			}
		}

		public Entity GetEntityByName( string entityName )
		{
			if( !_LoadedEntities.Where( x => x.Name == entityName ).Any() )
				throw new Exception( $"No entity found for the name {entityName}" );

			return _LoadedEntities.Where( x => x.Name == entityName ).FirstOrDefault();
		}
	}
}
