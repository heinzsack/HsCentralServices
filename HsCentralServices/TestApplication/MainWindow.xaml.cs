// Copyright (c) 2016 All rights reserved Christian Sack
// <author>Christian Sack</author>
// <email>christian@sack.at</email>
// <website>christian.sack.at</website>
// <date>2016-12-22</date>

using System;
using System.IO;
using System.Net;
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
		private Guid _latestFile = Guid.Parse("fa2097e8-0626-48c5-aa31-b8b2722cd211");
		public MainWindow()
		{
			CsGlobal.Install(GlobalFunctions.Storage);
			Rfr = new RemoteFileRepository("http://localhost:16411/FileRepo/");

			InitializeComponent();

		}

		private void DownloadClick(object sender, RoutedEventArgs e)
		{
			var downloadTask = Rfr.Get(new GetCommand(_latestFile));
			downloadTask.ShowDialog();
		}

		private void UploadClick(object sender, RoutedEventArgs e)
		{
			var saveCommand = new SaveCommand(new FileInfo(@"\\sack\_Videos\Serien\Better call Soul\BCS S01 E04.mp4"));
			var upload = Rfr.Save(saveCommand);
			upload.ContinueWith(t =>
			{
				if (t.Exception != null && t.Exception.MostInner() is WebException)
				{
					var webResponse = ((WebException)t.Exception.MostInner()).Response;
					var convertToUtf8String = webResponse.GetResponseStream().SafeRead(webResponse.ContentLength).ConvertTo_Utf8String();
					Console.WriteLine(convertToUtf8String);
				}
				else
				{
					_latestFile = saveCommand.Result.Id;
				}
			});
		}
	}
}