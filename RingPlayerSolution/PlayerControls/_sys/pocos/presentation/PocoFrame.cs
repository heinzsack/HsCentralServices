// Copyright (c) 2015-2017 All rights reserved Christian Sack
// <author>Christian Sack</author>
// <email>christian@sack.at</email>
// <website>christian.sack.at</website>
// <created>2017-04-27</creation-date>
// <modified>2017-04-28 11:57</modify-date>

using System;
using System.Collections;
using System.Collections.ObjectModel;
using System.Windows.Data;
using CsWpfBase.Ev.Public.Extensions;
using Newtonsoft.Json;
using PlayerControls.Interfaces.presentation.FrameItems;
using PlayerControls.Interfaces.presentation._base;
using PlayerControls._sys.extensions;






namespace PlayerControls._sys.pocos.presentation
{
	[JsonObject(MemberSerialization.OptIn)]
	[Serializable]
	public class PocoFrame : PocoFrameItem, IFrame
	{
		[field: NonSerialized] [JsonIgnore] private IEnumerable _frameChildren;
		private bool _frameHasFixedRatio;
		private double _frameRatioX;
		private double _frameRatioY;
		private ObservableCollection<PocoFrame> _frames;
		[field: NonSerialized] [JsonIgnore] private IEnumerable _frameTransitions;
		private ObservableCollection<PocoFrameImage> _images;
		private ObservableCollection<PocoFrameText> _texts;
		private ObservableCollection<PocoFrameVideo> _videos;

		[JsonConstructor]
		public PocoFrame()
		{

		}


		#region Overrides/Interfaces
		/// <inheritdoc />
		[JsonProperty("HasFixedRatio")]
		public bool FrameHasFixedRatio
		{
			get => _frameHasFixedRatio;
			set => SetProperty(ref _frameHasFixedRatio, value);
		}
		/// <inheritdoc />
		[JsonProperty("RatioX")]
		public double FrameRatioX
		{
			get => _frameRatioX;
			set => SetProperty(ref _frameRatioX, value);
		}
		/// <inheritdoc />
		[JsonProperty("RatioY")]
		public double FrameRatioY
		{
			get => _frameRatioY;
			set => SetProperty(ref _frameRatioY, value);
		}
		/// <inheritdoc />
		[JsonIgnore]
		public IEnumerable FrameChildren
		{
			get
			{
				if (_frameChildren != null) return _frameChildren;

				_frameChildren = new CompositeCollection
								{
									new CollectionContainer {Collection = Frames},
									new CollectionContainer {Collection = Texts},
									new CollectionContainer {Collection = Images},
									new CollectionContainer {Collection = Videos}
								};
				return _frameChildren;
			}
		}
		/// <inheritdoc />
		[JsonIgnore]
		public IEnumerable FrameTransitions => _frameTransitions;




		/// <inheritdoc />
		public IFrameText EditorRequestedNewText()
		{
			return new PocoFrameText();
		}

		/// <inheritdoc />
		public IFrameImage EditorRequestedNewImage()
		{
			return new PocoFrameImage();
		}

		/// <inheritdoc />
		public IFrameVideo EditorRequestedNewVideo()
		{
			return new PocoFrameVideo();
		}

		/// <inheritdoc />
		public IFrame EditorRequestedNewFrame()
		{
			return new PocoFrame();
		}

		/// <inheritdoc />
		public void EditorRequestedRemoveChild(IFrameItem child)
		{
			if (child is PocoFrameText)
				Texts.Remove((PocoFrameText) child);
			else if (child is PocoFrameImage)
				Images.Remove((PocoFrameImage) child);
			else if (child is PocoFrameVideo)
				Videos.Remove((PocoFrameVideo) child);
			else if (child is PocoFrame)
				Frames.Remove((PocoFrame) child);
		}
		#endregion


		///<summary>Contained Images</summary>
		[JsonProperty]
		public ObservableCollection<PocoFrameImage> Images => _images ?? (_images = new ObservableCollection<PocoFrameImage>());
		///<summary>Contained videos</summary>
		[JsonProperty]
		public ObservableCollection<PocoFrameVideo> Videos => _videos ?? (_videos = new ObservableCollection<PocoFrameVideo>());
		///<summary>Contained texts</summary>
		[JsonProperty]
		public ObservableCollection<PocoFrameText> Texts => _texts ?? (_texts = new ObservableCollection<PocoFrameText>());
		///<summary>Contained texts</summary>
		[JsonProperty]
		public ObservableCollection<PocoFrame> Frames => _frames ?? (_frames = new ObservableCollection<PocoFrame>());


		/// <summary>
		///     If the <paramref name="item" /> is a poco object it will directly be added. Otherwise it will be converted to a poco
		///     object.
		/// </summary>
		public void AddChild(IFrameItem item)
		{
			if (item is IFrameText)
				Texts.Add(item as PocoFrameText ?? ((IFrameText)item).ToPoco());
			else if (item is IFrameImage)
				Images.Add(item as PocoFrameImage ?? ((IFrameImage)item).ToPoco());
			else if (item is IFrameVideo)
				Videos.Add(item as PocoFrameVideo ?? ((IFrameVideo)item).ToPoco());
			else if (item is IFrame)
				Frames.Add(item as PocoFrame ?? ((IFrame)item).ToPoco());
		}

		public bool ShouldSerializeImages()
		{
			return _images != null && _images.Count != 0;
		}

		public bool ShouldSerializeVideos()
		{
			return _videos != null && _videos.Count != 0;
		}

		public bool ShouldSerializeTexts()
		{
			return _texts != null && _texts.Count != 0;
		}

		public bool ShouldSerializeFrames()
		{
			return _frames != null && _frames.Count != 0;
		}



		public static class Mock
		{
			public static PocoFrame FullScreenPrefilled(string specialText = null)
			{
				var fullScreen = FullScreen();
				fullScreen.AddChild(PocoFrameImage.Mocks.LeftTop());
				fullScreen.AddChild(PocoFrameText.Mocks.LeftBottom(specialText));
				fullScreen.AddChild(PocoFrameText.Mocks.RightTop());
				fullScreen.AddChild(PocoFrameImage.Mocks.RightBottom());
				return fullScreen;
			}

			public static PocoFrame FullScreen()
			{
				return Mocking.SetRandomBackground(new PocoFrame() {FrameHasFixedRatio = true, FrameRatioX = ((byte) 10).Random(12, 16), FrameRatioY = 9});
			}

			public static PocoFrame LeftTop()
			{
				return Mocking.SetRandomBackground(Mocking.SetLeftTop(new PocoFrame()));
			}

			public static PocoFrame LeftBottom()
			{
				return Mocking.SetRandomBackground(Mocking.SetLeftBottom(new PocoFrame()));
			}

			public static PocoFrame RightTop()
			{
				return Mocking.SetRandomBackground(Mocking.SetRightTop(new PocoFrame()));
			}

			public static PocoFrame RightBottom()
			{
				return Mocking.SetRandomBackground(Mocking.SetRightBottom(new PocoFrame()));
			}
		}

	}




}