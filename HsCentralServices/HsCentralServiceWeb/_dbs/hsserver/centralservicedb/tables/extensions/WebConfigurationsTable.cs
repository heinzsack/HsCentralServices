// Copyright (c) 2016 All rights reserved Christian Sack
// <author>Christian Sack</author>
// <email>christian@sack.at</email>
// <website>christian.sack.at</website>
// <date>2016-09-19</date>

using CsWpfBase.Db.tools.configurationTable;
using CsWpfBase.Utilitys;

namespace HsCentralServiceWeb._dbs.hsserver.centralservicedb.tables
{
	partial class WebConfigurationsTable
	{
		private RemoteLogConfiguration _remoteLog;
		private RingDistributionConfiguration _ringDistribution;
		private SmtpConfiguration _smtp;


		#region Abstract
		internal abstract class SubConfiguration
		{

			public SubConfiguration(WebConfigurationsTable parent, string context)
			{
				Parent = parent;
				Context = context;
			}

			public WebConfigurationsTable Parent { get; }
			public string Context { get; }
		}
		#endregion


		internal RemoteLogConfiguration RemoteLog => _remoteLog ?? (_remoteLog = new RemoteLogConfiguration(this));
		internal RingDistributionConfiguration RingDistribution => _ringDistribution ?? (_ringDistribution = new RingDistributionConfiguration(this));
		internal SmtpConfiguration Smtp => _smtp ?? (_smtp = new SmtpConfiguration(this));



		internal class RemoteLogConfiguration : SubConfiguration
		{

			public RemoteLogConfiguration(WebConfigurationsTable parent) : base(parent, nameof(RemoteLog))
			{
			}

			public int CurrentCount
			{
				get { return Parent.GetConfigurationValue(() => Parent.DataSet.RemoteLogs.DownloadRowsCount(), Context); }
				set { Parent.SetConfigurationValue(value, Context); }
			}
			public int TotalCount
			{
				get { return Parent.GetConfigurationValue(() => Parent.DataSet.RemoteLogs.DownloadRowsCount(), Context); }
				set { Parent.SetConfigurationValue(value, Context); }
			}
			public int MaximumCount
			{
				get { return Parent.GetConfigurationValue(2000, Context); }
				set { Parent.SetConfigurationValue(value, Context); }
			}
			public int BatchDeleteCount
			{
				get { return Parent.GetConfigurationValue(100, Context); }
				set { Parent.SetConfigurationValue(value, Context); }
			}
		}



		internal class RingDistributionConfiguration : SubConfiguration
		{

			public RingDistributionConfiguration(WebConfigurationsTable parent) : base(parent, nameof(RingDistribution))
			{
			}

			public int MaxStoredRingsPerComputer
			{
				get { return Parent.GetConfigurationValue(20, Context); }
				set { Parent.SetConfigurationValue(value, Context); }
			}
		}



		internal class SmtpConfiguration : SubConfiguration, IContainMailConfiguration
		{

			public SmtpConfiguration(WebConfigurationsTable parent) : base(parent, nameof(Smtp))
			{
			}
			
			public string MailServer
			{
				get { return Parent.GetConfigurationValue("", Context); }
				set { Parent.SetConfigurationValue(value, Context); }
			}
			public int MailServerPort
			{
				get { return Parent.GetConfigurationValue(25, Context); }
				set { Parent.SetConfigurationValue(value, Context); }
			}
			public bool MailServerEnableSsl
			{
				get { return Parent.GetConfigurationValue(false, Context); }
				set { Parent.SetConfigurationValue(value, Context); }
			}
			public string SenderMail
			{
				get { return Parent.GetConfigurationValue("", Context); }
				set { Parent.SetConfigurationValue(value, Context); }
			}
			public string MailServerUsername
			{
				get { return Parent.GetConfigurationValue("", Context); }
				set { Parent.SetConfigurationValue(value, Context); }
			}
			public string MailServerPassword
			{
				get { return Parent.GetConfigurationValue("", Context); }
				set { Parent.SetConfigurationValue(value, Context); }
			}
			public int MailServerConnectionTimeout
			{
				get { return Parent.GetConfigurationValue(5000, Context); }
				set { Parent.SetConfigurationValue(value, Context); }
			}
		}
	}
}