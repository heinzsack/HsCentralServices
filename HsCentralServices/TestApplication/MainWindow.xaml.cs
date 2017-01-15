// Copyright (c) 2016 All rights reserved Christian Sack
// <author>Christian Sack</author>
// <email>christian@sack.at</email>
// <website>christian.sack.at</website>
// <date>2017-01-05</date>

using System;
using System.Diagnostics;
using System.IO;
using System.Windows;
using CsWpfBase.Global;
using CsWpfBase.Themes.Controls.Containers;
using CsWpfBase.Themes.Controls.Editors._baseControls;






namespace TestApplication
{
	/// <summary>Interaction logic for MainWindow.xaml</summary>
	public partial class MainWindow : CsWindow
	{
		public MainWindow()
		{
			CsGlobal.Install(GlobalFunctions.Storage);
			CsGlobal.InstallRemote("http://localhost:16412");
			CsGlobal.Remote.Event.Connect();
			CsGlobal.Remote.Event.Connected += Connected;

			InitializeComponent();
			FileSelector.ValuePath = new FileInfo(@"C:\Data\Personal\OneDrive\Bilder\Wallpaper\6.jpg");
			IdSelector.Value = "2cac40bb-36d1-4e75-8b07-c328d07e0f2d";
		}

		private void Connected()
		{
			CsGlobal.Remote.Event.Handle<int>("SimpleEvent", SimpleEvent);
			CsGlobal.Remote.Event.Handle<int>("SimpleEvent1", SimpleEvent);
			CsGlobal.Remote.Event.Handle<int>("SimpleEvent2", SimpleEvent);
			CsGlobal.Remote.Event.Handle<int>("SimpleEvent3", SimpleEvent);
		}

		private void SendEventClick(object sender, RoutedEventArgs e)
		{
			CsGlobal.Remote.Event.Raise("SimpleEvent", Process.GetCurrentProcess().Id);
		}

		private void SimpleEvent(int eventData)
		{
			CsGlobal.Message.Push(eventData);
		}

		private void DownloadClick(object sender, RoutedEventArgs e)
		{
			var filedownload = CsGlobal.Remote.FileRepository.FindOrDownloadAsync(Guid.Parse(IdSelector.Value));
			filedownload.ShowDialog();
		}

		private void UploadClick(object sender, RoutedEventArgs e)
		{
			var fileupload = CsGlobal.Remote.FileRepository.UploadAsync(FileSelector.ValuePath, null, null, "MyGroup1", DateTime.Now.AddSeconds(30));
			fileupload.ShowDialog();
			if (fileupload.IsSucceeded)
			IdSelector.Value = fileupload.Result[0].Id.ToString();
		}

		private ValidationResult IdSelector_OnValidation(object value)
		{
			Guid id;
			if (Guid.TryParse(value?.ToString() ?? "", out id))
				return ValidationResult.Ok;
			return ValidationResult.Error("not an id");
		}

		
	}
}