using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;
using CsWpfBase.Db;
using CsWpfBase.Db.codegen.architecture;
using CsWpfBase.Db.codegen.architecture.parts;
using CsWpfBase.Db.codegen.code;
using CsWpfBase.Ev.Public.Extensions;

namespace DbsGenerator
	{
	/// <summary>
	/// Interaction logic for App.xaml
	/// </summary>
	public partial class App : Application
		{
		readonly String _solutionFolder = new FileInfo("temp").Directory.GoUpward_Until("HsCentralServices").FullName;

		private void App_OnStartup(object sender, StartupEventArgs e)
			{
			Generate     // Central Control Db
				(
				server: DbAccounts.Generator.CentralService.DataSource,
				user: DbAccounts.Generator.CentralService.UserName,
				password: DbAccounts.Generator.CentralService.Password,
				projectFolder: Path.Combine(_solutionFolder, "HsCentralServiceWeb", "_dbs"),
				projectFile: Path.Combine(_solutionFolder, "HsCentralServiceWeb", "HsCentralServiceWeb.csproj"),
				nameSpace: "HsCentralServiceWeb._dbs"
				);
			Generate // Ring Player Db
				(
				server: DbAccounts.Generator.RingPlayer.DataSource,
				user: DbAccounts.Generator.RingPlayer.UserName,
				password: DbAccounts.Generator.RingPlayer.Password,
				projectFolder: Path.Combine(_solutionFolder, @"HsCentralServiceWeb.Interfaces.Server", "_dbs"),
				projectFile: Path.Combine(_solutionFolder, "HsCentralServiceWeb.Interfaces.Server", "HsCentralServiceWeb.Interfaces.Server.csproj"),
				nameSpace: "HsCentralServiceWebInterfacesServer._dbs"
				);
			Environment.Exit(1);
			}

		private void Generate(string server, string user, string password, string projectFolder, string projectFile, string nameSpace)
			{
			CsDbArchitecture architecture = CsDb.CodeGen.Create.Architecture_From_Sql(server, user, password);
			CsDbCodeBundle codeBundle = architecture.GetCodeBundle();
			codeBundle.SetPaths(projectFolder, nameSpace, projectFile);
			codeBundle.Write(false);
			}
		}
	}
