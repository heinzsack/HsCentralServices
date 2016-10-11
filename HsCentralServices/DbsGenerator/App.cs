// Copyright (c) 2016 All rights reserved Christian Sack
// <author>Christian Sack</author>
// <email>christian@sack.at</email>
// <website>christian.sack.at</website>
// <date>2016-10-11</date>

using System;
using System.IO;
using CsWpfBase.Db;
using CsWpfBase.Ev.Public.Extensions;






namespace DbsGenerator
{
	/// <summary>Interaction logic for App.xaml</summary>
	public partial class App
	{
		static readonly string SolutionFolder = new FileInfo("temp").Directory.GoUpward_Until("HsCentralServices").FullName;

		static void Main(string[] args)
		{
			Generate // HsCentralServiceWeb DBS
			(
				DbAccounts.Generator.CentralService.DataSource,
				DbAccounts.Generator.CentralService.UserName,
				DbAccounts.Generator.CentralService.Password,
				Path.Combine(SolutionFolder, "HsCentralServiceWeb", "_dbs"),
				Path.Combine(SolutionFolder, "HsCentralServiceWeb", "HsCentralServiceWeb.csproj"),
				"HsCentralServiceWeb._dbs"
			);
			Generate // HsCentralServiceWeb.Interfaces.Server DBS
			(
				DbAccounts.Generator.RingPlayer.DataSource,
				DbAccounts.Generator.RingPlayer.UserName,
				DbAccounts.Generator.RingPlayer.Password,
				Path.Combine(SolutionFolder, @"HsCentralServiceWeb.Interfaces.Server", "_dbs"),
				Path.Combine(SolutionFolder, "HsCentralServiceWeb.Interfaces.Server", "HsCentralServiceWeb.Interfaces.Server.csproj"),
				"HsCentralServiceWebInterfacesServer._dbs"
			);
			Environment.Exit(0);
		}
		

		private static void Generate(string server, string user, string password, string projectFolder, string projectFile, string nameSpace)
		{
			var architecture = CsDb.CodeGen.Create.Architecture_From_Sql(server, user, password);
			var codeBundle = architecture.GetCodeBundle();
			codeBundle.SetPaths(projectFolder, nameSpace, projectFile);
			codeBundle.Write(false);
		}
	}
}