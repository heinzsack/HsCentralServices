// Copyright (c) 2015-2017 All rights reserved Christian Sack
// <author>Christian Sack</author>
// <email>christian@sack.at</email>
// <website>christian.sack.at</website>
// <created>2017-04-27</creation-date>
// <modified>2017-04-28 16:15</modify-date>

using System;
using Newtonsoft.Json;
using PlayerControls.Interfaces.presentation.FrameItems;






namespace PlayerControls._sys.pocos.presentation
{
	[JsonObject(MemberSerialization.OptIn)]
	[Serializable]
	public class PocoFrameVideo : PocoFrameItem, IFrameVideo
	{
		private Guid? _frameItemVideoId;


		#region EVENTS
		/// <summary>Occurs whenever a image is requested through the <see cref="PocoFrameImage" />.</summary>
		public static event Delegate0 VideoRequested;
		#endregion


		#region Overrides/Interfaces
		/// <inheritdoc />
		[JsonIgnore]
		public string FrameItemVideoFilePath
		{
			get
			{
				var args = new VideoRequestedArgs(this);
				VideoRequested?.Invoke(args);
				return args.FilePath;
			}
		}
		/// <summary>
		///     The identifier can be used for identifing the <see cref="FrameItemVideoFilePath" /> inside the
		///     <see cref="VideoRequested" /> event.
		/// </summary>
		[JsonProperty("Id")]
		public Guid? FrameItemVideoId
		{
			get => _frameItemVideoId;
			set => SetProperty(ref _frameItemVideoId, value);
		}

		/// <inheritdoc />
		public void EditorRequestedVideoChange()
		{
			throw new NotImplementedException();
		}
		#endregion



		public delegate void Delegate0(VideoRequestedArgs args);



		public class VideoRequestedArgs
		{
			public VideoRequestedArgs(PocoFrameVideo pocoVideo)
			{
				PocoVideo = pocoVideo;
			}

			public PocoFrameVideo PocoVideo { get; }
			public string FilePath { get; set; }
		}
	}
}