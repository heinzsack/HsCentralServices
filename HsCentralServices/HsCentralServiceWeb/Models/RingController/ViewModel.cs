// Copyright (c) 2016 All rights reserved Christian Sack
// <author>Christian Sack</author>
// <email>christian@sack.at</email>
// <website>christian.sack.at</website>
// <date>2016-10-11</date>

using System;
using HsCentralServiceWeb._dbs.hsserver.centralservicedb.rows;
using HsCentralServiceWebInterfacesServer._dbs.hsserver.ringplayerdb.rows;






namespace HsCentralServiceWeb.Models.RingController
{
	public class ViewModel
	{
		public ViewModel(RemoteInstance remoteInstance, RingMetaData ring)
		{
			RemoteInstance = remoteInstance;
			Ring = ring;
		}

		public RemoteInstance RemoteInstance { get; set; }
		public RingMetaData Ring { get; set; }
	}
}