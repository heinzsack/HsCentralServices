using System;






namespace HsCentralServiceWebInterfacesClient.steadyConnection.hubs.ringDistribution.playerDataArgs
{
	[Flags]
	public enum PlayerStates
	{
		None = 0,
		Playing = PlayerDataStateTypes.Playing + (1 << 0),
		DownloadingRing = PlayerDataStateTypes.Downloading + (1 << 4),
		DownloadingFiles = PlayerDataStateTypes.Downloading + (2 << 4),
		RingValidation = PlayerDataStateTypes.Downloading + (3 << 4),
	}
}