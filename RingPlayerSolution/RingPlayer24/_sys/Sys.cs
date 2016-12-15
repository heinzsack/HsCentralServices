using System;
using ErrorLogging;
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

//TODO local FileLog to find transmission Errors, which could not be reported to Server (Wendeltreppen Problem)
		private static HsLocalLogging _hsLog;
		public static HsLocalLogging HsLog => _hsLog ?? (_hsLog = new HsLocalLogging());

		public static String ConnectionStateDescription
			{
			get { return ServerConnection.ConnectionStateDescription; }
			}
		}
	}
