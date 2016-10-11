// Copyright (c) 2016 All rights reserved Christian Sack
// <author>Christian Sack</author>
// <email>christian@sack.at</email>
// <website>christian.sack.at</website>
// <date>2016-09-18</date>

using System;
using System.Threading.Tasks;
using HsCentralServiceWebInterfacesClient.steadyConnection.hubs.ringDistribution.newRingAvailableArgs;
using HsCentralServiceWebInterfacesClient.steadyConnection.hubs.ringDistribution.playerDataArgs;
using HsCentralServiceWebInterfacesClient.steadyConnection.hubs.ringDistribution.ringValidationArgs;






namespace HsCentralServiceWebInterfacesClient.steadyConnection.hubs.ringDistribution
{
	public interface IRingDistributionHubProtocol
	{
		#region Abstract
		/// <summary>Sets the current playing state.</summary>
		Task UpdatePlayerData(PlayerDataArgs args);

		/// <summary>Ask wheter the ring is valid to be played.</summary>
		Task<RingValidationResultArgs> RingValidation(RingValidationArgs args);

		event NewRingAvailableArgs.Delegate NewRingAvailable;
		event PlayerDataRequestArgs.Delegate PlayerDataRequested;
		#endregion
	}



}