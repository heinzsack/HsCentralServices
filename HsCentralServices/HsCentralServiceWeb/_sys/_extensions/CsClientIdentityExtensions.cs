// Copyright (c) 2016 All rights reserved Christian Sack
// <author>Christian Sack</author>
// <email>christian@sack.at</email>
// <website>christian.sack.at</website>
// <date>2017-01-14</date>

using System;
using CsWpfBase.Ev.Public.Extensions;
using CsWpfBase.Global.remote.clientIdentification;
using CsWpfBase.Global.remote.clientIdentification.interfaces;
using HsCentralServiceWeb._dbs.hsserver.centralservicedb.rows;






namespace HsCentralServiceWeb._sys._extensions
{
	public static class CsClientIdentityExtensions
	{
		public static RemoteInstance GetRemoteInstance(this CsClientIdentification id)
		{
			lock (Sys.Data)
			{
				var db = Sys.Data.CentralService;

				var appInstance = db.RemoteInstances.FindOrLoad(id.AppInstance.Id);
				if (appInstance != null)
				{
					appInstance.LastSeen = DateTime.Now;
					appInstance.Table.SaveChangesAndAccept();
					return appInstance;
				}

				appInstance = db.RemoteInstances.NewRow();
				var computer = db.RemoteComputers.FindOrLoad(id.Computer.Id);
				var user = db.RemoteUsers.FindOrLoad(id.User.Id);
				var application = db.RemoteApplications.FindOrLoad(id.Application.Id);

				if (computer == null)
					computer = db.RemoteComputers.NewRow();
				if (user == null)
					user = db.RemoteUsers.NewRow();
				if (application == null)
					application = db.RemoteApplications.NewRow();


				id.Computer.CopyTo<ICsClientInfoComputer>(computer);
				id.User.CopyTo<ICsClientInfoUser>(user);
				id.Application.CopyTo<ICsClientInfoApp>(application);
				id.AppInstance.CopyTo<ICsClientInfoAppInstance>(appInstance);

				appInstance.LastSeen = DateTime.Now;

				user.RemoteComputer = computer;
				appInstance.RemoteUser = user;
				appInstance.RemoteApplication = application;

				computer.AddToTable();
				user.AddToTable();
				application.AddToTable();
				appInstance.AddToTable();

				appInstance.DataSet.SaveAnabolicAndAccept();
				return appInstance;
			}
		}
	}
}