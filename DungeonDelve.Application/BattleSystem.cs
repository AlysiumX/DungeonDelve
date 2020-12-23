using DungeonDelve.Core;
using System;
using System.Collections.Generic;
using System.Linq;

namespace DungeonDelve.Application
{
	public class BattleSystem
	{
		private readonly MessageLog _messageLog;
		private readonly Encounter _encounter;
		public BattleSystem( MessageLog messageLog, Encounter encounter )
		{
			_messageLog = messageLog;
			_encounter = encounter;
		}

		public void StartBattleWithPlayers( IEnumerable<Entity> players )
		{
			_messageLog.Add( "Battle Started..." );
			_encounter.LoadEnemies();
			_encounter.StartWithPlayers( players );
		}
	}
}
