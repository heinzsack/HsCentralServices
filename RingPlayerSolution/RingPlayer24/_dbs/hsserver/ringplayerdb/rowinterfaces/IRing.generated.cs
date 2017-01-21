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
using IRing=RingPlayer24._dbs.hsserver.ringplayerdb.rowinterfaces.IRing;






namespace RingPlayer24._dbs.hsserver.ringplayerdb.rowinterfaces
{
	///	<summary>Interface for <see cref="Ring"/> can be used to create POCO object or other models.</summary>
	[CsDbDataRowInterface(Database = "RingPlayerDb", TableName = "Rings", Generated = "17.01.21 20:15:00", Hash = "7283E4A274B528A6ECA3C602BEC8081D")]
	public interface IRing
	{
		///	<summary>[<c>RingPlayerDb</c>].[<c>Rings</c>].[<c>Id</c>]</summary>
		Guid Id { get; set; }
		///	<summary>[<c>RingPlayerDb</c>].[<c>Rings</c>].[<c>CreationDate</c>]</summary>
		DateTime CreationDate { get; set; }
		///	<summary>[<c>RingPlayerDb</c>].[<c>Rings</c>].[<c>TargetDate</c>]</summary>
		DateTime TargetDate { get; set; }
		///	<summary>[<c>RingPlayerDb</c>].[<c>Rings</c>].[<c>DiagnosticText</c>]</summary>
		String DiagnosticText { get; set; }
	}
}