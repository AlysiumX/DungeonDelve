using DungeonDelve.Application;
using DungeonDelve.Application.Data;
using DungeonDelve.Data;
using System;
using Unity;

namespace DungeonDelve.Framework
{
	public class UnityDependencyResolver
	{
		private readonly UnityContainer _container;

		public T Resolve<T>()
		{
			return _container.Resolve<T>();
		}

		public UnityDependencyResolver()
		{
			_container = new UnityContainer();
		}

		public void Load()
		{
			_container.RegisterType<IEntityLoader, EntityLoader>();
			_container.RegisterSingleton<MessageLog>();
			_container.RegisterSingleton<Game>();
		}
	}
}
