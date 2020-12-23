using System;
using System.Collections.Generic;
using System.Text;

namespace DungeonDelve.Application
{
	public class MessageLog
	{
		public delegate void MessageAddedHandler( object messageLogObject, MessageArgs messageArgs );
		public event MessageAddedHandler MessageAdded;

		private readonly List<string> Messages;
		public MessageLog()
		{
			Messages = new List<string>();
		}

		public void Add( string message )
		{
			Messages.Add( message );
			MessageAdded( this, new MessageArgs( message ) );
		}

	}

	public class MessageArgs : EventArgs
	{
		public string Message { get; set; }
		public MessageArgs( string message )
		{
			Message = message;
		}
	}
}
