using System;
using System.Threading.Tasks;
using HsCentralServiceWebInterfacesClient.steadyConnection.hubs.management.args;






namespace HsCentralServiceWebInterfacesClient.steadyConnection.hubs.management
{
	public interface IRemoteManagementHubProtocol
	{
		Task Log(LogArgs args);
		event RestartArgs.Delegate Restart;
	}



}
