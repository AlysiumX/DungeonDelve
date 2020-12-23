using DungeonDelve.Application.Data;
using DungeonDelve.Core;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace DungeonDelve.Data
{
	public class EntityLoader : IEntityLoader
	{
		public IEnumerable<Entity> RetrieveEntities()
		{
			var entities = new List<Entity>();
			var entityFiles = new DirectoryInfo( $"{Directory.GetCurrentDirectory()}/Entities" ).GetFiles();
			foreach( var entityFile in entityFiles )
			{
				var entityObject = JsonConvert.DeserializeObject<Entity>( File.ReadAllText( entityFile.FullName ) );
				entities.Add( entityObject );
			}

			ValidateEntityListing( entities );

			return entities;
		}

		private void ValidateEntityListing( List<Entity> entityList )
		{
			ValidationNoDuplicateNamesInEntityListing( entityList );
		}

		private void ValidationNoDuplicateNamesInEntityListing( List<Entity> entities )
		{
			var duplicatedEntries = entities.Select( x => x.Name ).GroupBy( n => n ).Where( c => c.Count() > 1 ).Select( x => x.Key );
			var duplicatedEntriesString = string.Join( ",", duplicatedEntries.ToArray() );

			if( duplicatedEntries.Any() )
				throw new Exception( $"Duplicate names found in entity files for the following entities : {duplicatedEntriesString}" );
		}


	}
}
