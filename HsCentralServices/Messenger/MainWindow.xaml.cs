// Copyright (c) 2016 All rights reserved Christian Sack
// <author>Christian Sack</author>
// <email>christian@sack.at</email>
// <website>christian.sack.at</website>
// <date>2017-01-15</date>

using System;
using System.Windows;
using CsWpfBase.Global;
using CsWpfBase.Themes.Controls.Containers;






namespace Messenger
{
	/// <summary>Interaction logic for MainWindow.xaml</summary>
	public partial class MainWindow : CsWindow
	{
		public MainWindow()
		{
			CsGlobal.Install(GlobalFunctions.Storage);
			CsGlobal.InstallRemote("service.wpmedia.at");
			CsGlobal.Remote.Event.Connect();
			CsGlobal.Remote.Event.Connected += OnConnected;
			InitializeComponent();
		}

		private void OnConnected()
		{
			CsGlobal.Remote.Event.Handle<string>(nameof(MessageReceived), MessageReceived);
		}

		private void MessageReceived(string eventData)
		{
			MessageInput.Value = eventData;
		}

		private void SendClicked(object sender, RoutedEventArgs e)
		{
			CsGlobal.Remote.Event.Raise(nameof(MessageReceived), MessageInput.Value);
		}
	}
}