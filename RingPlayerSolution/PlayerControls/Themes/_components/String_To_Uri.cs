// Copyright (c) 2015-2017 All rights reserved Christian Sack
// <author>Christian Sack</author>
// <email>christian@sack.at</email>
// <website>christian.sack.at</website>
// <created>2017-05-05</creation-date>
// <modified>2017-05-05 11:40</modify-date>

using System;
using System.Globalization;
using System.Windows.Data;



// ReSharper disable once InconsistentNaming



namespace PlayerControls.Themes._components
{
	internal class String_To_Uri : IValueConverter
	{


		#region Overrides/Interfaces
		/// <inheritdoc />
		public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
		{
			if (value == null)
				return  null;
			return new Uri((string)value, UriKind.Absolute);
		}

		/// <inheritdoc />
		public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
		{
			throw new NotImplementedException();
		}
		#endregion


	}
}