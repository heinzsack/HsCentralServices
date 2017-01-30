// Copyright (c) 2016 All rights reserved Christian Sack
// <author>Christian Sack</author>
// <email>christian@sack.at</email>
// <website>christian.sack.at</website>
// <date>2017-01-28</date>

using System;
using System.Windows.Media.Imaging;






namespace PlayerControls.Interfaces.FrameItems
{
	/// <summary>Used for inserting images inside a <see cref="IFrame" />.</summary>
	public interface IFrameItemImage : IFrameItem
	{
		#region Abstract
		/// <summary>The source which is used for the image. This will be accessed by an async binding. TAKE CARE OF SYNCHRONIZATION.</summary>
		BitmapSource ImageBitmapSource { get; }
		#endregion
	}
}