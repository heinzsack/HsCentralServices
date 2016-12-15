using System;
using System.Collections.Generic;
using System.Linq;
using HsCentralServiceWeb._dbs.hsserver.centralservicedb.rows;
using HsCentralServiceWebInterfacesClient.steadyConnection.hubs.ringDistribution;
using HsCentralServiceWebInterfacesClient.steadyConnection.hubs.ringDistribution.newRingAvailableArgs;
using HsCentralServiceWebInterfacesClient.steadyConnection.hubs.ringDistribution.playerDataArgs;






namespace HsCentralServiceWeb._sys.hubs.ringDistribution
{
	public class RingDistributionHubModule
		{
		public IEnumerable<RemoteInstance> ConnectedClients
			= RingDistributionHub.ConnectionHandler.CurrentConnections.Select(x => x.Identification)
				.OrderBy(ord => ord.RemoteUser.RemoteComputer.Name);

		public IEnumerable<RemoteComputer> UnConnectedComputer
			{
			get
				{
				List<RemoteComputer> connectedRemoteComputer = RingDistributionHub.ConnectionHandler
					.CurrentConnections.Select(x => x.Identification).Select(sel => sel.RemoteUser.RemoteComputer)
					.OrderBy(ord => ord.Name).ToList();
				 return Sys.Data.CentralService.RemoteComputers
					.Where(whe => connectedRemoteComputer.Contains(whe) == false)
					.OrderBy(ord => ord.Name);
				}
			}

		public void OnNewRingAvailable(RemoteInstance client, NewRingAvailableArgs args)
			{
			dynamic computerConnection = RingDistributionHub.ConnectionHandler.GetConnection(client);
			if (computerConnection == null)
				return;
			computerConnection.Invoke(nameof(IRingDistributionHubProtocol.NewRingAvailable), args);
			}

		public void OnPlayerDataRequested(RemoteInstance client, PlayerDataRequestArgs args)
			{
			dynamic computerConnection = RingDistributionHub.ConnectionHandler.GetConnection(client);
			if (computerConnection == null)
				return;
			computerConnection.Invoke(nameof(IRingDistributionHubProtocol.PlayerDataRequested), args);
			}
		}
}