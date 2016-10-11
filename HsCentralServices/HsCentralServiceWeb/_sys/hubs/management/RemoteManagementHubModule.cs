using System;
using System.Collections.Generic;
using System.Linq;
using HsCentralServiceWeb._dbs.hsserver.centralservicedb.rows;
using HsCentralServiceWeb._dbs.hsserver.centralservicedb.tables;
using HsCentralServiceWebInterfacesClient.steadyConnection.hubs.management;
using HsCentralServiceWebInterfacesClient.steadyConnection.hubs.management.args;






namespace HsCentralServiceWeb._sys.hubs.management
{
	public class RemoteManagementHubModule
	{
		public IEnumerable<RemoteInstance> ConnectedClients 
			= RemoteManagementHub.ConnectionHandler.CurrentConnections.Select(x => x.Identification);

		public void Restart(RemoteInstance client, RestartArgs args)
		{
			dynamic computerConnection = RemoteManagementHub.ConnectionHandler.GetConnection(client);
			if (computerConnection == null)
				return;
			computerConnection.Invoke(nameof(IRemoteManagementHubProtocol.Restart), args);
		}

		/// <summary>See <see cref="IRemoteManagementHubProtocol.Log" /> method.</summary>
		public void Received_Log(RemoteInstance client, LogArgs args)
		{
			lock (Sys.Data)
			{
				WebConfigurationsTable.RemoteLogConfiguration config 
					= Sys.Data.CentralService.WebConfigurations.RemoteLog;
				RemoteLog log = Sys.Data.CentralService.RemoteLogs.NewRow();


				log.SeverityNumber = (int)args.Severity;
				log.Created = args.CreationTime;
				log.Title = args.Title;
				log.Message = args.Message;
				log.CodeFile = args.CodeFile;
				log.CodeMethod = args.CodeMethod;
				log.CodeLine = args.CodeLine;

				log.RemoteInstance = client;
				log.AddToTable();
				config.CurrentCount++;
				config.TotalCount++;

				while (config.CurrentCount > config.MaximumCount)
				{
					Sys.Data.CentralService.RemoteLogs.DbProxy.ExecuteNonQuery
						($"DELETE FROM [{RemoteLogsTable.NativeName}] WHERE [{RemoteLogsTable.IdCol}] " +
						$"IN (SELECT TOP {config.BatchDeleteCount} [{RemoteLogsTable.IdCol}] " +
						$"FROM [{RemoteLogsTable.NativeName}] ORDER BY [{RemoteLogsTable.CreatedCol}] " +
						$"ASC)");
					config.CurrentCount = Sys.Data.CentralService.RemoteLogs.DownloadRowsCount();
				}
				log.DataSet.SaveAnabolic();
				log.DataSet.AcceptChanges();

			}
		}
	}
}