using DungeonDelve.Application;
using DungeonDelve.Framework;
using System;

namespace DungeonDelve.ConsoleUI
{
	class Program
	{
		static void Main( string[] args )
		{
			var dependencyResolver = new UnityDependencyResolver();
			dependencyResolver.Load();

			var game = dependencyResolver.Resolve<Game>();
			game.Start();
			Console.ReadLine();
		}
	}
}
