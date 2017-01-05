// Copyright (c) 2016 All rights reserved Christian Sack
// <author>Christian Sack</author>
// <email>christian@sack.at</email>
// <website>christian.sack.at</website>
// <date>2017-01-05</date>

using System;
using System.IO;
using System.Text;
using System.Web.Mvc;
using CsWpfBase.Remote;
using CsWpfBase.Remote._protocols;
using HsCentralServiceWeb._sys;






namespace HsCentralServiceWeb.Controllers.services
{
	public class FileRepoController : Controller
	{

		public FileRepoController()
		{
#if DEBUG
			CsRemote.InstallServer(new DirectoryInfo(@"\\speicher\AData2\HsCentralServiceWeb"));
#else
			Remote.InstallServer(new DirectoryInfo(new DirectoryInfo(Sys.Data.CentralService.WebConfigurations.FileManagementService.StorageDirectory)));
#endif
		}


		[HttpGet]
		[ActionName(nameof(RemoteProtocol.FileRepository.Http.Routes.Info))]
		public ActionResult Info()
		{
			lock (Sys.Data.CentralService)
			{
				CsRemote.Server.FileRepository.Info(Sys.Data.CentralService.RepositoryFiles);
				return new ContentResult {Content = "success", ContentEncoding = Encoding.UTF8, ContentType = "string"};
			}
		}

		[HttpGet]
		[ActionName(nameof(RemoteProtocol.FileRepository.Http.Routes.Download))]
		public ActionResult Download()
		{
			Stream stream = null;
			try
			{
				lock (Sys.Data.CentralService)
				{
					stream = CsRemote.Server.FileRepository.Download(Sys.Data.CentralService.RepositoryFiles);
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

		[HttpPost]
		[ActionName(nameof(RemoteProtocol.FileRepository.Http.Routes.Upload))]
		public ActionResult Upload()
		{
			lock (Sys.Data.CentralService)
			{
				CsRemote.Server.FileRepository.Upload(Sys.Data.CentralService.RepositoryFiles);
				return new ContentResult { Content = "success", ContentEncoding = Encoding.UTF8, ContentType = "string" };
			}
		}

		[HttpPost]
		[ActionName(nameof(RemoteProtocol.FileRepository.Http.Routes.Delete))]
		public ActionResult Delete()
		{
			lock (Sys.Data.CentralService)
			{
				CsRemote.Server.FileRepository.Delete(Sys.Data.CentralService.RepositoryFiles);
				return new ContentResult() {Content = "Succeeded"};
			}
		}
	}
}