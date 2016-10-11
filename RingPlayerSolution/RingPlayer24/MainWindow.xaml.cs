using System;
using System.IO;
using System.Linq;
using System.Windows;
using CsWpfBase.Ev.Public.Extensions;
using CsWpfBase.Global;
using HsCentralServiceWebInterfacesClient.steadyConnection.hubs.ringDistribution.newRingAvailableArgs;
using HsCentralServiceWebInterfacesClient.steadyConnection.hubs.ringDistribution.playerDataArgs;
using HsCentralServiceWebInterfacesServer._dbs.hsserver.ringplayerdb.rows;
using RingPlayer24._sys;

namespace RingPlayer24
	{
	/// <summary>
	/// Interaction logic for MainWindow.xaml
	/// </summary>
	public partial class MainWindow : Window
		{

#if DEBUG
		String ServerAdresse = "http://localhost:5555/";
#else
		String ServerAdresse = "http://www.internettv.citynews.at/TempApp";
#endif


		public MainWindow()
			{
			CsGlobal.Install(GlobalFunctions.Storage | GlobalFunctions.AppData);
			//Sys.Storage.GetPlayingRingFilePath().LoadAs_Object_From_SerializedBinary<RingPlayerDb>().OpenViewer();
			//Environment.Exit(1);

	        //ServerAdresse = "http://www.internettv.citynews.at/TempApp";


			InitializeComponent();

			this.Loaded += MainWindow_Loaded;
			Sys.ServerConnection.RingDistribution.NewRingAvailable += RingDistribution_NewRingAvailable;
			Sys.ServerConnection.RingDistribution.PlayerDataRequested += RingDistributionOnPlayerDataRequested;
			Sys.ServerConnection.Opened += ServerConnectionOnOpened;

			Sys.Services.RingPlayerService.RingDownloadCompleted += RingPlayerService_RingDownloadCompleted;

			OpenConnection();



			}

		private void ServerConnectionOnOpened()
			{
			Sys.Services.RingPlayerService.SendInstanceArgs();
			//Sys.ServerConnection.Management.Log(LogSeverity.Information,
			//	$"ServerConnectionOnOpened {Environment.MachineName} to {ServerAdresse}", "after successfull Open Connection");
			}

		private void MainWindow_Loaded(object sender, RoutedEventArgs e)
			{
			Sys.Services.RingPlayerService.LoadCurrentPlayingDataSetFromFile();
			}

		private void RingDistribution_NewRingAvailable(NewRingAvailableArgs args)
			{
			//Sys.ServerConnection.Management.Log(LogSeverity.Information,
			//	$"RingDistribution_NewRingAvailable {Environment.MachineName} to {ServerAdresse}", $"before {args.DownloadUrl}");
			Sys.Services.RingPlayerService.DownloadRing(args);
			}
		private void RingDistributionOnPlayerDataRequested(PlayerDataRequestArgs args)
			{
			Sys.Services.RingPlayerService.SendInstanceArgs();
			}
		private void RingPlayerService_RingDownloadCompleted(RingMetaData ring)
			{
			Sys.Services.RingPlayerService.CurrentPlayingRing = ring;
			//Sys.ServerConnection.Management.Log(LogSeverity.Information,
			//	$"RingPlayerService_RingDownloadCompleted {Environment.MachineName} to {ServerAdresse}", $"after {ring.Id} completed");
			}
		private void CloseClicked(object sender, RoutedEventArgs e)
			{
			CsGlobal.App.Exit();
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