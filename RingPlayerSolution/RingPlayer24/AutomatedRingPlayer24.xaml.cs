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
using System.Windows.Navigation;
using System.Windows.Shapes;
using CsWpfBase.Global;

namespace RingPlayer24
	{
	/// <summary>
	/// Interaction logic for AutomatedRingPlayer24.xaml
	/// </summary>
	public partial class AutomatedRingPlayer24 : UserControl
		{


		public event Action<Object, String, String, Object> ReConfigurationRequired;
		public AutomatedRingPlayer24()
			{
			InitializeComponent();
			}

		private void CloseClicked(object sender, RoutedEventArgs e)
			{
			if (ReConfigurationRequired != null)
				ReConfigurationRequired(this, "Player", "Hide", null);
			}
		}
	}
