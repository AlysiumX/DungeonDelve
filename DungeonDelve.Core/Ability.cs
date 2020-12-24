using System;
using System.Collections.Generic;
using System.Text;

namespace DungeonDelve.Core
{
	public class Ability
	{
		public string Name { get; set; }
		public int PriorityOrder { get; set; }
		public string AffectedStats { get; set; } //TODO : List Const?
		public int AffectedStatsValue { get; set; }
		public int CanBeAppliedXTimes { get; set; }
		public int UsagePercentage { get; set; }
		public int DamageValue { get; set; }
	}
}
