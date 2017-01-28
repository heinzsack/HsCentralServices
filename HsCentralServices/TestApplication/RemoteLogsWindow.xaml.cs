// Copyright (c) 2016 All rights reserved Christian Sack
// <author>Christian Sack</author>
// <email>christian@sack.at</email>
// <website>christian.sack.at</website>
// <date>2017-01-26</date>

using System;
using System.Windows;
using CsWpfBase.Global;
using CsWpfBase.Global.remote.services.logging.components;
using CsWpfBase.Themes.Controls.Containers;






namespace TestApplication
{
	/// <summary>Interaction logic for RemoteLogsWindow.xaml</summary>
	public partial class RemoteLogsWindow : CsWindow
	{
		public RemoteLogsWindow()
		{
			InitializeComponent();
		}

		private void SendClicked(object sender, RoutedEventArgs e)
		{
			CsGlobal.Remote.Log.Send(Title.Value, Content.Value, (RemoteLog.Severitys) Severity.Value, DateTime.Now.AddMinutes(2));
		}
	}
}