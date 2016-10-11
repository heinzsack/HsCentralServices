// Copyright (c) 2016 All rights reserved Christian Sack
// <author>Christian Sack</author>
// <email>christian@sack.at</email>
// <website>christian.sack.at</website>
// <date>2016-09-18</date>

using System;
using System.Threading.Tasks;
using System.Windows;
using HsCentralServiceWebInterfacesClient.steadyConnection.hubs.ringDistribution.newRingAvailableArgs;
using HsCentralServiceWebInterfacesClient.steadyConnection.hubs.ringDistribution.playerDataArgs;
using HsCentralServiceWebInterfacesClient.steadyConnection.hubs.ringDistribution.ringValidationArgs;
using Microsoft.AspNet.SignalR.Client;






namespace HsCentralServiceWebInterfacesClient.steadyConnection.hubs.ringDistribution
	{
	public class RingDistributionHubClient : IRingDistributionHubProtocol
		{
		private IHubProxy _proxy;
		#region Overrides/Interfaces

		public Task UpdatePlayerData(PlayerDataArgs args)
			{
			try
				{
				return _proxy?.Invoke(nameof(IRingDistributionHubProtocol.UpdatePlayerData), args);
				}
			catch (Exception)
				{
				return null;
				}
			}

		public Task<RingValidationResultArgs> RingValidation(RingValidationArgs args)
			{
			try
				{
				return _proxy?.Invoke<RingValidationResultArgs>(nameof
					(IRingDistributionHubProtocol.RingValidation), args);
				}
			catch (Exception)
				{
				return null;
				}
			}

		public event NewRingAvailableArgs.Delegate NewRingAvailable;
		public event PlayerDataRequestArgs.Delegate PlayerDataRequested;
		#endregion


		internal void SetConnection(HubConnection connection)
		{
		if (connection == null)
			{
				_proxy = null;
				return;
			}
//TODO by HS adding the if

			if (_proxy != null)
				return;
			_proxy = connection.CreateHubProxy(nameof(IRingDistributionHubProtocol));
			_proxy.On<NewRingAvailableArgs>(nameof(IRingDistributionHubProtocol
				.NewRingAvailable), args => Application.Current.Dispatcher.BeginInvoke
					(new Action(() => NewRingAvailable?.Invoke(args))));
			_proxy.On<PlayerDataRequestArgs>(nameof(IRingDistributionHubProtocol
				.PlayerDataRequested), args => Application.Current.Dispatcher.BeginInvoke
					(new Action(() => PlayerDataRequested?.Invoke(args))));
		}
	}
}