// Copyright (c) 2016 All rights reserved Christian Sack
// <author>Christian Sack</author>
// <email>christian@sack.at</email>
// <website>christian.sack.at</website>
// <date>2017-01-14</date>

using System;
using System.Collections.Generic;
using System.Linq;
using CsWpfBase.Global.remote.services.eventHub;
using Microsoft.AspNet.SignalR;
using Microsoft.AspNet.SignalR.Hubs;






namespace HsCentralServiceWeb._sys.hubs
{
	public class HubConnectionHandler<TIdentification> where TIdentification : class
	{
		private readonly Func<HubCallerContext, TIdentification> _getIdentificationFunc;
		private IHubContext Context { get; }
		private Dictionary<TIdentification, HubConnection> Connections { get; } = new Dictionary<TIdentification, HubConnection>();
		public HubConnectionHandler(IHubContext context, Func<HubCallerContext, TIdentification> getIdentificationFunc)
		{
			Context = context;
			_getIdentificationFunc = getIdentificationFunc;
		}

		public IEnumerable<HubConnection> CurrentConnections => Connections.Values;


		public dynamic GetConnection(TIdentification identification)
		{
			lock (this)
			{
				HubConnection connection;
				if (!Connections.TryGetValue(identification, out connection))
					return null;

				return Context.Clients.Clients(connection.EstablishedConnections.ToList());
			}
		}

		public TIdentification Connected(HubCallerContext hc)
		{
			lock (this)
			{

				var connection = GetOrCreate_ClientConnection(hc);
				connection.EstablishedConnections.Add(hc.ConnectionId);
				return connection.Identification;
			}
		}

		public TIdentification Reconnected(HubCallerContext hc)
		{
			lock (this)
			{
				var connection = GetOrCreate_ClientConnection(hc);
				connection.EstablishedConnections.Add(hc.ConnectionId);
				return connection.Identification;
			}
		}

		public TIdentification Disconnected(HubCallerContext hc)
		{
			lock (this)
			{
				var connection = Connections.Values.FirstOrDefault(x => x.EstablishedConnections.Contains(hc.ConnectionId));
				if (connection == null)
					return null;
				connection.EstablishedConnections.Remove(hc.ConnectionId);
				if (connection.EstablishedConnections.Count == 0)
					Connections.Remove(connection.Identification);
				return connection.Identification;
			}
		}

		private HubConnection GetOrCreate_ClientConnection(HubCallerContext context)
		{
			lock (this)
			{
				var identification = _getIdentificationFunc(context);
				HubConnection connection;
				if (!Connections.TryGetValue(identification, out connection))
				{
					connection = new HubConnection(identification);
					Connections.Add(identification, connection);
				}
				return connection;
			}
		}



		public class HubConnection
		{
			public HubConnection(TIdentification identification)
			{
				Identification = identification;
				ConnectionStart = DateTime.Now;
			}


			#region Overrides/Interfaces
			public override string ToString()
			{
				return Identification.ToString();
			}
			#endregion


			public TIdentification Identification { get; }
			public DateTime ConnectionStart { get; }
			public HashSet<string> EstablishedConnections { get; } = new HashSet<string>();
		}
	}
}