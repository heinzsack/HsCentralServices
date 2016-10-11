using System;
using HsCentralServiceWebInterfacesClient.steadyConnection;
using RingPlayer24._sys.services;
using RingPlayer24._sys.storage;

namespace RingPlayer24._sys
	{
	public static class Sys
		{
		private static Storage _storage;
		private static SteadyConnection _serverConnection;
		private static Services _services;

		public static SteadyConnection ServerConnection => _serverConnection ?? (_serverConnection = new SteadyConnection(true, true));
		public static Storage Storage => _storage ?? (_storage = new Storage());
		public static Services Services => _services ?? (_services = new Services());

		public static String ConnectionStateDescription
			{
			get { return ServerConnection.ConnectionStateDescription; }
			}
		}
	}
