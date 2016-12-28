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
using CsWpfBase.Themes.Controls.Containers;
using CsWpfBase.Themes.Controls.Editors._baseControls;






namespace TestApplication
{
	/// <summary>Interaction logic for MainWindow.xaml</summary>
	public partial class MainWindow : CsWindow
	{
		private RemoteFileRepository Rfr { get; }
		public MainWindow()
		{
			CsGlobal.Install(GlobalFunctions.Storage);
			Rfr = new RemoteFileRepository("http://www.internettv.citynews.at/TempApp/FileRepo");

			InitializeComponent();
			FileSelector.ValuePath = new FileInfo(@"\\sack\_Videos\Filme\8.Mile.2002.German.DL.1080p.BluRay.x264-DEFUSED\dfd-8mile-1080p.mkv");
			IdSelector.Value = "2cac40bb-36d1-4e75-8b07-c328d07e0f2d";
		}

		private void DownloadClick(object sender, RoutedEventArgs e)
		{
			var downloadTask = Rfr.Get(new GetCommand(Guid.Parse(IdSelector.Value)));
			downloadTask.ShowDialog();
		}

		private void UploadClick(object sender, RoutedEventArgs e)
		{
			
			var saveCommand = new SaveCommand(FileSelector.ValuePath);
			var uploadTask = Rfr.Save(saveCommand);
			uploadTask.ShowDialog();

			IdSelector.Value = saveCommand?.Result?.Id.ToString();
		}

		private ValidationResult IdSelector_OnValidation(object value)
		{
			Guid id;
			if (Guid.TryParse(value?.ToString()??"", out id))
				return ValidationResult.Ok;
			return ValidationResult.Error("not an id");
		}
	}
}