// Copyright (c) 2015-2017 All rights reserved Christian Sack
// <author>Christian Sack</author>
// <email>christian@sack.at</email>
// <website>christian.sack.at</website>
// <created>2017-04-26</creation-date>
// <modified>2017-04-26 21:48</modify-date>

using System;
using System.Windows;
using System.Windows.Media;
using CsWpfBase.Ev.Objects;
using CsWpfBase.Ev.Public.Extensions;
using Newtonsoft.Json;
using PlayerControls.Interfaces.presentation._base;






namespace PlayerControls._sys.pocos.presentation.frame
{
	[JsonObject(MemberSerialization.OptIn)]
	[Serializable]
	public abstract class PocoFrameItem : Base, IFrameItem
	{
		/// <inheritdoc />
		private Color _frameItemBackground = Colors.Transparent;
		/// <inheritdoc />
		private Color _frameItemBorderColor = Colors.Transparent;
		/// <inheritdoc />
		private Thickness _frameItemBorderThickness;
		/// <inheritdoc />
		private Thickness _frameItemPadding;
		/// <inheritdoc />
		private Thickness _frameItemRelativePosition;
		/// <inheritdoc />
		private double _frameItemRotation;
		/// <inheritdoc />
		private int _frameItemZIndex ;


		#region Overrides/Interfaces
		/// <inheritdoc />
		[JsonProperty("Position")]
		public Thickness FrameItemRelativePosition
		{
			get => _frameItemRelativePosition;
			set => SetProperty(ref _frameItemRelativePosition, value);
		}
		/// <inheritdoc />
		[JsonProperty("Background", DefaultValueHandling = DefaultValueHandling.Ignore)]
		public Color FrameItemBackground
		{
			get => _frameItemBackground;
			set => SetProperty(ref _frameItemBackground, value);
		}
		/// <inheritdoc />
		[JsonProperty("BorderColor",DefaultValueHandling = DefaultValueHandling.Ignore)]
		public Color FrameItemBorderColor
		{
			get => _frameItemBorderColor;
			set => SetProperty(ref _frameItemBorderColor, value);
		}
		/// <inheritdoc />
		[JsonProperty("BorderThickness")]
		public Thickness FrameItemBorderThickness
		{
			get => _frameItemBorderThickness;
			set => SetProperty(ref _frameItemBorderThickness, value);
		}
		/// <inheritdoc />
		[JsonProperty("Padding")]
		public Thickness FrameItemPadding
		{
			get => _frameItemPadding;
			set => SetProperty(ref _frameItemPadding, value);
		}
		/// <inheritdoc />
		[JsonProperty("Rotation")]
		public double FrameItemRotation
		{
			get => _frameItemRotation;
			set => SetProperty(ref _frameItemRotation, value);
		}
		/// <inheritdoc />
		[JsonProperty("ZIndex")]
		public int FrameItemZIndex
		{
			get => _frameItemZIndex;
			set => SetProperty(ref _frameItemZIndex, value);
		}
		#endregion


		public bool ShouldSerializeFrameItemBackground()
		{
			return _frameItemBackground != Colors.Transparent;
		}
		public bool ShouldSerializeFrameItemBorderColor()
		{
			return _frameItemBorderColor != Colors.Transparent;
		}


		protected static class Mocking
		{
			public static TItemType SetLeftTop<TItemType>(TItemType item) where TItemType:PocoFrameItem
			{
				item.FrameItemRelativePosition = new Thickness(2, 2, 52, 52);
				return item;
			}

			public static TItemType SetLeftBottom<TItemType>(TItemType item) where TItemType : PocoFrameItem
			{
				item.FrameItemRelativePosition = new Thickness(2, 52, 52, 2);
				return item;
			}

			public static TItemType SetRightTop<TItemType>(TItemType item) where TItemType : PocoFrameItem
			{
				item.FrameItemRelativePosition = new Thickness(52, 2, 2, 52);
				return item;
			}

			public static TItemType SetRightBottom<TItemType>(TItemType item) where TItemType : PocoFrameItem
			{
				item.FrameItemRelativePosition = new Thickness(52, 52, 2, 2);
				return item;
			}

			public static TItemType SetRandomBackground<TItemType>(TItemType item) where TItemType : PocoFrameItem
			{
				byte a = 0;
				item.FrameItemBackground = Color.FromRgb(a.Random(), a.Random(), a.Random());
				return item;
			}
		}
	}
}