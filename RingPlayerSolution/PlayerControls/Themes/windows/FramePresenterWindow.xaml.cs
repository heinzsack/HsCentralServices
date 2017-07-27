// Copyright (c) 2015-2017 All rights reserved Christian Sack
// <author>Christian Sack</author>
// <email>christian@sack.at</email>
// <website>christian.sack.at</website>
// <created>2017-02-06</creation-date>
// <modified>2017-04-27 18:26</modify-date>

using System;
using System.Linq;
using System.Windows;
using CsWpfBase.csglobal;
using PlayerControls.Interfaces.presentation.FrameItems;






namespace PlayerControls.Themes.windows
{
	/// <summary>Interaction logic for FramePresenterWindow.xaml</summary>
	internal partial class FramePresenterWindow
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

			CsGlobal.Local.Persistence.Ui.Store(this, $"{nameof(FramePresenterWindow)}");

		}
	}
}