using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using CsWpfBase.Db.models.helper;
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
				_hsserver = new HsServerContext();
				_hsserver.Set_DbProxy<HsServerDirectConnector>();
				_hsserver.LoadConstraints();
				return _hsserver;
			}
		}

		private static void AnalyzeChanges(DataTable table)
		{
			if(table.TableName == RemoteLogsTable.NativeName)
				Sys.Hubs.WwwSurferNotification.LogsChanged();
		}


		public class HsServerDirectConnector : CsDbRouter_SqlDirect
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