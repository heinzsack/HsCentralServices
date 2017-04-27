// Copyright (c) 2016 All rights reserved Christian Sack
// <author>Christian Sack</author>
// <email>christian@sack.at</email>
// <website>christian.sack.at</website>
// <date>2017-02-05</date>

using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Windows;
using System.Windows.Documents;
using System.Windows.Input;
using CsWpfBase.Global;
using CsWpfBase.Themes.Controls.glyphicon;
using JetBrains.Annotations;
using PlayerControls.Interfaces;
using PlayerControls.Interfaces.presentation.FrameItems;






namespace PlayerControls.Themes.editors.components
{
	/// <summary>Interaction logic for IsMouseOverAdorner.xaml</summary>
	internal partial class IsMouseOverAdorner : ControlAdorner
	{
		private static Dictionary<AdornerLayer, IsMouseOverAdorner> CurrentAdorners { get; } = new Dictionary<AdornerLayer, IsMouseOverAdorner>();

		public static void Apply([NotNull] FrameworkElement target)
		{
			var layer = AdornerLayer.GetAdornerLayer(target);
			IsMouseOverAdorner control;
			bool available = CurrentAdorners.TryGetValue(layer, out control);

			if (available && Equals(control.AdornedElement, target))
				return;

			if (available)
				CsGlobal.Wpf.Animation.Opacity(control, 0, new Duration(TimeSpan.FromMilliseconds(150)), null, () => control.OwningLayer.Remove(control));
			else
				CurrentAdorners.Add(layer, null);

			CurrentAdorners[layer] = new IsMouseOverAdorner(layer, target);
		}
		public static void Clear([NotNull] FrameworkElement target)
		{
			var layer = AdornerLayer.GetAdornerLayer(target);



			IsMouseOverAdorner control;
			if (!CurrentAdorners.TryGetValue(layer, out control))
				return;

			CsGlobal.Wpf.Animation.Opacity(control, 0, new Duration(TimeSpan.FromMilliseconds(150)), null, () => control.OwningLayer.Remove(control));
			CurrentAdorners.Remove(layer);
		}


		private AdornerLayer OwningLayer { get; }

		private IsMouseOverAdorner(AdornerLayer layer, [NotNull] FrameworkElement adornedElement) : base(adornedElement)
		{
			InitializeComponent();
			OwningLayer = layer;
			OwningLayer.Add(this);

			if (adornedElement.DataContext is IFrame)
				GlyphIcon.Icon = ((IFrame) adornedElement.DataContext).FrameHasFixedRatio ? GlyphIcons.G_Vector_Path_All : GlyphIcons.G_Vector_Path_Square;
			else if (adornedElement.DataContext is IFrameText)
				GlyphIcon.Icon = GlyphIcons.H_Font;
			else if (adornedElement.DataContext is IFrameImage)
				GlyphIcon.Icon = GlyphIcons.E_Image;
			else if (adornedElement.DataContext is IFrameVideo)
				GlyphIcon.Icon = GlyphIcons.E_Youtube;

			CsGlobal.Wpf.Animation.Opacity(this, 1, new Duration(TimeSpan.FromMilliseconds(150)));
		}
	}
}