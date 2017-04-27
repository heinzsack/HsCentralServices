// Copyright (c) 2016 All rights reserved Christian Sack
// <author>Christian Sack</author>
// <email>christian@sack.at</email>
// <website>christian.sack.at</website>
// <date>2017-01-28</date>

using System;
using System.IO;
using System.Windows;
using System.Windows.Data;
using CsWpfBase.Ev.Public.Extensions;
using CsWpfBase.Global;
using CsWpfBase.Themes.Controls.Containers;
using CsWpfBase.Themes.Controls.Editors._baseControls;
using CsWpfBase._todo;
using PlayerControls.Extensions;
using PlayerControls.Themes;
using PlayerControls.Themes.editors;






namespace TestApplication
{
	/// <summary>Interaction logic for MainWindow.xaml</summary>
	public partial class MainWindow : CsWindow
	{
		public MainWindow()
		{
			CsGlobal.Install(GlobalFunctions.Storage | GlobalFunctions.AppData | GlobalFunctions.ConfigFile | GlobalFunctions.GermanThreadCulture);
			//http://localhost:16412/
			CsGlobal.InstallRemote("service.wpmedia.at", "<RSAKeyValue><Modulus>7bTXJULjf3ELHOv/57LyGUTBpgQ7CucbdSXusgy+270FPbK0Iboqkqrhs4rbeKkH6AWA6BwXGqUqAwwVNKHPEtXTpLe9GKM41eZOJyhU7QCw0X8BAQXLbTQbc+QGFn/J/t6wlh7cgrYgqe/3Q9u7yW9+j16Q8Uj4OG4N20fsqX0=</Modulus><Exponent>AQAB</Exponent></RSAKeyValue>");

			InitializeComponent();
			FileSelector.ValuePath = new FileInfo(@"x.mkv").In_Desktop_Directory();
			IdSelector.Value = "0A2D546F-B976-4566-8BAD-E910B3DF96E3";

			var frame = FramePresenter.GetMock();
			new FrameEditor { Item = frame }.ShowDialog("Frame Edit");


			CsGlobal.App.Exit();


			////var applicationUpdate = ApplicationUpdate.New(new DirectoryInfo(@"C:\_Data\DEV\Github\Hs\SharedComponents\HsCentralServices\TestApplication\bin\Debug"));
			//var updateFile = new FileInfo("AppUpdate.upd").In_Desktop_Directory();
			////applicationUpdate.Save(updateFile);

			//var update = ApplicationUpdate.Load(updateFile);
			//update.Execute();
		}


		private void DownloadClick(object sender, RoutedEventArgs e)
		{
			var filedownload = CsGlobal.Remote.FileRepository.FindOrDownloadAsync(Guid.Parse(IdSelector.Value));
			filedownload.ShowDialog();
		}

		private void UploadClick(object sender, RoutedEventArgs e)
		{
			var fileupload = CsGlobal.Remote.FileRepository.UploadAsync(FileSelector.ValuePath, null, null, "MyGroup1", DateTime.Now.AddMinutes(10));
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


		private void OpenEventHubTester(object sender, RoutedEventArgs e)
		{
			new EventHubWindow().ShowDialog();
		}

		private void OpenLoggingTester(object sender, RoutedEventArgs e)
		{
			new RemoteLogsWindow().Show();
		}
	}
}