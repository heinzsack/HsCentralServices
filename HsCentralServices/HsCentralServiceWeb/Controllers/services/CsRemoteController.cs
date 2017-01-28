// Copyright (c) 2016 All rights reserved Christian Sack
// <author>Christian Sack</author>
// <email>christian@sack.at</email>
// <website>christian.sack.at</website>
// <date>2017-01-26</date>

using System;
using System.Web.Mvc;
using CsWpfBase.Global.remote;
using HsCentralServiceWeb._dbs.hsserver.centralservicedb.dataset;
using HsCentralServiceWeb._sys;
using HsCentralServiceWeb._sys.data;






namespace HsCentralServiceWeb.Controllers.services
{
	public class CsRemoteController : Controller
	{
		[HttpPost]
		[ActionName(CsRemoteProtocol.Mvc.ActionNames.DbAccess)]
		public ActionResult DbAccess()
		{
			Sys.RemoteServer.DbAccess.HandleRequest();
			return new ContentResult();
		}

		[HttpPost]
		[ActionName(CsRemoteProtocol.Mvc.ActionNames.FileRepository)]
		public ActionResult FileRepository()
		{
			using (var db = new CentralServiceDb())
			{
				db.Set_DbProxy<Data.HsServerDirectConnector>();
				db.LoadSchema();
				Sys.RemoteServer.FileRepository.HandleRequest(db.RepositoryFiles);
			}
			return new ContentResult();
		}

		[HttpPost]
		[ActionName(CsRemoteProtocol.Mvc.ActionNames.Log)]
		public ActionResult Log()
		{
			using (var db = new CentralServiceDb())
			{
				db.Set_DbProxy<Data.HsServerDirectConnector>();
				db.LoadSchema();
				Sys.RemoteServer.Log.HandleRequest(db.RemoteLogs);
				Sys.Hubs.WwwSurferNotification.LogsChanged();
			}
			return new ContentResult();
		}
	}
}