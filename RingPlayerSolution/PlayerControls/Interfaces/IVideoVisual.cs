using System;






namespace PlayerControls.Interfaces
	{
	public interface IVideoVisual : IBaseVisual
		{
		string IFileName { get; }
		Guid IFileIdentifier { get; }
		string IExtension { get; }
		}
	}