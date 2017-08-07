// Copyright (c) 2015-2017 All rights reserved Christian Sack
// <author>Christian Sack</author>
// <email>christian@sack.at</email>
// <website>christian.sack.at</website>
// <created>2017-07-27</creation-date>
// <modified>2017-08-07 16:51</modify-date>

using System;
using System.Collections.ObjectModel;
using System.IO;
using System.Windows;
using System.Windows.Data;
using System.Windows.Media.Imaging;
using CsWpfBase.env.extensions;
using PlayerControls._sys.extensions;
using PlayerControls._sys.pocos.presentation.frame;






namespace PlayerControlsTest
{
	/// <summary>Interaction logic for SampleWindow.xaml</summary>
	public partial class SampleWindow : Window
	{


		#region DP Keys
		/// <summary>The <see cref="DependencyProperty" /> for the <see cref="Images" /> property.</summary>
		public static readonly DependencyProperty ImagesProperty = DependencyProperty.Register(nameof(Images), typeof(ObservableCollection<Imager>), typeof(SampleWindow), new FrameworkPropertyMetadata
		{
			BindsTwoWayByDefault = true,
			//PropertyChangedCallback = (o, args) => ((SampleWindow)o).ImagesDpChanged((ObservableCollection<Imager>)args.OldValue, (ObservableCollection<Imager>)args.NewValue),
			DefaultValue = default(ObservableCollection<Imager>),
			DefaultUpdateSourceTrigger = UpdateSourceTrigger.PropertyChanged,
		});
		#endregion


		public SampleWindow()
		{
			InitializeComponent();
			this.Loaded += OnLoaded;
			new Imager().Image.SaveAs_PngFile(new FileInfo("test.png").In_Desktop_Directory());
		}

		private void OnLoaded(object sender, RoutedEventArgs routedEventArgs)
		{
			Images = new ObservableCollection<Imager> {new Imager(), new Imager(), new Imager(), new Imager()};
		}

		/// <summary>Description</summary>
		public ObservableCollection<Imager> Images
		{
			get => (ObservableCollection<Imager>) GetValue(ImagesProperty);
			set => SetValue(ImagesProperty, value);
		}
	}



	public class Imager
	{
		public Imager()
		{

		}

		public BitmapSource Image => PocoFrame.Mock.FullScreen_ImageAndText().ConvertTo_RenderedImage().Result;
	}
}