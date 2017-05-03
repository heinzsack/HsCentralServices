// Copyright (c) 2015-2017 All rights reserved Christian Sack
// <author>Christian Sack</author>
// <email>christian@sack.at</email>
// <website>christian.sack.at</website>
// <created>2017-04-27</creation-date>
// <modified>2017-04-28 15:35</modify-date>

using System;
using System.Linq;
using System.Windows;
using System.Windows.Media;
using CsWpfBase.Ev.Public.Extensions;
using Newtonsoft.Json;
using PlayerControls.Interfaces.presentation.FrameItems;






namespace PlayerControls._sys.pocos.presentation.frame
{
	[JsonObject(MemberSerialization.OptIn)]
	[Serializable]
	public class PocoFrameText : PocoFrameItem, IFrameText
	{
		/// <inheritdoc />
		private FontFamily _frameItemFontFamily;
		/// <inheritdoc />
		private FontStyle _frameItemFontStyle;
		/// <inheritdoc />
		private FontWeight _frameItemFontWeight;
		/// <inheritdoc />
		private Color _frameItemForeground = Colors.Black;
		/// <inheritdoc />
		private string _frameItemText;
		/// <inheritdoc />
		[JsonProperty("FontFamily")] private string _serializedFontFamily;


		#region Overrides/Interfaces
		/// <inheritdoc />
		[JsonProperty("Text")]
		public string FrameItemText
		{
			get => _frameItemText;
			set => SetProperty(ref _frameItemText, value);
		}
		/// <inheritdoc />
		[JsonProperty("Foreground", DefaultValueHandling = DefaultValueHandling.Ignore)]
		public Color FrameItemForeground
		{
			get => _frameItemForeground;
			set => SetProperty(ref _frameItemForeground, value);
		}
		/// <inheritdoc />
		[JsonIgnore]
		public FontFamily FrameItemFontFamily
		{
			get => _frameItemFontFamily ?? (_frameItemFontFamily = _serializedFontFamily.IsNullOrEmpty() ? null : new FontFamily(_serializedFontFamily));
			set
			{
				if (!SetProperty(ref _frameItemFontFamily, value)) return;
				_serializedFontFamily = value?.FamilyNames.First().Value;
			}
		}
		/// <inheritdoc />
		[JsonProperty("FontWeight")]
		public FontWeight FrameItemFontWeight
		{
			get => _frameItemFontWeight;
			set => SetProperty(ref _frameItemFontWeight, value);
		}
		/// <inheritdoc />
		[JsonProperty("FontStyle")]
		public FontStyle FrameItemFontStyle
		{
			get => _frameItemFontStyle;
			set => SetProperty(ref _frameItemFontStyle, value);
		}
		#endregion


		public bool ShouldSerializeFrameItemForeground()
		{
			return _frameItemForeground != Colors.Black;
		}



		public static class Mocks
		{
			public static IFrameText LeftTop(string text = null)
			{
				return Mocking.SetLeftTop(new PocoFrameText
										{
											FrameItemForeground = Colors.Black,
											FrameItemText = text ?? "LINKS OBEN".AppendRandomText()
										});
			}

			public static IFrameText LeftBottom(string text = null)
			{
				return Mocking.SetLeftBottom(new PocoFrameText
											{
												FrameItemForeground = Colors.Black,
												FrameItemText = text ?? "LINKS UNTEN".AppendRandomText()
											});
			}

			public static IFrameText RightTop(string text = null)
			{
				return Mocking.SetRightTop(new PocoFrameText
											{
												FrameItemForeground = Colors.Black,
												FrameItemText = text ?? "RECHTS OBEN".AppendRandomText()
											});
			}

			public static IFrameText RightBottom(string text = null)
			{
				return Mocking.SetRightBottom(new PocoFrameText
											{
												FrameItemForeground = Colors.Black,
												FrameItemText = text ?? "RECHTS UNTEN".AppendRandomText()
											});
			}
		}
	}
}