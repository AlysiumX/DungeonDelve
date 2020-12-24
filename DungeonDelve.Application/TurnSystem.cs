using DungeonDelve.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DungeonDelve.Application
{
	public class TurnSystem
	{
		private List<Entity> EntitiesInTurnOrder;
		private int CurrentTurn = 0;

		public void AddEntities( IEnumerable<Entity> entities )
		{
			EntitiesInTurnOrder = entities.OrderByDescending( x => x.Stats.AttackSpeed ).ToList();
		}

		public Entity GetEntityForCurrentTurn()
		{
			return EntitiesInTurnOrder[CurrentTurn];
		}

		public void GoToNextTurn()
		{
			CurrentTurn++;

			if( CurrentTurn == EntitiesInTurnOrder.Count() )
				CurrentTurn = 0;
		}
	}
}
