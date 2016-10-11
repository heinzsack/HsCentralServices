using System;






namespace HsCentralServiceWebInterfacesClient.steadyConnection.hubs.ringDistribution.playerDataArgs
{
	[Flags]
	public enum PlayerDataStateTypes
	{
		Playing = 1 << 29,
		Downloading = 1 << 30,
	}
}