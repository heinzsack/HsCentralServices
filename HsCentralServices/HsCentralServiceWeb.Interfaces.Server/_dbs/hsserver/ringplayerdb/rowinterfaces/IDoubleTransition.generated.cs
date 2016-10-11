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
using IDoubleTransition=HsCentralServiceWebInterfacesServer._dbs.hsserver.ringplayerdb.rowinterfaces.IDoubleTransition;






namespace HsCentralServiceWebInterfacesServer._dbs.hsserver.ringplayerdb.rowinterfaces
{
	///	<summary>Interface for <see cref="DoubleTransition"/> can be used to create POCO object or other models.</summary>
	[CsDbDataRowInterface(Database = "RingPlayerDb", TableName = "DoubleTransitions", Generated = "16.10.11 17:43:35", Hash = "C147FA375895CAC683C2E218D3B1E34D")]
	public interface IDoubleTransition
	{
		///	<summary>[<c>RingPlayerDb</c>].[<c>DoubleTransitions</c>].[<c>Id</c>]</summary>
		Guid Id { get; set; }
		///	<summary>[<c>RingPlayerDb</c>].[<c>DoubleTransitions</c>].[<c>PageId</c>]</summary>
		Guid PageId { get; set; }
		///	<summary>[<c>RingPlayerDb</c>].[<c>DoubleTransitions</c>].[<c>BeginnTimeSeconds</c>]</summary>
		Double BeginnTimeSeconds { get; set; }
		///	<summary>[<c>RingPlayerDb</c>].[<c>DoubleTransitions</c>].[<c>DurationSeconds</c>]</summary>
		Double DurationSeconds { get; set; }
		///	<summary>[<c>RingPlayerDb</c>].[<c>DoubleTransitions</c>].[<c>FromValue</c>]</summary>
		Double FromValue { get; set; }
		///	<summary>[<c>RingPlayerDb</c>].[<c>DoubleTransitions</c>].[<c>ToValue</c>]</summary>
		Double ToValue { get; set; }
		///	<summary>[<c>RingPlayerDb</c>].[<c>DoubleTransitions</c>].[<c>PropertyPath</c>]</summary>
		String PropertyPath { get; set; }
		///	<summary>[<c>RingPlayerDb</c>].[<c>DoubleTransitions</c>].[<c>TransitionType</c>]</summary>
		String TransitionType { get; set; }
	}
}