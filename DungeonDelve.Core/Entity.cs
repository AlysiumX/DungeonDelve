using System;
using System.Collections.Generic;
using System.Text;

namespace DungeonDelve.Core
{
	public class Entity
	{
		public string Name { get; set; }
		public EntityType Type { get; set; }
		public int Health { get; set; }
		public int Speed { get; set; }
	}
}
