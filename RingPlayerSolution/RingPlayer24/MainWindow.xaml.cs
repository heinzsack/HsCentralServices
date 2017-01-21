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
			CsGlobal.InstallRemote("service.wpmedia.at", "<RSAKeyValue><Modulus>7bTXJULjf3ELHOv/57LyGUTBpgQ7CucbdSXusgy+270FPbK0Iboqkqrhs4rbeKkH6AWA6BwXGqUqAwwVNKHPEtXTpLe9GKM41eZOJyhU7QCw0X8BAQXLbTQbc+QGFn/J/t6wlh7cgrYgqe/3Q9u7yW9+j16Q8Uj4OG4N20fsqX0=</Modulus><Exponent>AQAB</Exponent></RSAKeyValue>"); //TODO
			CsGlobal.Remote.EventHub.Connect();

			InitializeComponent();
		}

		private void CloseClicked(object sender, RoutedEventArgs e)
		{
			CsGlobal.App.Exit();
		}
	}
}