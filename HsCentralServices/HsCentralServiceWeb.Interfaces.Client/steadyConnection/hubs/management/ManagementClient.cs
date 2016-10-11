using System;
using System.Runtime.CompilerServices;
using System.Threading.Tasks;
using System.Windows;
using HsCentralServiceWebInterfacesClient.steadyConnection.hubs.management.args;
using Microsoft.AspNet.SignalR.Client;






namespace HsCentralServiceWebInterfacesClient.steadyConnection.hubs.management
{
	public class ManagementClient : IRemoteManagementHubProtocol
	{
		private IHubProxy _proxy;
		

		#region Overrides/Interfaces
		public Task Log(LogArgs args)
		{
			return _proxy.Invoke(nameof(IRemoteManagementHubProtocol.Log), args);
		}

		public event RestartArgs.Delegate Restart;
		#endregion


		public Task Log(LogSeverity severity, string title, string message, 
			[CallerFilePath] string filePath = null, 
			[CallerMemberName] string method = null, 
			[CallerLineNumber] int line = 0)
		{
			return Log(new LogArgs() {CreationTime = DateTime.Now, Title = title,
				Severity = severity, Message = message, CodeFile = filePath,
				CodeMethod = method, CodeLine = line});
		}

		internal void SetConnection(HubConnection connection)
			{
//TODO by HS adding the if
			if (_proxy != null)
				return;
			_proxy = connection.CreateHubProxy(nameof(IRemoteManagementHubProtocol));
			_proxy.On<RestartArgs>(nameof(IRemoteManagementHubProtocol.Restart), 
				args => Application.Current.Dispatcher.BeginInvoke(new Action(() => 
					Restart?.Invoke(args))));
		}
	}
}