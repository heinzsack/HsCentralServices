using System;
using HsCentralServiceWeb._dbs.hsserver.centralservicedb.rows;
using HsCentralServiceWebInterfacesClient.steadyConnection.hubs.ringDistribution.playerDataArgs;
using HsCentralServiceWebInterfacesClient.steadyConnection.hubs.ringDistribution.ringValidationArgs;
using HsCentralServiceWebInterfacesServer._dbs.hsserver.ringplayerdb.rows;






namespace HsCentralServiceWeb._sys.services.ringdistribution.communication
{
	public class RingDistributionCommunication
	{
		public void UpdatePlayerData(RemoteInstance instance, PlayerDataArgs args)
		{
			lock (Sys.Data)
			{
				instance.RingPlayerManagement.PlayerData = args;
				instance.RingPlayerManagement.LastUpdated = DateTime.Now;
				Sys.Data.CentralService.SaveAnabolic();
				Sys.Data.CentralService.AcceptChanges();

				Sys.Hubs.WwwSurferNotification.RingDistributionClientsChanged();
			}
		}

		public RingValidationResultArgs RingValidation(RemoteInstance instance, RingValidationArgs args)
		{
			lock (Sys.Data)
			{
				try
				{
					RingMetaData ring = Sys.Services.RingDistribution.Storage.Ring.Get(instance.RemoteUser.RemoteComputer, args.RingId);
					if (ring == null)
						return new RingValidationResultArgs() {Valid = false};

					Sys.Services.RingDistribution.Storage.Ring.Store_AsCurrentPlaying(instance.RemoteUser.RemoteComputer, ring);
					return new RingValidationResultArgs() {Valid = true};

				}
				catch (Exception)
				{
					return new RingValidationResultArgs() {Valid = false};
				}
			}
		}
	}
}