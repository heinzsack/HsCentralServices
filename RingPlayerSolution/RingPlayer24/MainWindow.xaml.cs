// Copyright (c) 2016 All rights reserved Christian Sack
// <author>Christian Sack</author>
// <email>christian@sack.at</email>
// <website>christian.sack.at</website>
// <date>2017-01-14</date>

using System;
using System.Windows;
using CsWpfBase.Global;






namespace RingPlayer24
{
	/// <summary>Interaction logic for MainWindow.xaml</summary>
	public partial class MainWindow : Window
	{
		public MainWindow()
		{
			CsGlobal.Install(GlobalFunctions.Storage | GlobalFunctions.AppData);
			CsGlobal.InstallRemote("http://localhost:16412/"); //TODO
			CsGlobal.Remote.Event.Connect();

			InitializeComponent();
		}

		private void CloseClicked(object sender, RoutedEventArgs e)
		{
			CsGlobal.App.Exit();
		}
	}
}