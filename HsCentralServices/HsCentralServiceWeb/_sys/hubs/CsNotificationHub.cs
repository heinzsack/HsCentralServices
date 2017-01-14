// Copyright (c) 2016 All rights reserved Christian Sack
// <author>Christian Sack</author>
// <email>christian@sack.at</email>
// <website>christian.sack.at</website>
// <date>2017-01-14</date>

using System;
using System.Linq;
using System.Threading.Tasks;
using CsWpfBase.Global.remote.clientIdentification;
using CsWpfBase.Global.remote._protocols;
using HsCentralServiceWeb._dbs.hsserver.centralservicedb.rows;
using HsCentralServiceWeb._sys.hubs.ringDistribution;
using HsCentralServiceWeb._sys.hubs.webManagement;
using HsCentralServiceWeb._sys._extensions;
using HsCentralServiceWebInterfacesClient.steadyConnection.hubs.ringDistribution;
using HsCentralServiceWebInterfacesClient.steadyConnection.hubs.ringDistribution.playerDataArgs;
using Microsoft.AspNet.SignalR;
using Microsoft.AspNet.SignalR.Hubs;






namespace HsCentralServiceWeb._sys.hubs
{
	[HubName(nameof(RemoteProtocol.Notification.Hub.CsNotificationHub))]
	public class CsNotificationHub : Hub
	{
		private static HubConnectionHandler<RemoteInstance> ConnectionHandler { get; } = new HubConnectionHandler<RemoteInstance>(GlobalHost.ConnectionManager.GetHubContext<RingDistributionHub>(), GetIdentification);

		private static RemoteInstance GetIdentification(HubCallerContext hubCallerContext)
		{
			var id = CsClientIdentification.Transmission.Get(hubCallerContext.Headers.ToDictionary(x => x.Key, x => x.Value));
			return id.GetRemoteInstance();
		}


		#region Overrides/Interfaces
		public override Task OnConnected()
		{
			lock(Sys.Data)
			{
				ConnectionHandler.Connected(Context);
				return base.OnConnected();
			}

		}

		public override Task OnReconnected()
		{
			lock(Sys.Data)
			{
				ConnectionHandler.Reconnected(Context);
				return base.OnReconnected();
			}
		}

		public override Task OnDisconnected(bool stopCalled)
		{
			lock(Sys.Data)
			{
				ConnectionHandler.Disconnected(Context);
				return base.OnDisconnected(stopCalled);
			}
		}
		#endregion


		// ReSharper disable once UnusedMember.Global
		[HubMethodName(RemoteProtocol.Notification.Hub.Methods.JoinEvent)]
		public void JoinEvent(string eventName)
		{
			Groups.Add(Context.ConnectionId, eventName);
		}

		// ReSharper disable once UnusedMember.Global
		[HubMethodName(RemoteProtocol.Notification.Hub.Methods.RaiseEvent)]
		public void RaiseEvent(string eventName, string data)
		{
			var @group = Clients.Group(eventName);
			@group.Invoke(RemoteProtocol.Notification.Hub.Methods.ReceiveEvent, eventName, data);
			@group.ReceiveEvent(data);
		}
	}
}