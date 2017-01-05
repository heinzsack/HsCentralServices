// Copyright (c) 2016 All rights reserved Christian Sack
// <author>Christian Sack</author>
// <email>christian@sack.at</email>
// <website>christian.sack.at</website>
// <date>2017-01-05</date>

using System;
using System.IO;
using System.Text;
using System.Web.Mvc;
using CsWpfBase.Global;
using CsWpfBase.Remote.clientSide.fileRepository;
using CsWpfBase.Remote.serverSide;
using CsWpfBase.Remote._protocols;
using HsCentralServiceWeb._sys;






namespace HsCentralServiceWeb.Controllers.services
{
	/// <summary>
	///     This <see cref="FileRepoController" /> represents the server side interface for accessing the file repository over the internet. Clients can
	///     access this via the <see cref="CsGlobal.Remote" /> scope.
	/// </summary>
	public class FileRepoController : Controller
	{
		/// <summary>Installs the <see cref="CsRemoteServer.I" /> module for the whole website.</summary>
		static FileRepoController()
		{
			CsRemoteServer.InstallServer(new DirectoryInfo(Sys.Data.CentralService.WebConfigurations.FileManagementService.StorageDirectory));
		}


		/// <summary>Used for downloading infos about files. This is the server interface for the <see cref="FileRepositoryClient.FindOrDownloadInfo(Guid)" />
		///     method.</summary>
		[HttpGet]
		[ActionName(nameof(RemoteProtocol.FileRepository.Http.Routes.Info))]
		public ActionResult Info()
		{
			lock (Sys.Data)
			{
				CsRemoteServer.I.FileRepository.Info(Sys.Data.CentralService.RepositoryFiles);
				return new ContentResult {Content = "success", ContentEncoding = Encoding.UTF8, ContentType = "string"};
			}
		}

		/// <summary>Used for downloading a complete file. This is the server interface for the <see cref="FileRepositoryClient.FindOrDownload(Guid)" />
		///     method.</summary>
		[HttpGet]
		[ActionName(nameof(RemoteProtocol.FileRepository.Http.Routes.Download))]
		public ActionResult Download()
		{
			Stream stream = null;
			try
			{
				lock (Sys.Data)
				{
					stream = CsRemoteServer.I.FileRepository.Download(Sys.Data.CentralService.RepositoryFiles);
				}
				return new FileStreamResult(stream, "file");
			}
			catch
			{
				stream?.Close();
				stream?.Dispose();
				throw;
			}
		}

		/// <summary>Used for uploading a complete file. This is the server interface for the <see cref="FileRepositoryClient.Upload(FileInfo,string,Guid?)" />
		///     method.</summary>
		[HttpPost]
		[ActionName(nameof(RemoteProtocol.FileRepository.Http.Routes.Upload))]
		public ActionResult Upload()
		{
			lock (Sys.Data)
			{
				CsRemoteServer.I.FileRepository.Upload(Sys.Data.CentralService.RepositoryFiles);
				return new ContentResult {Content = "success", ContentEncoding = Encoding.UTF8, ContentType = "string"};
			}
		}

		[HttpPost]
		[ActionName(nameof(RemoteProtocol.FileRepository.Http.Routes.Delete))]
		public ActionResult Delete()
		{
			lock (Sys.Data)
			{
				CsRemoteServer.I.FileRepository.Delete(Sys.Data.CentralService.RepositoryFiles);
				return new ContentResult {Content = "success"};
			}
		}
	}
}