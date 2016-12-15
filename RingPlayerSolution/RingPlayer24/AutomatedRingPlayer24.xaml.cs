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
using HsCentralServiceWebInterfacesClient.steadyConnection.hubs.ringDistribution.newRingAvailableArgs;
using HsCentralServiceWebInterfacesClient.steadyConnection.hubs.ringDistribution.playerDataArgs;
using HsCentralServiceWebInterfacesServer._dbs.hsserver.ringplayerdb.rows;
using RingPlayer24._sys;

namespace RingPlayer24
	{
	/// <summary>
	/// Interaction logic for AutomatedRingPlayer24.xaml
	/// </summary>
	public partial class AutomatedRingPlayer24 : UserControl
		{
		public event Action<Object, String, String, Object> ReConfigurationRequired;


#if DEBUG && HS
		String ServerAdresse = "http://localhost:16411/";
#elif DEBUG
		String ServerAdresse = "http://localhost:16411/";
#else
		String ServerAdresse = "http://www.internettv.citynews.at/TempApp";
#endif
		public AutomatedRingPlayer24()
			{
			CsGlobal.Install(GlobalFunctions.Storage | GlobalFunctions.AppData);
			if (Application.Current.Properties.Contains("ServerAdresse"))
				ServerAdresse = Application.Current.Properties["ServerAdresse"].ToString();
			InitializeComponent();
			this.Loaded += AutomatedRingPlayer24_OnLoaded;
			Sys.ServerConnection.RingDistribution.NewRingAvailable += RingDistribution_NewRingAvailable;
			Sys.ServerConnection.RingDistribution.PlayerDataRequested += RingDistributionOnPlayerDataRequested;
			Sys.ServerConnection.Opened += ServerConnectionOnOpened;

			Sys.Services.RingPlayerService.RingDownloadCompleted += RingPlayerService_RingDownloadCompleted;

			OpenConnection();

			}

		//private void MainWindow_Loaded(object sender, RoutedEventArgs e)
		//	{
		//	Sys.Services.RingPlayerService.LoadCurrentPlayingDataSetFromFile();
		//	}
		private void AutomatedRingPlayer24_OnLoaded(object sender, RoutedEventArgs e)
			{
			Sys.Services.RingPlayerService.LoadCurrentPlayingDataSetFromFile();
			}

		private void ServerConnectionOnOpened()
			{
			Sys.Services.RingPlayerService.SendInstanceArgs();
			}


		private void RingDistribution_NewRingAvailable(NewRingAvailableArgs args)
			{
			Sys.Services.RingPlayerService.DownloadRing(args);
			}
		private void RingDistributionOnPlayerDataRequested(PlayerDataRequestArgs args)
			{
			Sys.Services.RingPlayerService.SendInstanceArgs();
			}
		private void RingPlayerService_RingDownloadCompleted(RingMetaData ring)
			{
			Sys.Services.RingPlayerService.CurrentPlayingRing = ring;
			}
		private void CloseClicked(object sender, RoutedEventArgs e)
			{
			if (ReConfigurationRequired != null)
				ReConfigurationRequired(this, "Player", "Hide", null);
			}

		private void ReOpenConnection_OnClick(object sender, RoutedEventArgs e)
			{
			if (MessageBox.Show($"Aktueller State = {RingPlayer24._sys.Sys.ConnectionStateDescription}\r\n" +
								$"soll die Connection zu\r\n" +
								$"{ServerAdresse} neu geöffnet werden?",
					"Sicherheitsabfrage", MessageBoxButton.YesNo) != MessageBoxResult.Yes)
				return;

			OpenConnection();
			}

		private void OpenConnection()
			{
			Sys.ServerConnection.Open(ServerAdresse);
			}

		}
	}
