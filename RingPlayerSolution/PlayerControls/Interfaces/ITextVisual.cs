using System;
using System.Windows;
using System.Windows.Media;






namespace PlayerControls.Interfaces
	{
	public interface ITextVisual : IBaseVisual
		{
		string IText { get; }
		Color IForeground { get; }
		string IFontFamily { get; }
		FontWeight IFontWeight { get; }
		FontStyle IFontStyle { get; }
		}
	}