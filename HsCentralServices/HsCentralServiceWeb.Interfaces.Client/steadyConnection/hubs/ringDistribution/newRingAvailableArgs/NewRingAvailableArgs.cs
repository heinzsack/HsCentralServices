// Copyright (c) 2016 All rights reserved Christian Sack
// <author>Christian Sack</author>
// <email>christian@sack.at</email>
// <website>christian.sack.at</website>
// <date>2016-09-19</date>

using System;






namespace HsCentralServiceWebInterfacesClient.steadyConnection.hubs.ringDistribution.newRingAvailableArgs
{
	/// <summary>Is used for the <see cref="IRingDistributionHubProtocol.NewRingAvailable" /> event.</summary>
	public class NewRingAvailableArgs 
	{
		#region Overrides/Interfaces
		public override string ToString()
		{
			return $"[RingId = {RingId}, DownloadUrl='{DownloadUrl}', Images='{ImageDownloadUrl}', Videos='{VideoDownloadUrl}']";
		}
		#endregion


		public int RingId { get; set; }

		public string DownloadUrl { get; set; }
		public string ImageDownloadUrl { get; set; }
		public string VideoDownloadUrl { get; set; }
		public string ImageVideoReplacementString { get; set; }



		public delegate void Delegate(NewRingAvailableArgs args);
	}
}