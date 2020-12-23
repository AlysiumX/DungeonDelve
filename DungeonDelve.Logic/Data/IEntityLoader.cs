using DungeonDelve.Core;
using System;
using System.Collections.Generic;
using System.Text;

namespace DungeonDelve.Application.Data
{
	public interface IEntityLoader
	{
		IEnumerable<Entity> RetrieveEntities();
	}
}
