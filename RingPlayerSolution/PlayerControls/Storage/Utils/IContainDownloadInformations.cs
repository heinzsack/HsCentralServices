using System;






namespace PlayerControls.Storage.Utils
	{
	public interface IContainDownloadInformations
		{
		string ImageDownloadUrl { get; }
		string VideoDownloadUrl { get; }
		string ReplacementString { get; }
		}
	}