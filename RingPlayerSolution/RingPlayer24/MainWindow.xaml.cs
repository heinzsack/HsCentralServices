// Copyright (c) 2016 All rights reserved Christian Sack
// <author>Christian Sack</author>
// <email>christian@sack.at</email>
// <website>christian.sack.at</website>
// <date>2017-01-14</date>

using System;
using System.IO;
using System.Windows;
using CsWpfBase.Ev.Public.Extensions;
using CsWpfBase.Global;
using PlayerControls.Themes;
using PlayerControls._sys.extensions;
using PlayerControls._sys.pocos.audio;






namespace RingPlayer24
{
	/// <summary>Interaction logic for MainWindow.xaml</summary>
	public partial class MainWindow : Window
	{
		public MainWindow()
		{
			CsGlobal.Install(GlobalFunctions.Storage);
			PocoAudioRing.Mock.Get(new DateTime(2017, 1, 1, 0, 0, 0, 0), TimeSpan.FromMinutes(1)).Play();
			FrameRingPresenter.GetMock(new DateTime(2017, 1,1,0,0,0,0), TimeSpan.FromMinutes(1) ).ShowDialog();
			Application.Current.Shutdown();


			var frame = FramePresenter.GetMock();
			frame.ConvertTo_Json().SaveAs_Utf8String(new FileInfo("Test.json").In_Desktop_Directory());
			frame.ShowEditorDialog();

			InitializeComponent();
		}

		private void CloseClicked(object sender, RoutedEventArgs e)
		{
			CsGlobal.App.Exit();
		}
	}
}