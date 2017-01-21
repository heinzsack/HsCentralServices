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
//<date>2017-01-21 20:14:59</date>



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
using IWebUser=HsCentralServiceWeb._dbs.hsserver.centralservicedb.rowinterfaces.IWebUser;






namespace HsCentralServiceWeb._dbs.hsserver.centralservicedb.rowinterfaces
{
	///	<summary>Interface for <see cref="WebUser"/> can be used to create POCO object or other models.</summary>
	[CsDbDataRowInterface(Database = "CentralServiceDb", TableName = "WebUsers", Generated = "17.01.21 20:14:59", Hash = "3916951889DC08BD54E0816EDDBE6E6D")]
	public interface IWebUser
	{
		///	<summary>[<c>CentralServiceDb</c>].[<c>WebUsers</c>].[<c>Id</c>]</summary>
		Guid Id { get; set; }
		///	<summary>[<c>CentralServiceDb</c>].[<c>WebUsers</c>].[<c>Name</c>]</summary>
		String Name { get; set; }
		///	<summary>[<c>CentralServiceDb</c>].[<c>WebUsers</c>].[<c>Description</c>]</summary>
		String Description { get; set; }
		///	<summary>[<c>CentralServiceDb</c>].[<c>WebUsers</c>].[<c>UserName</c>]</summary>
		String UserName { get; set; }
		///	<summary>[<c>CentralServiceDb</c>].[<c>WebUsers</c>].[<c>PasswordMd5</c>]</summary>
		Byte[] PasswordMd5 { get; set; }
	}
}