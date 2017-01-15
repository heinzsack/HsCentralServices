// Copyright (c) 2016 All rights reserved Christian Sack
// <author>Christian Sack</author>
// <email>christian@sack.at</email>
// <website>christian.sack.at</website>
// <date>2016-09-17</date>

using System;
using HsCentralServiceWeb._sys.hubs.webManagement;






namespace HsCentralServiceWeb._sys.hubs
{
	public class Hubs
	{
		private WwwSurferNotificationHubModule _wwwSurferNotification;
		private CsRemoteEventHub _csRemoteEventHub;


		public CsRemoteEventHub RemoteManagement => _csRemoteEventHub ?? (_csRemoteEventHub = new CsRemoteEventHub());
		public WwwSurferNotificationHubModule WwwSurferNotification => _wwwSurferNotification ?? (_wwwSurferNotification = new WwwSurferNotificationHubModule());
	}



}