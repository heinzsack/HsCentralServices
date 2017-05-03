﻿// Copyright (c) 2015-2017 All rights reserved Christian Sack
// <author>Christian Sack</author>
// <email>christian@sack.at</email>
// <website>christian.sack.at</website>
// <created>2017-02-06</creation-date>
// <modified>2017-04-29 14:26</modify-date>

using System;
using System.Linq;
using System.Windows;
using CsWpfBase.Global;
using PlayerControls.Interfaces.presentation;






namespace PlayerControls.Themes.windows
{
	/// <summary>Interaction logic for DuratedFramesPresenterWindow.xaml</summary>
	internal partial class FrameRingPresenterWindow
	{
		public FrameRingPresenterWindow(string title, IFrameRing ring)
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
			Presenter.Ring = ring;

			CsGlobal.Wpf.Storage.Window.Handle(this, $"{nameof(FrameRingPresenterWindow)}");
		}
	}
}