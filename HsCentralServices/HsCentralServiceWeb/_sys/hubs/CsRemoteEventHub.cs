// Copyright (c) 2016 All rights reserved Christian Sack
// <author>Christian Sack</author>
// <email>christian@sack.at</email>
// <website>christian.sack.at</website>
// <date>2017-01-15</date>

using System;
using System.Linq;
using System.Threading.Tasks;
using CsWpfBase.Global;
using CsWpfBase.Global.remote;
using CsWpfBase.Global.remote.clientIdentification;
using CsWpfBase.Global.remote.services.eventHub;
using HsCentralServiceWeb._dbs.hsserver.centralservicedb.rows;
using HsCentralServiceWeb._sys._extensions;
using JetBrains.Annotations;
using Microsoft.AspNet.SignalR;
using Microsoft.AspNet.SignalR.Hubs;






namespace HsCentralServiceWeb._sys.hubs
{
	[UsedImplicitly]
	[HubName(CsRemoteProtocol.ServiceRoutes.EventHubName)]
	public class CsRemoteEventHub : Hub
	{
		private static HubConnectionHandler<RemoteConnection> ConnectionHandler { get; } = new HubConnectionHandler<RemoteConnection>(GlobalHost.ConnectionManager.GetHubContext<CsRemoteEventHub>(), GetIdentification);

		private static RemoteConnection GetIdentification(HubCallerContext hubCallerContext)
		{
			var id = CsClientIdentification.Transmission.Get(hubCallerContext.Headers.ToDictionary(x => x.Key, x => x.Value));
			var remoteInstance = id.GetRemoteInstance();

			var connection = Sys.Data.CentralService.RemoteConnections.FindOrLoad(Guid.Parse(hubCallerContext.ConnectionId));
			if (connection != null)
				return connection;

			connection = Sys.Data.CentralService.RemoteConnections.NewRow();
			connection.Id = Guid.Parse(hubCallerContext.ConnectionId);
			connection.RemoteInstance = remoteInstance;
			connection.Server = CsGlobal.Os.Info.ComputerName;
			connection.Established = DateTime.Now;
			connection.AddToTable();
			connection.Table.SaveChangesAndAccept();

			return connection;
		}

		static CsRemoteEventHub()
		{
		}


		#region Overrides/Interfaces
		public override Task OnConnected()
		{
			lock (Sys.Data)
			{
				ConnectionHandler.Connected(Context);
				Sys.Hubs.WwwSurferNotification.ConnectedClientsChanged();

				return base.OnConnected();
			}

		}

		public override Task OnReconnected()
		{
			lock (Sys.Data)
			{
				ConnectionHandler.Reconnected(Context);

				return base.OnReconnected();
			}
		}

		public override Task OnDisconnected(bool stopCalled)
		{
			lock (Sys.Data)
			{
				var connection = ConnectionHandler.Disconnected(Context);
				connection.Delete();
				connection.Table.SaveChangesAndAccept();

				Sys.Hubs.WwwSurferNotification.ConnectedClientsChanged();

				return base.OnDisconnected(stopCalled);
			}
		}
		#endregion


		[UsedImplicitly]
		[HubMethodName(EventHubServer.Methods.JoinEvent)]
		public void JoinEvent(string eventName)
		{
			lock (Sys.Data)
			{
				var connection = GetIdentification(Context);
				connection.Events = (connection.Events ?? "") + eventName + ", ";
				connection.Table.SaveChangesAndAccept();

				Groups.Add(Context.ConnectionId, eventName);
				Sys.Hubs.WwwSurferNotification.ConnectedClientsChanged();
			}
		}

		[UsedImplicitly]
		[HubMethodName(EventHubServer.Methods.RaiseEvent)]
		public void RaiseEvent(string eventName, string data)
		{
			Clients.Group(eventName).Invoke(EventHubServer.Methods.ReceiveEvent, eventName, data);
		}
	}
}