//********************************************************************
//
//                 AUTOGENERATED CONTENT DO NOT MODIFY
//                      PRODUCED BY CsWpfBase.Db
//
//********************************************************************
//
//
//Copyright (c) 2014 - 2016 All rights reserved Christian Sack
//<author>Christian Sack</author>
//<email>service.christian@sack.at</email>
//<website>christian.sack.at</website>
//<date>2017-01-21 20:15:00</date>



using System;
using System.Data;
using System.Diagnostics;
using System.Linq;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Windows;
using System.Windows.Markup;
using CsWpfBase.Ev.Public.Extensions;
using CsWpfBase.Db.attributes;
using CsWpfBase.Db.attributes.columnAttributes;
using CsWpfBase.Db.models;
using CsWpfBase.Db.models.helper;
using CsWpfBase.Db.models.bases;
using CsWpfBase.Db.router;
using System.IO;
using System.Text;
using System.ComponentModel;
using IRingEntry=RingPlayer24._dbs.hsserver.ringplayerdb.rowinterfaces.IRingEntry;






namespace RingPlayer24._dbs.hsserver.ringplayerdb.rowinterfaces
{
	///	<summary>Interface for <see cref="RingEntry"/> can be used to create POCO object or other models.</summary>
	[CsDbDataRowInterface(Database = "RingPlayerDb", TableName = "RingEntries", Generated = "17.01.21 20:15:00", Hash = "A2EAB2D7A4E27C587826F3058AE5F3B8")]
	public interface IRingEntry
	{
		///	<summary>[<c>RingPlayerDb</c>].[<c>RingEntries</c>].[<c>Id</c>]</summary>
		Guid Id { get; set; }
		///	<summary>[<c>RingPlayerDb</c>].[<c>RingEntries</c>].[<c>PageId</c>]</summary>
		Guid PageId { get; set; }
		///	<summary>[<c>RingPlayerDb</c>].[<c>RingEntries</c>].[<c>RingId</c>]</summary>
		Guid RingId { get; set; }
		///	<summary>[<c>RingPlayerDb</c>].[<c>RingEntries</c>].[<c>StartTime</c>]</summary>
		DateTime StartTime { get; set; }
		///	<summary>[<c>RingPlayerDb</c>].[<c>RingEntries</c>].[<c>DiagnosticText</c>]</summary>
		String DiagnosticText { get; set; }
	}
}