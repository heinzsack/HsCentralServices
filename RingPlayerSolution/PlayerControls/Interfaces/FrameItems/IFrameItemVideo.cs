// Copyright (c) 2016 All rights reserved Christian Sack
// <author>Christian Sack</author>
// <email>christian@sack.at</email>
// <website>christian.sack.at</website>
// <date>2017-02-06</date>

using System;
using PlayerControls.Themes.editors;






namespace PlayerControls.Interfaces.FrameItems
{
	/// <summary>Used for presenting videos inside a <see cref="IFrame" />.</summary>
	public interface IFrameItemVideo : IFrameItem
	{
		#region Abstract
		/// <summary>The path to the video.</summary>
		string FrameItemVideoFilePath { get; }

		/// <summary>
		///     Should open or change the video file path stored in <see cref="FrameItemVideoFilePath" />. This method will be used by the
		///     <see cref="FrameEditor" />.
		/// </summary>
		void EditorRequestedVideoChange();
		#endregion
	}
}