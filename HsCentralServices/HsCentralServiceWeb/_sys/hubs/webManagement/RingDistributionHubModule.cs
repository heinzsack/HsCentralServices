// Copyright (c) 2016 All rights reserved Christian Sack
// <author>Christian Sack</author>
// <email>christian@sack.at</email>
// <website>christian.sack.at</website>
// <date>2016-09-18</date>

using System;






namespace HsCentralServiceWeb._sys.hubs.webManagement
{
	public class WwwSurferNotificationHubModule
	{
		public void RingDistributionClientsChanged()
		{
			WwwSurferNotificationHub.SendSignal();
		}
		public void LogsChanged()
		{
			WwwSurferNotificationHub.SendSignal();
		}

		public void ComputerConnectionChanged()
			{
			WwwSurferNotificationHub.SendSignal();
			}
		}
	}