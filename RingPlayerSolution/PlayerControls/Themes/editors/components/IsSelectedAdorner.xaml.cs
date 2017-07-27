// Copyright (c) 2016 All rights reserved Christian Sack
// <author>Christian Sack</author>
// <email>christian@sack.at</email>
// <website>christian.sack.at</website>
// <date>2017-02-05</date>

using System;
using System.Collections.Generic;
using System.Windows;
using System.Windows.Documents;
using CsWpfBase.csglobal;
using JetBrains.Annotations;






namespace PlayerControls.Themes.editors.components
{
	/// <summary>Interaction logic for IsSelectedAdorner.xaml</summary>
	internal partial class IsSelectedAdorner : ControlAdorner
	{
		private static Dictionary<AdornerLayer, IsSelectedAdorner> CurrentAdorners { get; } = new Dictionary<AdornerLayer, IsSelectedAdorner>();
		private AdornerLayer OwningLayer { get; }

		public static void Apply([NotNull] FrameworkElement target)
		{
			var layer = AdornerLayer.GetAdornerLayer(target);
			IsSelectedAdorner control;
			bool available = CurrentAdorners.TryGetValue(layer, out control);

			if (available && Equals(control.AdornedElement, target))
			{
				return;
			}

			if(available)
				CsGlobal.Wpf.Animation.Opacity(control, 0, new Duration(TimeSpan.FromMilliseconds(150)), null, () => control.OwningLayer.Remove(control));
			else
				CurrentAdorners.Add(layer, null);

			CurrentAdorners[layer] = new IsSelectedAdorner(layer, target);
		}
		public static void Clear([NotNull] FrameworkElement target)
		{
			var layer = AdornerLayer.GetAdornerLayer(target);

			IsSelectedAdorner control;
			if(!CurrentAdorners.TryGetValue(layer, out control))
				return;

			CsGlobal.Wpf.Animation.Opacity(control, 0, new Duration(TimeSpan.FromMilliseconds(150)), null, () => control.OwningLayer.Remove(control));
			CurrentAdorners.Remove(layer);
		}
		public IsSelectedAdorner(AdornerLayer layer, [NotNull] UIElement adornedElement) : base(adornedElement)
		{
			InitializeComponent();
			OwningLayer = layer;
			OwningLayer.Add(this);
			CsGlobal.Wpf.Animation.Opacity(this, 1, new Duration(TimeSpan.FromMilliseconds(150)));
		}
	}
}