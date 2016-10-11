// Copyright (c) 2016 All rights reserved Christian Sack
// <author>Christian Sack</author>
// <email>christian@sack.at</email>
// <website>christian.sack.at</website>
// <date>2016-09-19</date>

using System;
using System.Linq;
using System.Threading.Tasks;
using CsWpfBase.Global.transmission.clientIdentification;
using HsCentralServiceWeb._dbs.hsserver.centralservicedb.rows;
using HsCentralServiceWeb._sys._extensions;
using HsCentralServiceWebInterfacesClient.steadyConnection.hubs.ringDistribution;
using HsCentralServiceWebInterfacesClient.steadyConnection.hubs.ringDistribution.playerDataArgs;
using HsCentralServiceWebInterfacesClient.steadyConnection.hubs.ringDistribution.ringValidationArgs;
using Microsoft.AspNet.SignalR;
using Microsoft.AspNet.SignalR.Hubs;






namespace HsCentralServiceWeb._sys.hubs.ringDistribution
{
	[HubName(nameof(IRingDistributionHubProtocol))]
	public class RingDistributionHub : Hub
	{
		public static HubConnectionHandler<RemoteInstance> ConnectionHandler
			{ get; } = new HubConnectionHandler<RemoteInstance>(GlobalHost.ConnectionManager
				.GetHubContext<RingDistributionHub>(), GetIdentification);

		public static RemoteInstance GetIdentification(HubCallerContext hubCallerContext)
		{
			lock (Sys.Data)
			{
				CsClientIdentification id = CsClientIdentification.Transmission.Get
					(hubCallerContext.Headers.ToDictionary(x => x.Key, x => x.Value));
				return id.GetRemoteInstance();
			}
		}


		#region Overrides/Interfaces
		public override Task OnConnected()
		{
			ConnectionHandler.Connected(Context);
			Sys.Hubs.WwwSurferNotification.RingDistributionClientsChanged();
			return base.OnConnected();
		}

		public override Task OnReconnected()
		{
			ConnectionHandler.Reconnected(Context);
			Sys.Hubs.WwwSurferNotification.RingDistributionClientsChanged();
			return base.OnReconnected();
		}

		public override Task OnDisconnected(bool stopCalled)
		{
			ConnectionHandler.Disconnected(Context);
			Sys.Hubs.WwwSurferNotification.RingDistributionClientsChanged();
			return base.OnDisconnected(stopCalled);
		}
		#endregion


		[HubMethodName(nameof(IRingDistributionHubProtocol.UpdatePlayerData))]
		public void UpdatePlayerData(PlayerDataArgs args)
		{
			Sys.Services.RingDistribution.Communication.UpdatePlayerData(GetIdentification(Context), args);
		}

		[HubMethodName(nameof(IRingDistributionHubProtocol.RingValidation))]
		public RingValidationResultArgs RingValidation(RingValidationArgs args)
		{
			return Sys.Services.RingDistribution.Communication.RingValidation(GetIdentification(Context), args);
		}
	}
}