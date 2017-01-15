// Copyright (c) 2016 All rights reserved Christian Sack
// <author>Christian Sack</author>
// <email>christian@sack.at</email>
// <website>christian.sack.at</website>
// <date>2017-01-14</date>

using System;






namespace HsCentralServiceWeb._sys.hubs.webManagement
{
	public class WwwSurferNotificationHubModule
	{
		public void LogsChanged()
		{
			WwwSurferNotificationHub.SendSignal();
		}

		public void ConnectedClientsChanged()
		{
			WwwSurferNotificationHub.SendSignal();
		}
	}
}