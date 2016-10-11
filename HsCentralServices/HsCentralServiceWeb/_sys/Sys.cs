// Copyright (c) 2016 All rights reserved Christian Sack
// <author>Christian Sack</author>
// <email>christian@sack.at</email>
// <website>christian.sack.at</website>
// <date>2016-10-11</date>

using System;
using System.Collections.Generic;
using System.Linq;
using CsWpfBase.Ev.Public.Extensions;
using HsCentralServiceWeb._sys.data;
using HsCentralServiceWeb._sys.hubs;
using HsCentralServiceWeb._sys.services;
using HsCentralServiceWebInterfacesServer;






namespace HsCentralServiceWeb._sys
{
	public static class Sys
	{
		private static Hubs _hubs;
		private static ServerHandler _rcData;
		private static Data _data;  
		private static Services _services;


		public static Hubs Hubs => _hubs ?? (_hubs = new Hubs());
		public static IServer Server => _rcData ?? (_rcData = new ServerHandler());
		public static Data Data => _data ?? (_data = new Data());
		public static Services Services => _services ?? (_services = new Services());



		private class ServerHandler : IServer
		{
			private readonly Dictionary<object, object> _storage = new Dictionary<object, object>();


			#region Overrides/Interfaces
			/// <summary>Stores the <paramref name="obj" /> under the specified key into the current running server instance.</summary>
			/// <param name="key">A unique key for the <paramref name="obj" />.</param>
			/// <param name="obj">The obj which needs to be stored in RAM.</param>
			public void Save(object key, object obj)
			{
				if (!_storage.ContainsKey(key))
				{
					_storage.Add(key, obj);
					return;
				}
				_storage[key] = obj;
			}

			/// <summary>Searches the currently stored instances for the specified key. If no such key is found null will be returned.</summary>
			/// <param name="key">The key of the requested object.</param>
			public object Load(object key)
			{
				object obj;
				if (!_storage.TryGetValue(key, out obj))
					return null;
				return obj;
			}

			/// <summary>Searches the currently stored instances for the specified key. If no such key is found null will be returned.</summary>
			/// <param name="key">The key of the requested object.</param>
			public TCast Load<TCast>(object key)
			{
				var load = Load(key);
				return load != null ? (TCast) load : default(TCast);
			}
			#endregion
		}
	}
}