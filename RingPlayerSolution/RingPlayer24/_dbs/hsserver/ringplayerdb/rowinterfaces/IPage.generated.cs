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
//<date>2017-01-26 17:28:57</date>



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
using IPage=RingPlayer24._dbs.hsserver.ringplayerdb.rowinterfaces.IPage;






namespace RingPlayer24._dbs.hsserver.ringplayerdb.rowinterfaces
{
	///	<summary>Interface for <see cref="Page"/> can be used to create POCO object or other models.</summary>
	[CsDbDataRowInterface(Database = "RingPlayerDb", TableName = "Pages", Generated = "17.01.26 17:28:57", Hash = "84F76927133911CB19B6960112949DA4")]
	public interface IPage
	{
		///	<summary>[<c>RingPlayerDb</c>].[<c>Pages</c>].[<c>Id</c>]</summary>
		Guid Id { get; set; }
		///	<summary>[<c>RingPlayerDb</c>].[<c>Pages</c>].[<c>ParentPageId</c>]</summary>
		Guid? ParentPageId { get; set; }
		///	<summary>[<c>RingPlayerDb</c>].[<c>Pages</c>].[<c>SortOrder</c>]</summary>
		Int32 SortOrder { get; set; }
		///	<summary>[<c>RingPlayerDb</c>].[<c>Pages</c>].[<c>MarginThickness</c>]</summary>
		String MarginThickness { get; set; }
		///	<summary>[<c>RingPlayerDb</c>].[<c>Pages</c>].[<c>BorderThickness</c>]</summary>
		String BorderThickness { get; set; }
		///	<summary>[<c>RingPlayerDb</c>].[<c>Pages</c>].[<c>Background</c>]</summary>
		String Background { get; set; }
		///	<summary>[<c>RingPlayerDb</c>].[<c>Pages</c>].[<c>BorderColor</c>]</summary>
		String BorderColor { get; set; }
		///	<summary>[<c>RingPlayerDb</c>].[<c>Pages</c>].[<c>Rotation</c>]</summary>
		Double Rotation { get; set; }
		///	<summary>[<c>RingPlayerDb</c>].[<c>Pages</c>].[<c>HasFixedRatio</c>]</summary>
		Boolean HasFixedRatio { get; set; }
		///	<summary>[<c>RingPlayerDb</c>].[<c>Pages</c>].[<c>RatioX</c>]</summary>
		Double RatioX { get; set; }
		///	<summary>[<c>RingPlayerDb</c>].[<c>Pages</c>].[<c>RatioY</c>]</summary>
		Double RatioY { get; set; }
		///	<summary>[<c>RingPlayerDb</c>].[<c>Pages</c>].[<c>DiagnosticText</c>]</summary>
		String DiagnosticText { get; set; }
	}
}