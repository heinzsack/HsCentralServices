// Copyright (c) 2016 All rights reserved Christian Sack
// <author>Christian Sack</author>
// <email>christian@sack.at</email>
// <website>christian.sack.at</website>
// <date>2016-09-17</date>

using System;
using CsWpfBase.Ev.Public.Extensions;
using CsWpfBase.Global.transmission.clientIdentification;
using CsWpfBase.Global.transmission.clientIdentification.interfaces;
using HsCentralServiceWeb._dbs.hsserver.centralservicedb.dataset;
using HsCentralServiceWeb._dbs.hsserver.centralservicedb.rows;






namespace HsCentralServiceWeb._sys._extensions
{
	public static class CsClientIdentityExtensions
	{
		public static RemoteInstance GetRemoteInstance(this CsClientIdentification id)
		{
			CentralServiceDb centralServiceDb = Sys.Data.CentralService;
			RemoteInstance appInstance = centralServiceDb.RemoteInstances.FindOrLoad(id.AppInstance.Id);
			RemoteComputer computer = null;
			RemoteUser user = null;
			RemoteApplication application = null;
			if (appInstance != null)
				{
				//TODO check for alwas correct RingFile name creation
				computer = centralServiceDb.RemoteComputers.FindOrLoad(id.Computer.Id);
				String commputerEntry = (computer != null) ? computer.Name : "Name fehlt";
				if ((computer == null)
					|| (String.Compare(computer.Name, id.Computer.Name, 
						StringComparison.OrdinalIgnoreCase ) != 0))
					throw new ArgumentException($"beim zentralen Identifikationseintrag für " +
								$"die Maschine '{id.Computer.Id}' ist \r\n" +
								$"der zentral gespeicherte Computername " +
								$"({commputerEntry})\r\n" +
								$"anders als der System Name des Computers ({id.Computer?.Name})");

				user = centralServiceDb.RemoteUsers.FindOrLoad(id.User.Id);
				String userEntry = (user != null) ? user.Name : "Name fehlt";
				if ((user == null)
					|| (String.Compare(user.Name, id.User?.Name,
						StringComparison.OrdinalIgnoreCase) != 0))
					throw new ArgumentException($"beim zentralen Identifikationseintrag für " +
								$"die Maschine '{id.Computer.Id}' ist \r\n" +
								$"der zentral gespeicherte UserName " +
								$"({userEntry})\r\n" +
								$"anders als der User Name der ClientIdentification ({id.User?.Name})");
				appInstance.LastSeen = DateTime.Now;
				appInstance.DataSet.SaveAnabolic();
				appInstance.DataSet.AcceptChanges();
				return appInstance;
				}

			computer = centralServiceDb.RemoteComputers.FindOrLoad(id.Computer.Id);
			user = centralServiceDb.RemoteUsers.FindOrLoad(id.User.Id);
			application = centralServiceDb.RemoteApplications.FindOrLoad(id.Application.Id);


			if (computer == null)
			{
				computer = centralServiceDb.RemoteComputers.NewRow();
			}
			if (user == null)
				user = centralServiceDb.RemoteUsers.NewRow();
			if (application == null)
				application = centralServiceDb.RemoteApplications.NewRow();
			if (appInstance == null)
			{
				appInstance = centralServiceDb.RemoteInstances.NewRow();
				appInstance.Created = DateTime.Now;
			}


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

			appInstance.DataSet.SaveAnabolic();
			appInstance.DataSet.AcceptChanges();
			return appInstance;
		}
	}
}