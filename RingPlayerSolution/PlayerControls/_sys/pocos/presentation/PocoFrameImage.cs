// Copyright (c) 2015-2017 All rights reserved Christian Sack
// <author>Christian Sack</author>
// <email>christian@sack.at</email>
// <website>christian.sack.at</website>
// <created>2017-04-26</creation-date>
// <modified>2017-04-27 09:48</modify-date>

using System;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using CsWpfBase.Ev.Public.Extensions;
using Newtonsoft.Json;
using PlayerControls.Interfaces.presentation.FrameItems;






namespace PlayerControls._sys.pocos.presentation
{
	[JsonObject(MemberSerialization.OptIn)]
	[Serializable]
	public class PocoFrameImage : PocoFrameItem, IFrameImage
	{
		/// <inheritdoc />
		private BitmapSource _imageBitmapSource;


		#region Overrides/Interfaces
		/// <inheritdoc />
		public BitmapSource ImageBitmapSource => _imageBitmapSource;

		/// <inheritdoc />
		public void EditorRequestedImageChange()
		{
			throw new NotImplementedException();
		}
		#endregion



		public static class Mocks
		{
			private static BitmapSource _sampleImage;

			public static PocoFrameImage LeftTop()
			{
				return Mocking.SetLeftTop(new PocoFrameImage
										{
											_imageBitmapSource = SampleImage()
										});
			}

			public static PocoFrameImage LeftBottom()
			{
				return Mocking.SetLeftBottom(new PocoFrameImage
											{
												_imageBitmapSource = SampleImage()
											});
			}

			public static PocoFrameImage RightTop()
			{
				return Mocking.SetRightTop(new PocoFrameImage
											{
												_imageBitmapSource = SampleImage()
											});
			}

			public static PocoFrameImage RightBottom()
			{
				return Mocking.SetRightBottom(new PocoFrameImage
											{
												_imageBitmapSource = SampleImage()
											});
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