// Copyright (c) 2016 All rights reserved Christian Sack
// <author>Christian Sack</author>
// <email>christian@sack.at</email>
// <website>christian.sack.at</website>
// <date>2017-01-21</date>

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
		static readonly string RingPlayerSolutionFolder = new FileInfo("temp").Directory.GoUpward_Until("SharedComponents").Combine("RingPlayerSolution").FullName;

		static void Main(string[] args)
		{
			Generate
			(
				DbAccounts.Generator.CentralService.DataSource,
				DbAccounts.Generator.CentralService.UserName,
				DbAccounts.Generator.CentralService.Password,
				Path.Combine(SolutionFolder, "HsCentralServiceWeb", "_dbs"),
				Path.Combine(SolutionFolder, "HsCentralServiceWeb", "HsCentralServiceWeb.csproj"), "HsCentralServiceWeb._dbs"
			);
			Generate
			(
				DbAccounts.Generator.RingPlayer.DataSource,
				DbAccounts.Generator.RingPlayer.UserName,
				DbAccounts.Generator.RingPlayer.Password,
				Path.Combine(RingPlayerSolutionFolder, @"RingPlayer24", "_dbs"),
				Path.Combine(RingPlayerSolutionFolder, "RingPlayer24", "RingPlayer24.csproj"),"RingPlayer24._dbs"
			);
			Generate
			(
				DbAccounts.Generator.CentralService.DataSource,
				DbAccounts.Generator.CentralService.UserName,
				DbAccounts.Generator.CentralService.Password,
				Path.Combine(SolutionFolder, @"TestApplication", "_dbs"),
				Path.Combine(SolutionFolder, "TestApplication", "TestApplication.csproj"), "TestApplication._dbs"
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