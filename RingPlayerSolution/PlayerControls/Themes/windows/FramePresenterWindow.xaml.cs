// Copyright (c) 2016 All rights reserved Christian Sack
// <author>Christian Sack</author>
// <email>christian@sack.at</email>
// <website>christian.sack.at</website>
// <date>2017-01-28</date>

using System;
using System.Linq;
using System.Windows;
using CsWpfBase.Global;
using CsWpfBase.Themes.Controls.Containers;
using PlayerControls.Interfaces;






namespace PlayerControls.Themes.windows
{
	/// <summary>Interaction logic for FramePresenterWindow.xaml</summary>
	internal partial class FramePresenterWindow : CsWindow
	{
		public FramePresenterWindow(string title, IFrame frame, bool isDiagnostic)
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
			Presenter.Item = frame;
			Presenter.IsDiagnostic = isDiagnostic;

			CsGlobal.Wpf.Storage.Window.Handle(this, $"{nameof(FramePresenterWindow)}");

		}
	}
}