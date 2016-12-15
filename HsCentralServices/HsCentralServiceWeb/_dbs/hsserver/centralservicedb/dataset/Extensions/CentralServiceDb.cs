using System;
using System.Collections.Generic;
using System.IO;
using HsCentralServiceWeb._dbs.hsserver.centralservicedb.rows;
using HsCentralServiceWeb._dbs.hsserver.centralservicedb.tables;

namespace HsCentralServiceWeb._dbs.hsserver.centralservicedb.dataset
	{
	public partial class CentralServiceDb
		{
		public String RemoteInstanceDescription(Guid remoteInstanceId)
			{
			RemoteInstance remoteInstance = RemoteInstances.FindOrLoad(remoteInstanceId);
			if (remoteInstance == null)
				{
				throw new FileNotFoundException($"Für die RemoteInstanceId ({remoteInstanceId}) wurde kein DatenBank Eintrag gefunden");
				}
			RemoteUser remoteUser = RemoteUsers.FindOrLoad(remoteInstance.RemoteUserId);
			return
				$"{remoteUser.RemoteComputer.Name}, {remoteInstance.RemoteUser.Domain}/{remoteInstance.RemoteUser.Name}, {remoteInstance.RemoteApplication.Name}";
			}


		private bool _loadAllHasBeenInvoked = false;
		public void LoadAll_IfHasNotBeenLoaded()
			{
			if (_loadAllHasBeenInvoked)
				return;
			LoadAll();
			}
		private void LoadAll()
			{
			_loadAllHasBeenInvoked = true;
			List<String> SelectedStatementsForRefresh = new List<string>()
				{
				$"Select * from {RemoteInstancesTable.NativeName} ",
				$"Select * from {RemoteComputersTable.NativeName}",
				$"Select * from {RemoteApplicationsTable.NativeName}",
				$"Select * from {RemoteLogsTable.NativeName}",
				$"Select * from {RemoteRingPlayerManagementsTable.NativeName}",
				$"Select * from {RemoteUsersTable.NativeName}",
				$"Select * from {WebConfigurationsTable.NativeName}",
				$"Select * from {WebLogsTable.NativeName}",
				$"Select * from {WebUsersTable.NativeName}"
				};

			DownloadTables(String.Join(";", SelectedStatementsForRefresh));

				{
				SetHasBeenLoaded();
				AcceptChanges();
				}
			}

		}
	}