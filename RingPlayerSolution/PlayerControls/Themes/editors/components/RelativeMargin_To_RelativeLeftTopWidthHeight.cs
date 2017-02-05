// Copyright (c) 2016 All rights reserved Christian Sack
// <author>Christian Sack</author>
// <email>christian@sack.at</email>
// <website>christian.sack.at</website>
// <date>2017-02-05</date>

using System;
using System.Globalization;
using System.Windows;
using System.Windows.Data;






namespace PlayerControls.Themes.editors.components
{
	// ReSharper disable once InconsistentNaming
	internal class RelativeMargin_To_RelativeLeftTopWidthHeight : IValueConverter
	{
		#region Overrides/Interfaces
		/// <summary>
		///     Converts a relative margin in percentage into a <see cref="Thickness" /> wit Left, Top, Width, Height. Sample: [30, 20,
		///     50, 10] => [30, 20, 20, 70]
		/// </summary>
		public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
		{
			var thickness = (Thickness) value;
			return new Thickness(thickness.Left, thickness.Top, 100 - (thickness.Right + thickness.Left), 100 - (thickness.Top + thickness.Bottom));
		}

		/// <summary>
		///     Converts a Left, Top, Width and Height in percentage into a relative Margin with percentage. Sample: [30, 20, 20, 70] =>
		///     [30, 20, 50, 10]
		/// </summary>
		public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
		{
			var thickness = (Thickness) value;
			return new Thickness(thickness.Left, thickness.Top, 100 - (thickness.Right + thickness.Left), 100 - (thickness.Top + thickness.Bottom));
		}
		#endregion
	}
}