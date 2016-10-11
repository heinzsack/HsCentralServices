using System;
using System.Windows.Media.Imaging;






namespace PlayerControls.Interfaces
	{
	public interface IImageVisual : IBaseVisual
		{
		BitmapSource IBitmapSource { get; }
		}
	}