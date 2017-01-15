// Copyright (c) 2016 All rights reserved Christian Sack
// <author>Christian Sack</author>
// <email>christian@sack.at</email>
// <website>christian.sack.at</website>
// <date>2017-01-15</date>

using System;
using System.IO;
using System.Text;
using System.Web.Mvc;
using CsWpfBase.Global;
using CsWpfBase.Global.remote.clientSide.fileRepository;
using CsWpfBase.Global.remote._protocols;
using HsCentralServiceWeb._dbs.hsserver.centralservicedb.dataset;
using HsCentralServiceWeb._sys;
using HsCentralServiceWeb._sys.data;






namespace HsCentralServiceWeb.Controllers.services
{
	/// <summary>
	///     This <see cref="FileRepoController" /> represents the server side interface for accessing the file repository over the internet. Clients can
	///     access this via the <see cref="CsGlobal.Remote" /> scope.
	/// </summary>
	public class FileRepoController : Controller
	{

		private CentralServiceDb Db { get; }

		public FileRepoController()
		{
			Db = new CentralServiceDb();
			Db.Set_DbProxy<Data.HsServerDirectConnector>();
		}

		/// <summary>Used for downloading infos about files. This is the server interface for the <see cref="FileRepositoryClient.FindOrDownloadInfo(Guid)" />
		///     method.</summary>
		[HttpGet]
		[ActionName(nameof(RemoteProtocol.FileRepository.Http.Routes.Info))]
		public ActionResult Info()
		{
			Sys.RemoteServer.FileRepository.Info(Db.RepositoryFiles);
			return new ContentResult {Content = "success", ContentEncoding = Encoding.UTF8, ContentType = "string"};
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
				stream = Sys.RemoteServer.FileRepository.Download(Db.RepositoryFiles);
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
			Sys.RemoteServer.FileRepository.Upload(Db.RepositoryFiles);
			return new ContentResult {Content = "success", ContentEncoding = Encoding.UTF8, ContentType = "string"};
		}

		[HttpPost]
		[ActionName(nameof(RemoteProtocol.FileRepository.Http.Routes.Delete))]
		public ActionResult Delete()
		{
			Sys.RemoteServer.FileRepository.Delete(Db.RepositoryFiles);
			return new ContentResult {Content = "success"};
		}
	}
}