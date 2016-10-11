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
//<date>2016-10-11 17:43:35</date>



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
using IPageSchedule=HsCentralServiceWebInterfacesServer._dbs.hsserver.ringplayerdb.rowinterfaces.IPageSchedule;






namespace HsCentralServiceWebInterfacesServer._dbs.hsserver.ringplayerdb.rowinterfaces
{
	///	<summary>Interface for <see cref="PageSchedule"/> can be used to create POCO object or other models.</summary>
	[CsDbDataRowInterface(Database = "RingPlayerDb", TableName = "PageSchedules", Generated = "16.10.11 17:43:35", Hash = "7E7A0BA58E7D27812EDD1F80750F12D8")]
	public interface IPageSchedule
	{
		///	<summary>[<c>RingPlayerDb</c>].[<c>PageSchedules</c>].[<c>Id</c>]</summary>
		Guid Id { get; set; }
		///	<summary>[<c>RingPlayerDb</c>].[<c>PageSchedules</c>].[<c>DiagnosticText</c>]</summary>
		String DiagnosticText { get; set; }
		///	<summary>[<c>RingPlayerDb</c>].[<c>PageSchedules</c>].[<c>RingMetaDataId</c>]</summary>
		Int32 RingMetaDataId { get; set; }
		///	<summary>[<c>RingPlayerDb</c>].[<c>PageSchedules</c>].[<c>PageId</c>]</summary>
		Guid PageId { get; set; }
		///	<summary>[<c>RingPlayerDb</c>].[<c>PageSchedules</c>].[<c>PageGroupScheduleId</c>]</summary>
		Guid PageGroupScheduleId { get; set; }
		///	<summary>[<c>RingPlayerDb</c>].[<c>PageSchedules</c>].[<c>SlotId</c>]</summary>
		Guid SlotId { get; set; }
		///	<summary>[<c>RingPlayerDb</c>].[<c>PageSchedules</c>].[<c>StartTime</c>]</summary>
		DateTime StartTime { get; set; }
	}
}