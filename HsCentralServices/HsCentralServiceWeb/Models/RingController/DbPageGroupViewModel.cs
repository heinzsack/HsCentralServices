// Copyright (c) 2016 All rights reserved Christian Sack
// <author>Christian Sack</author>
// <email>christian@sack.at</email>
// <website>christian.sack.at</website>
// <date>2016-10-11</date>

using System;
using System.Linq;
using CsWpfBase.Ev.Public.Extensions;
using HsCentralServiceWebInterfacesServer._dbs.hsserver.ringplayerdb.rows;






namespace HsCentralServiceWeb.Models.RingController
{
	public class DbPageGroupViewModel
	{
		public DbPageGroupViewModel(PageGroup pageGroup)
		{
			PageGroup = pageGroup;
			Entries = pageGroup.Pages.Select(x =>
									new Entry()
									{
										Page = x,
										Base64Image = x.GetRenderedImage(1920.0/2, 1080.0/2).Result.ConvertTo_JpgByteArray().ConvertTo_Base64()
									}).ToArray();
		}

		public PageGroup PageGroup { get; set; }
		public Entry[] Entries { get; set; }

		public class Entry
		{
			public Page Page { get; set; }
			public string Base64Image { get; set; }
		}
	}
}