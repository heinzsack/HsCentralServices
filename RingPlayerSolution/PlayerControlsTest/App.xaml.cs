// Copyright (c) 2015-2017 All rights reserved Christian Sack
// <author>Christian Sack</author>
// <email>christian@sack.at</email>
// <website>christian.sack.at</website>
// <created>2017-01-26</creation-date>
// <modified>2017-05-03 17:05</modify-date>

using System;
using System.Collections.Generic;
using System.Windows;
using CsWpfBase.csglobal;
using CsWpfBase.env.extensions;
using PlayerControls.Themes;
using PlayerControls._sys.extensions;
using PlayerControls._sys.pocos.audio;
using PlayerControls._sys.pocos.presentation;
using PlayerControls._sys.pocos.presentation.frame;






namespace PlayerControlsTest
{
	/// <summary>Interaction logic for App.xaml</summary>
	public partial class App : Application
	{


		private void App_OnStartup(object sender, StartupEventArgs e)
		{
			CsGlobal.Install(CsGlobalFunctions.Persistency);
			PocoFrameImage.Mocks.HandleEvent();
			PocoAudioRingEntry.Mock.HandleEvent();
			PocoFrameVideo.Mocks.HandleEvent();

			var presentationRing = FrameRingPresenter.GetMock(new DateTime(2017, 1, 1, 0, 0, 0, 0), TimeSpan.FromMinutes(1)).ConvertTo_Json().ConvertFrom_Json<PocoFrameRing>();
			var audioRing = presentationRing.CreateGapFillingAudioRing(new List<Guid> {Guid.Empty}).ConvertTo_Json().SaveAs_Utf8String_OnDesktop_AndOpen("sample.json").ConvertFrom_Json<PocoAudioRing>();
			audioRing.Play();
			presentationRing.ShowDialog();

			Current.Shutdown();
		}
	}
}