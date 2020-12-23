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

			var messageLog = dependencyResolver.Resolve<MessageLog>();
			messageLog.MessageAdded += new MessageLog.MessageAddedHandler( DisplayMessage );

			var game = dependencyResolver.Resolve<Game>();
			game.Start();

			Console.ReadLine();
		}

		static void DisplayMessage( object sender, MessageArgs e )
		{
			Console.WriteLine( e.Message );
		}
	}
}
