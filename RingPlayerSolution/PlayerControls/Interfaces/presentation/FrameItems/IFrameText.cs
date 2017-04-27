// Copyright (c) 2016 All rights reserved Christian Sack
// <author>Christian Sack</author>
// <email>christian@sack.at</email>
// <website>christian.sack.at</website>
// <date>2017-01-28</date>

using System;
using System.Windows;
using System.Windows.Media;
using PlayerControls.Interfaces.presentation._base;






namespace PlayerControls.Interfaces.presentation.FrameItems
{
	/// <summary>Used for inserting text inside a <see cref="IFrame" />.</summary>
	public interface IFrameText : IFrameItem
	{
		#region Abstract
		/// <summary>The text which should be displayed.</summary>
		string FrameItemText { get; set; }
		/// <summary>The <see cref="Color" /> of the <see cref="FrameItemText" />.</summary>
		Color FrameItemForeground { get; set; }
		/// <summary>The font family of the <see cref="FrameItemText" />.</summary>
		FontFamily FrameItemFontFamily { get; set; }
		/// <summary>The <see cref="FontWeight" /> of the <see cref="FrameItemText" />.</summary>
		FontWeight FrameItemFontWeight { get; set; }
		/// <summary>The <see cref="FontStyle" /> of the <see cref="FrameItemText" />.</summary>
		FontStyle FrameItemFontStyle { get; set; }
		#endregion
	}
}