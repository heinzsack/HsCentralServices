using System;






namespace HsCentralServiceWebInterfacesClient.steadyConnection.hubs.management.args
{
	public class LogArgs
	{
		public DateTime CreationTime { get; set; }
		public LogSeverity Severity { get; set; }
		public string Title { get; set; }
		public string Message { get; set; }
		public string CodeFile { get; set; }
		public string CodeMethod { get; set; }
		public int CodeLine { get; set; }
	}
}