// Copyright (c) 2016 All rights reserved Christian Sack
// <author>Christian Sack</author>
// <email>christian@sack.at</email>
// <website>christian.sack.at</website>
// <date>2016-09-19</date>

using System;
using CsWpfBase.Ev.Public.Extensions;






namespace HsCentralServiceWebInterfacesClient.steadyConnection.hubs.ringDistribution.playerDataArgs
{
	/// <summary>Collapses application specific informations about the current ring player instance.</summary>
	public class PlayerDataArgs
	{
		#region Overrides/Interfaces
		/// <summary>The current state of the player.</summary>
		public PlayerStates State { get; set; }

		/// <summary>The current playing ring id.</summary>
		public int? PlayingRingId { get; set; }

		/// <summary>The current downloading ring id.</summary>
		public int? DownloadingRingId { get; set; }
		#endregion


		public bool IsPlaying => State.Includes(PlayerDataStateTypes.Playing);
		public bool IsDownloading => State.Includes(PlayerDataStateTypes.Downloading);
		public PlayerStates DownloadPhase => State & ~PlayerStates.Playing;
	}
}