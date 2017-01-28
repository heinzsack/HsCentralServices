// Copyright (c) 2016 All rights reserved Christian Sack
// <author>Christian Sack</author>
// <email>christian@sack.at</email>
// <website>christian.sack.at</website>
// <date>2017-01-26</date>

using System;
using System.Web.Mvc.Html;
using System.Windows.Markup;
using HsCentralServiceWeb._dbs.hsserver.centralservicedb.tables;






namespace HsCentralServiceWeb._dbs.hsserver.centralservicedb.rows
{
	public partial class RemoteLog
	{
		[DependsOn(nameof(SeverityNumber))]
		public CsWpfBase.Global.remote.services.logging.components.RemoteLog.Severitys Severity
		{
			get { return Convert.Enum.Getter(SeverityNumber, CsWpfBase.Global.remote.services.logging.components.RemoteLog.Severitys.Information); }
			set { Convert.Enum.Setter(()=> SeverityNumber = (int)value); }
		}
	}
}