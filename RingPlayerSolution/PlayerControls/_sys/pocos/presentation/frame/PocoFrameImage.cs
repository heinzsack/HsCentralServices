// Copyright (c) 2015-2017 All rights reserved Christian Sack
// <author>Christian Sack</author>
// <email>christian@sack.at</email>
// <website>christian.sack.at</website>
// <created>2017-04-29</creation-date>
// <modified>2017-05-03 17:20</modify-date>

using System;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using CsWpfBase.env.extensions;
using Newtonsoft.Json;
using PlayerControls.Interfaces.presentation.FrameItems;






namespace PlayerControls._sys.pocos.presentation.frame
{
	[JsonObject(MemberSerialization.OptIn)]
	[Serializable]
	public class PocoFrameImage : PocoFrameItem, IFrameImage
	{
		private Guid _frameItemImageId;


		#region EVENTS
		/// <summary>Occurs whenever a image is requested through the <see cref="PocoFrameImage" />.</summary>
		public static event Delegate0 ImageRequested;
		#endregion


		#region Overrides/Interfaces
		/// <inheritdoc />
		public void EditorRequestedImageChange()
		{
			throw new NotImplementedException();
		}


		/// <summary>
		///     The identifier can be used for identifing the <see cref="FrameItemImage" /> inside the <see cref="ImageRequested" />
		///     event.
		/// </summary>
		[JsonProperty("Id")]
		public Guid FrameItemImageId
		{
			get => _frameItemImageId;
			set => SetProperty(ref _frameItemImageId, value);
		}


		/// <inheritdoc />
		[JsonIgnore]
		public BitmapSource FrameItemImage
		{
			get
			{
				var args = new ImageRequestedArgs(this);
				ImageRequested?.Invoke(args);
				return args.Result;
			}
		}
		#endregion



		public delegate void Delegate0(ImageRequestedArgs image);



		public class ImageRequestedArgs
		{
			public ImageRequestedArgs(PocoFrameImage pocoImage)
			{
				PocoImage = pocoImage;
			}

			public PocoFrameImage PocoImage { get; }
			public BitmapSource Result { get; set; }
		}



		public static class Mocks
		{
			private static BitmapSource _sampleImage;

			public static PocoFrameImage LeftTop()
			{
				return Mocking.SetLeftTop(new PocoFrameImage {FrameItemImageId = Guid.Empty});
			}

			public static PocoFrameImage LeftBottom()
			{
				return Mocking.SetLeftBottom(new PocoFrameImage {FrameItemImageId = Guid.Empty});
			}

			public static PocoFrameImage RightTop()
			{
				return Mocking.SetRightTop(new PocoFrameImage {FrameItemImageId = Guid.Empty});
			}

			public static PocoFrameImage RightBottom()
			{
				return Mocking.SetRightBottom(new PocoFrameImage {FrameItemImageId = Guid.Empty});
			}

			public static void HandleEvent()
			{
				SampleImage();
				ImageRequested += args =>
				{
					if (args.PocoImage.FrameItemImageId == Guid.Empty)
						args.Result = SampleImage();
				};
			}

			private static BitmapSource SampleImage()
			{
				if (_sampleImage != null)
					return _sampleImage;

				_sampleImage = new Border
								{
									BorderBrush = Brushes.Black,
									CornerRadius = new CornerRadius(30),
									BorderThickness = new Thickness(3),
									Height = 100,
									Width = 100
								}.ConvertTo_Image();
				_sampleImage.Freeze();
				return _sampleImage;
			}
		}
	}
}