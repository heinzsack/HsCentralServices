// Copyright (c) 2016 All rights reserved Christian Sack
// <author>Christian Sack</author>
// <email>christian@sack.at</email>
// <website>christian.sack.at</website>
// <date>2016-12-20</date>

using System;
using System.IO;
using System.Text;
using System.Threading;
using System.Web.Mvc;
using CsWpfBase.Global.transmission.remoteFileRepository.client;
using CsWpfBase.Global.transmission.remoteFileRepository.server;
using HsCentralServiceWeb._sys;






namespace HsCentralServiceWeb.Controllers.services
{
	public class FileRepoController : Controller
	{
#if DEBUG
		private static readonly RemoteFileRepositoryServer Repo = new RemoteFileRepositoryServer(new DirectoryInfo(@"\\speicher\AData2\HsCentralServiceWeb"));
#else
		private static readonly RemoteFileRepositoryServer Repo = new RemoteFileRepositoryServer(new DirectoryInfo(Sys.Data.CentralService.WebConfigurations.FileManagementService.StorageDirectory));
#endif



		[HttpGet]
		[ActionName(nameof(RemoteFileRepository.RelativeRoutes.Get))]
		public ActionResult Get(Guid id)
		{
			lock (Sys.Data.CentralService)
			{
				return new FileStreamResult(Repo.Open(id, Sys.Data.CentralService.RepositoryFiles), "file");
			}
		}

		[HttpPost]
		[ActionName(nameof(RemoteFileRepository.RelativeRoutes.Save))]
		public ActionResult Save()
		{
			lock (Sys.Data.CentralService)
			{
				return new ContentResult
				{
					Content = Repo.Save(Sys.Data.CentralService.RepositoryFiles).ToString(),
					ContentEncoding = Encoding.UTF8,
					ContentType = "Guid"
				};
			}
		}

		[HttpPost]
		public ActionResult Delete(Guid id)
		{
			lock (Sys.Data.CentralService)
			{
				Repo.Delete(id, Sys.Data.CentralService.RepositoryFiles);
				return new ContentResult() {Content = "Succeeded"};
			}
		}
	}
}