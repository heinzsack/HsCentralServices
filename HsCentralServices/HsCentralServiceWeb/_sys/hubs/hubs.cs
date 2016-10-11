// Copyright (c) 2016 All rights reserved Christian Sack
// <author>Christian Sack</author>
// <email>christian@sack.at</email>
// <website>christian.sack.at</website>
// <date>2016-09-17</date>

using System;
using HsCentralServiceWeb._sys.hubs.management;
using HsCentralServiceWeb._sys.hubs.ringDistribution;
using HsCentralServiceWeb._sys.hubs.webManagement;






namespace HsCentralServiceWeb._sys.hubs
{
	public class Hubs
	{
		private RemoteManagementHubModule _remoteManagement;
		private RingDistributionHubModule _ringDistribution;
		private WwwSurferNotificationHubModule _wwwSurferNotification;


		public RingDistributionHubModule RingDistribution => _ringDistribution ?? (_ringDistribution = new RingDistributionHubModule());
		public RemoteManagementHubModule RemoteManagement => _remoteManagement ?? (_remoteManagement = new RemoteManagementHubModule());
		public WwwSurferNotificationHubModule WwwSurferNotification => _wwwSurferNotification ?? (_wwwSurferNotification = new WwwSurferNotificationHubModule());
	}



}