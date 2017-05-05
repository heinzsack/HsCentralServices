using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using CsWpfBase.Ev.Objects;
using Newtonsoft.Json;
using PlayerControls._sys.pocos.presentation.frame;






namespace PlayerControlsTest
{
	/// <summary>
	/// Interaction logic for SampleWindow.xaml
	/// </summary>
	public partial class SampleWindow : Window
	{
		public SampleWindow()
		{
			InitializeComponent();
		}
	}
	[JsonObject(MemberSerialization.OptOut)]
	public class ButtonBase : Base
	{
		public PocoFrame Content { get; set; }
	}



	[JsonObject(MemberSerialization.OptOut)]
	public class UrlButton : ButtonBase
	{
		public string Url { get; set; }
	}

	[JsonObject(MemberSerialization.OptOut)]
	public class OpenFrameButton : ButtonBase
	{
		public PocoFrame FrameToOpen { get; set; }
	}

	[JsonObject(MemberSerialization.OptOut)]
	public class NavigationButton : ButtonBase
	{
		public List<ButtonBase> SubButtons { get; set; }
	}
}
