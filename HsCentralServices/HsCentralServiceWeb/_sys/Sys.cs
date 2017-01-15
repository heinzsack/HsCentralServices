// Copyright (c) 2016 All rights reserved Christian Sack
// <author>Christian Sack</author>
// <email>christian@sack.at</email>
// <website>christian.sack.at</website>
// <date>2017-01-14</date>

using System;
using System.IO;
using System.Security.Cryptography;
using CsWpfBase.Global;
using CsWpfBase.Global.remote.serverSide;
using HsCentralServiceWeb._dbs.hsserver.centralservicedb.tables;
using HsCentralServiceWeb._sys.data;
using HsCentralServiceWeb._sys.hubs;






namespace HsCentralServiceWeb._sys
{
	public static class Sys
	{
		static Sys()
		{
			InstallCsRemoteServer();
			Data.CentralService.DbProxy.ExecuteCommand($"DELETE FROM {RemoteConnectionsTable.NativeName} WHERE {RemoteConnectionsTable.ServerCol} LIKE '{CsGlobal.Os.Info.ComputerName}'");
		}


		private static Hubs _hubs;
		private static Data _data;


		public static Hubs Hubs => _hubs ?? (_hubs = new Hubs());
		public static Data Data => _data ?? (_data = new Data());
		public static CsRemoteServer RemoteServer => CsRemoteServer.I;


		private static void InstallCsRemoteServer()
		{
			var privateKey = new RSACryptoServiceProvider();
			privateKey.FromXmlString(Data.CentralService.WebConfigurations.DbAccess.PrivateKey);
			CsRemoteServer.InstallServer(new DirectoryInfo(Data.CentralService.WebConfigurations.FileRepository.StorageDirectory), privateKey);
		}
	}
}