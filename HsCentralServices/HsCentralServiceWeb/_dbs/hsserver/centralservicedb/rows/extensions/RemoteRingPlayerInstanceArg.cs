// Copyright (c) 2016 All rights reserved Christian Sack
// <author>Christian Sack</author>
// <email>christian@sack.at</email>
// <website>christian.sack.at</website>
// <date>2016-09-19</date>

using HsCentralServiceWebInterfacesClient.steadyConnection.hubs.ringDistribution.playerDataArgs;






namespace HsCentralServiceWeb._dbs.hsserver.centralservicedb.rows
{
	partial class RemoteRingPlayerManagement
	{
		private PlayerDataArgs _playerData;
		///<summary>Gets or sets the PlayerData.</summary>
		public PlayerDataArgs PlayerData
		{
			get { return _playerData; }
			set { SetProperty(ref _playerData, value); }
		}
	}
}