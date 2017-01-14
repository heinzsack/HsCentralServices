// Copyright (c) 2016 All rights reserved Christian Sack
// <author>Christian Sack</author>
// <email>christian@sack.at</email>
// <website>christian.sack.at</website>
// <date>2016-09-19</date>

using System;
using System.Diagnostics;
using System.Net;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Threading;
using CsWpfBase.Global;
using CsWpfBase.Global.remote.clientIdentification;
using CsWpfBase.Utilitys;
using HsCentralServiceWebInterfacesClient.steadyConnection.hubs.management;
using HsCentralServiceWebInterfacesClient.steadyConnection.hubs.ringDistribution;
using Microsoft.AspNet.SignalR.Client;






namespace HsCentralServiceWebInterfacesClient.steadyConnection
	{
	public class SteadyConnection
		{
		private readonly ProcessLock _closingLock = new ProcessLock();

		public SteadyConnection(bool management, bool ringDistribution)
			{
			if (management)
				Management = new ManagementClient();
			if (ringDistribution)
				RingDistribution = new RingDistributionHubClient();
			CsGlobal.App.OnExit += App_OnExit;
			}

		public RingDistributionHubClient RingDistribution { get; set; }
		public ManagementClient Management { get; set; }
		public HubConnection Connection { get; set; }
		private string Website { get; set; }

//TODO Inserted HS to eanble Information Up the call satck
		public String ConnectionStateDescription
			{
			get
				{
				if (Connection == null)
					{
					return "Connection is null";
					}
				return $"ConnectionState = {Connection.State}, " +
						$"LastError = {Connection.LastError}";
				}
			}


		public event Action Opened;


		/// <summary>Retries to open the connection until it finally connects.</summary>
		public void Open(string website)
			{
			Website = website;
			Open();
			}

		private void App_OnExit(ExitEventArgs obj)
			{
			using (_closingLock.Activate())
				{
				if (Connection != null)
					{
					Connection.Stop();
					Connection.Dispose();
					Connection = null;
					}
				}
			}

		private void Open()
			{
			var synchronizationContext = TaskScheduler.FromCurrentSynchronizationContext();
			Task t = new Task(() =>
				{
				if (Connection != null)
					{
					try
						{
						if (Connection.State != ConnectionState.Connecting)		//TODO inserted by HS to enable automated Reconnect after Server restart
							Connection.Stop();
						}
					finally
						{
//TODO inserted HS the if's
						if ((Connection != null)
							&& (Connection.State != ConnectionState.Connecting))
							{
							if (Connection.State != ConnectionState.Disconnected)
								{
								RingDistribution?.SetConnection(null);
								Management?.SetConnection(null);
								}
//							Connection = null;
							}
						}
					}

				if (Connection == null)
					{
					Connection = new HubConnection(Website);
					Connection.StateChanged += Connection_StateChanged;
					CsClientIdentification.Transmission.Set(Connection.Headers);

					RingDistribution?.SetConnection(Connection);
					Management?.SetConnection(Connection);

					ServicePointManager.DefaultConnectionLimit = 10;

					}
				if (Connection.State != ConnectionState.Connecting)
					Connection.Start().ContinueWith(ContinuationAction, synchronizationContext);
				
				}, TaskCreationOptions.LongRunning);
			t.Start(TaskScheduler.Default);
			}

		private void Connection_StateChanged(StateChange obj)
		{
			if(obj.NewState == ConnectionState.Connected || obj.NewState == ConnectionState.Connecting)
				return;
			//TODO by HS the nect if, for do not disturb an automaated Reconnect 

			if(obj.NewState == ConnectionState.Reconnecting)
				return;
			Debug.WriteLine($"{obj.NewState} - try to Open");
			Application.Current.Dispatcher.BeginInvoke(DispatcherPriority.Background,
				new Action(() => { Open(); }));
		}

		

		private void ContinuationAction(Task task)
			{
			if (task.IsFaulted)
				{
				Application.Current.Dispatcher.BeginInvoke(DispatcherPriority.Background, new Action(() => { Open(); }));
				return;
				}
			Opened?.Invoke();
			}
		}
	}