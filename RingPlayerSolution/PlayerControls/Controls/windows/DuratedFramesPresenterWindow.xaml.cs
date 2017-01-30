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






namespace PlayerControls.Controls.windows
{
	/// <summary>Interaction logic for DuratedFramesPresenterWindow.xaml</summary>
	internal partial class DuratedFramesPresenterWindow : CsWindow
	{
		public DuratedFramesPresenterWindow(string title, IDuratedFrame[] itemsSource)
		{
			Owner = Application.Current.Windows.OfType<Window>().FirstOrDefault(x => !Equals(x, this) && x.IsFocused);
			if(Owner != null)
			{
				WindowStartupLocation = WindowStartupLocation.CenterOwner;
				Width = Owner.Width * 0.95;
				Height = Owner.Height * 0.95;
			}
			InitializeComponent();
			Title = title;
			Presenter.ItemsSource = itemsSource;

			CsGlobal.Wpf.Storage.Window.Handle(this, $"{nameof(DuratedFramesPresenterWindow)}");
		}
	}
}