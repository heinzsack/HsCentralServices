using System;






namespace PlayerControls.Interfaces
	{
	public interface IDownloadAble
		{
		Guid IFileIdentifier { get; }
		string IExtension { get; }
		}
	}