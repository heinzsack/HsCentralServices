using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using CsWpfBase.Db.models.helper;
using CsWpfBase.Global;
using CsWpfBase.Global.remote.services.dbAccess.components;
using DbsGenerator;
using HsCentralServiceWeb._dbs.hsserver;
using HsCentralServiceWeb._dbs.hsserver.centralservicedb.dataset;
using HsCentralServiceWeb._dbs.hsserver.centralservicedb.tables;






namespace HsCentralServiceWeb._sys.data
{
	public class Data
	{
		public CentralServiceDb CentralService => HsServer.CentralServiceDb;
		private HsServerContext _hsserver;


		private HsServerContext HsServer
		{
			get
			{
				if(_hsserver != null)
					return _hsserver;

				_hsserver = GetConnectedContext();


				return _hsserver;
			}
		}

		private static void AnalyzeChanges(DataTable table)
		{
			if(table.TableName == RemoteLogsTable.NativeName)
				Sys.Hubs.WwwSurferNotification.LogsChanged();
		}

		public HsServerContext GetConnectedContext()
		{
			var context = new HsServerContext();

#if REMOTE
			CsGlobal.Install(GlobalFunctions.Storage);
			CsGlobal.InstallRemote("service.wpmedia.at", "<RSAKeyValue><Modulus>7bTXJULjf3ELHOv/57LyGUTBpgQ7CucbdSXusgy+270FPbK0Iboqkqrhs4rbeKkH6AWA6BwXGqUqAwwVNKHPEtXTpLe9GKM41eZOJyhU7QCw0X8BAQXLbTQbc+QGFn/J/t6wlh7cgrYgqe/3Q9u7yW9+j16Q8Uj4OG4N20fsqX0=</Modulus><Exponent>AQAB</Exponent></RSAKeyValue>");
			CsGlobal.Remote.DbAccess.GetDbProxy(context.CentralServiceDb, new DbAuthentication(DbAccounts.HsServer.DataSource, CentralServiceDb.NativeName, DbAccounts.HsServer.UserName, DbAccounts.HsServer.Password));
#else
				context.Set_DbProxy<HsServerDirectConnector>();
#endif
			context.LoadConstraints();
			return context;
		}

		private class HsServerDirectConnector : CsDbRouter_SqlDirect
		{
			public HsServerDirectConnector()
			{
				DataSource = DbAccounts.HsServer.DataSource;
				UserName = DbAccounts.HsServer.UserName;
				Password = DbAccounts.HsServer.Password;
			}


			public override void SaveChanges(DataTable target, object tag = null)
			{
				base.SaveChanges(target, tag);
				AnalyzeChanges(target);
			}
		}
	}
}