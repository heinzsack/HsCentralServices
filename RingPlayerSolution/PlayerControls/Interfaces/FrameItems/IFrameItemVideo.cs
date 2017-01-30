// Copyright (c) 2016 All rights reserved Christian Sack
// <author>Christian Sack</author>
// <email>christian@sack.at</email>
// <website>christian.sack.at</website>
// <date>2017-01-28</date>

using System;






namespace PlayerControls.Interfaces.FrameItems
{
	/// <summary>Used for presenting videos inside a <see cref="IFrame" />.</summary>
	public interface IFrameItemVideo : IFrameItem
	{
		#region Abstract
		/// <summary>The path to the video.</summary>
		string FrameItemVideoFilePath { get; }
		#endregion
	}
}