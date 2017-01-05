// Copyright (c) 2016 All rights reserved Christian Sack
// <author>Christian Sack</author>
// <email>christian@sack.at</email>
// <website>christian.sack.at</website>
// <date>2017-01-05</date>

using System;
using System.IO;
using System.Windows;
using CsWpfBase.Global;
using CsWpfBase.Remote;
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
			CsRemote.InstallClient("http://localhost:16411", "LocalServerTest");

			InitializeComponent();
			FileSelector.ValuePath = new FileInfo(@"C:\Data\Personal\OneDrive\Bilder\Wallpaper\6.jpg");
			IdSelector.Value = "2cac40bb-36d1-4e75-8b07-c328d07e0f2d";
		}

		private void DownloadClick(object sender, RoutedEventArgs e)
		{
			var filedownload = CsRemote.Client.FileRepository.FindOrDownloadAsync(Guid.Parse(IdSelector.Value));
			filedownload.ShowDialog();
		}

		private void UploadClick(object sender, RoutedEventArgs e)
		{
			var fileupload = CsRemote.Client.FileRepository.UploadAsync(FileSelector.ValuePath);
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

		//	{
		//	Rfr.Delete(Guid.Parse(IdSelector.Value)).ContinueWith(t =>
		//{


		//private void DeleteClick(object sender, RoutedEventArgs e)
		//		if (t.Exception != null)
		//		{
		//			CsGlobal.Message.Push(t.Exception.MostInner());
		//			return;
		//		}

		//		CsGlobal.Message.Push($"Succeeded with {IdSelector.Value}");
		//	}, TaskScheduler.FromCurrentSynchronizationContext());
		//}
	}
}