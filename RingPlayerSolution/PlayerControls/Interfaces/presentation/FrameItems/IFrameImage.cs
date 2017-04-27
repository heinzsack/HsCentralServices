// Copyright (c) 2016 All rights reserved Christian Sack
// <author>Christian Sack</author>
// <email>christian@sack.at</email>
// <website>christian.sack.at</website>
// <date>2017-02-06</date>

using System;
using System.Windows.Media.Imaging;
using PlayerControls.Interfaces.presentation._base;
using PlayerControls.Themes.editors;






namespace PlayerControls.Interfaces.presentation.FrameItems
{
	/// <summary>Used for inserting images inside a <see cref="IFrame" />.</summary>
	public interface IFrameImage : IFrameItem
	{
		#region Abstract
		/// <summary>The source which is used for the image. This will be accessed by an async binding. TAKE CARE OF SYNCHRONIZATION.</summary>
		BitmapSource ImageBitmapSource { get; }

		/// <summary>
		///     Should open or change the image stored in <see cref="ImageBitmapSource" />. This method will be used by the
		///     <see cref="FrameEditor" />.
		/// </summary>
		void EditorRequestedImageChange();
		#endregion
	}
}