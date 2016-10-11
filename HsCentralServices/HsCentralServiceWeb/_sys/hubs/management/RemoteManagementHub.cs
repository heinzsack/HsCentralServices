// Copyright (c) 2016 All rights reserved Christian Sack
// <author>Christian Sack</author>
// <email>christian@sack.at</email>
// <website>christian.sack.at</website>
// <date>2016-09-17</date>

using System;
using System.Threading.Tasks;
using HsCentralServiceWeb._dbs.hsserver.centralservicedb.rows;
using HsCentralServiceWeb._sys.hubs.ringDistribution;
using HsCentralServiceWebInterfacesClient.steadyConnection.hubs.management;
using HsCentralServiceWebInterfacesClient.steadyConnection.hubs.management.args;
using JetBrains.Annotations;
using Microsoft.AspNet.SignalR;
using Microsoft.AspNet.SignalR.Hubs;






namespace HsCentralServiceWeb._sys.hubs.management
{
	[HubName(nameof(IRemoteManagementHubProtocol))]
	public class RemoteManagementHub : Hub
	{
		public static HubConnectionHandler<RemoteInstance> ConnectionHandler { get; } = new HubConnectionHandler<RemoteInstance>(GlobalHost.ConnectionManager.GetHubContext<RingDistributionHub>(), GetIdentification);

		private static RemoteInstance GetIdentification(HubCallerContext hubCallerContext)
		{
			return RingDistributionHub.GetIdentification(hubCallerContext);
		}

		[HubMethodName(nameof(IRemoteManagementHubProtocol.Log))]
		[UsedImplicitly]
		public void Log(LogArgs args)
		{
			Sys.Hubs.RemoteManagement.Received_Log(GetIdentification(Context), args);
		}

		#region Overrides/Interfaces
		public override Task OnConnected()
		{
			ConnectionHandler.Connected(Context);
			return base.OnConnected();
		}

		public override Task OnReconnected()
		{
			ConnectionHandler.Reconnected(Context);
			return base.OnReconnected();
		}

		public override Task OnDisconnected(bool stopCalled)
		{
			ConnectionHandler.Disconnected(Context);
			return base.OnDisconnected(stopCalled);
		}
		#endregion
	}



}