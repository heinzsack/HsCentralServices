// Copyright (c) 2015-2017 All rights reserved Christian Sack
// <author>Christian Sack</author>
// <email>christian@sack.at</email>
// <website>christian.sack.at</website>
// <created>2017-02-06</creation-date>
// <modified>2017-04-27 18:25</modify-date>

using System;
using System.Linq;
using System.Windows;
using CsWpfBase.Global;
using PlayerControls.Interfaces.presentation;
using PlayerControls.Interfaces.ringEngine;






namespace PlayerControls.Themes.windows
{
	/// <summary>Interaction logic for DuratedFramesPresenterWindow.xaml</summary>
	internal partial class RingFramePresenterWindow
	{
		public RingFramePresenterWindow(string title, IRing<IFrameRingEntry> itemsSource)
		{
			Owner = Application.Current.Windows.OfType<Window>().FirstOrDefault(x => !Equals(x, this) && x.IsFocused);
			if (Owner != null)
			{
				WindowStartupLocation = WindowStartupLocation.CenterOwner;
				Width = Owner.Width * 0.95;
				Height = Owner.Height * 0.95;
			}
			InitializeComponent();
			Title = title;
			Presenter.Ring = itemsSource;

			CsGlobal.Wpf.Storage.Window.Handle(this, $"{nameof(RingFramePresenterWindow)}");
		}
	}
}