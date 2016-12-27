// Copyright (c) 2016 All rights reserved Christian Sack
// <author>Christian Sack</author>
// <email>christian@sack.at</email>
// <website>christian.sack.at</website>
// <date>2016-12-22</date>

using System;
using System.IO;
using System.Windows;
using CsWpfBase.Ev.Public.Extensions;
using CsWpfBase.Global;
using CsWpfBase.Global.transmission.remoteFileRepository.client;
using CsWpfBase.Global.transmission.remoteFileRepository.client.actions;






namespace TestApplication
{
	/// <summary>Interaction logic for MainWindow.xaml</summary>
	public partial class MainWindow : Window
	{
		private RemoteFileRepository Rfr { get; }
		private Guid latestFile = Guid.Parse("fa2097e8-0626-48c5-aa31-b8b2722cd211");
		public MainWindow()
		{
			CsGlobal.Install(GlobalFunctions.Storage);
			Rfr = new RemoteFileRepository("http://localhost:16411/FileRepo/");

			InitializeComponent();

		}

		private void DownloadClick(object sender, RoutedEventArgs e)
		{
			var downloadTask = Rfr.Get(new GetCommand(latestFile));
			downloadTask.ShowDialog();
		}

		private void UploadClick(object sender, RoutedEventArgs e)
		{
			var saveCommand = new SaveCommand(new FileInfo("test.txt").In_Desktop_Directory());
			var upload = Rfr.Save(saveCommand);
			latestFile = upload.Result[0].Result.Id;
		}
	}
}