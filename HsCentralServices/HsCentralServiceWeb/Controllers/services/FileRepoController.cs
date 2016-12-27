// Copyright (c) 2016 All rights reserved Christian Sack
// <author>Christian Sack</author>
// <email>christian@sack.at</email>
// <website>christian.sack.at</website>
// <date>2016-12-20</date>

using System;
using System.Text;
using System.Threading;
using System.Web.Mvc;
using CsWpfBase.Global.transmission.remoteFileRepository.client;
using HsCentralServiceWeb._sys;






namespace HsCentralServiceWeb.Controllers.services
{
	public class FileRepoController : Controller
	{
		[HttpGet]
		[ActionName(nameof(RemoteFileRepository.RelativeRoutes.Get))]
		public ActionResult Get(Guid id)
		{
			lock (Sys.Data.CentralService)
			{
				Thread.Sleep(5000);
				Sys.Services.FileRepo.AddFileInfoToResponseHeader(id);
				return new FileStreamResult(Sys.Services.FileRepo.Open(id), "file");
			}
		}

		[HttpPost]
		[ActionName(nameof(RemoteFileRepository.RelativeRoutes.Save))]
		public ActionResult Save()
		{
			lock (Sys.Data.CentralService)
			{
				var savedGuid = Sys.Services.FileRepo.Save(Request.InputStream, Request.Headers[RemoteFileRepository.Headers.FileName], Request.Headers[RemoteFileRepository.Headers.FileExtension], Request.Headers[RemoteFileRepository.Headers.FileDescription]);
				Sys.Services.FileRepo.AddFileInfoToResponseHeader(savedGuid);
				return new ContentResult { Content = savedGuid.ToString(), ContentEncoding = Encoding.UTF8, ContentType = "Guid" };
			}
		}

		[HttpPost]
		public ActionResult Delete(Guid id)
		{
			Sys.Services.FileRepo.Delete(id);
			return new ContentResult() {Content = "Succeeded"};
		}
	}
}