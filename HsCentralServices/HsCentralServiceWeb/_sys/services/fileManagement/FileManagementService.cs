// Copyright (c) 2016 All rights reserved Christian Sack
// <author>Christian Sack</author>
// <email>christian@sack.at</email>
// <website>christian.sack.at</website>
// <date>2016-12-22</date>

using System;
using System.IO;
using System.Web;
using CsWpfBase.Ev.Objects;
using CsWpfBase.Ev.Public.Extensions;
using CsWpfBase.Global.transmission.remoteFileRepository.client;
using HsCentralServiceWeb._dbs.hsserver.centralservicedb.rows;
using HsCentralServiceWeb._dbs.hsserver.centralservicedb.tables;






namespace HsCentralServiceWeb._sys.services.fileManagement
{
	/// <summary>used for transferring file from the server to the client and vice versa.</summary>
	public sealed class FileManagementService : Base
	{
		///<summary>The root directory of the folder where all files will be stored.</summary>
		public DirectoryInfo StorageDirectory => new DirectoryInfo(Path.Combine(Sys.Data.CentralService.WebConfigurations.FileManagementService.StorageDirectory, nameof(HsCentralServiceWeb), nameof(FileManagementService)));

		/// <summary>Stores the specified file into the file management system.</summary>
		/// <param name="fileData">the data of the file.</param>
		/// <param name="name">the name of the file, this name will never be used and is just for documenting purpose</param>
		/// <param name="extension">the extension of the file, this will be used for storing the data.</param>
		/// <param name="description">the description of the file for documenting purpose only.</param>
		/// <returns>the guid of the freshly created data.</returns>
		public Guid Save(Stream fileData, string name, string extension, string description)
		{
			extension = extension.RemoveLeadingString(".");

			if (name.IsNullOrEmpty())
				throw new ArgumentException($"The param '{nameof(name)}' cannot be null or empty.");

			if (extension.IsNullOrEmpty())
				throw new ArgumentException($"The param '{nameof(extension)}' cannot be null or empty.");


			//find valid nonexisting ID.
			var targetId = Guid.NewGuid();
			var targetPath = GetPathById(targetId, name, extension);
			try
			{
				targetPath.Directory.Create_If_NotExists();

				//copy stream content to file.
				using (var fs = targetPath.Open(FileMode.Create, FileAccess.Write))
				{
					fileData.CopyTo(fs);
				}

				//create database entry
				var webServiceFile = Sys.Data.CentralService.WebServiceFiles.NewRow();
				webServiceFile.Id = targetId;
				webServiceFile.Created = webServiceFile.Modified = webServiceFile.Accessed = DateTime.Now;
				webServiceFile.AccessCount = 0;
				webServiceFile.Name = name;
				webServiceFile.Extension = extension;
				webServiceFile.Description = description;
				webServiceFile.FullFilePath = targetPath.FullName;
				webServiceFile.AddToTable();

				Sys.Data.CentralService.SaveAnabolic();

				return webServiceFile.Id;
			}
			catch (Exception)
			{
				//revert changes on error.
				targetPath.Refresh();
				if (targetPath.Exists)
					targetPath.Delete();
				Sys.Data.CentralService.RejectChanges();
				throw;
			}
		}

		/// <summary>Opens the file which was previously saved by the method <see cref="Save" />.</summary>
		/// <param name="id">The id which was returned by the <see cref="Save" /> method.</param>
		public Stream Open(Guid id)
		{
			var wsf = GetFileRow(id);
			var filePath = GetFilePath(wsf);

			wsf.Accessed = DateTime.Now;
			wsf.AccessCount++;

			wsf.DataSet.SaveUnspecific();

			return filePath.Open(FileMode.Open);
		}

		/// <summary>Adds the file informations into the response header.</summary>
		/// <param name="id">The id of the file.</param>
		public void AddFileInfoToResponseHeader(Guid id)
		{
			var wsf = GetFileRow(id);
			HttpContext.Current.Response.AppendHeader(RemoteFileRepository.Headers.FileName, wsf.Name);
			HttpContext.Current.Response.AppendHeader(RemoteFileRepository.Headers.FileId, wsf.Id.ToString());
			HttpContext.Current.Response.AppendHeader(RemoteFileRepository.Headers.FileExtension, wsf.Extension);
			HttpContext.Current.Response.AppendHeader(RemoteFileRepository.Headers.FileDescription, wsf.Description);
		}

		/// <summary>Deleted the file which was previously saved by the method <see cref="Save" />.</summary>
		/// <param name="id">The id which was returned by the <see cref="Save" /> method.</param>
		public void Delete(Guid id)
		{
			var wsf = GetFileRow(id);
			var filePath = GetFilePath(wsf);
			try
			{
				filePath.Delete();
				wsf.Delete();
			}
			finally
			{
				filePath.Refresh();
				if (filePath.Exists)
					Sys.Data.CentralService.RejectChanges();
				else
					Sys.Data.CentralService.SaveKatabolic();
			}
		}

		/// <summary>Lookup the id in the database. Throws error if not exist.</summary>
		/// <param name="id">the file id to gather.</param>
		private WebServiceFile GetFileRow(Guid id)
		{
			var wsf = Sys.Data.CentralService.WebServiceFiles.FindOrLoad(id);
			if (wsf == null)
				throw new FileNotFoundException($"The ID [{id}] was NOT found in the TABLE [{WebServiceFilesTable.NativeName}].");
			return wsf;
		}

		/// <summary>Returns the file path to the entry. If the file does not exist this method throws an error</summary>
		/// <param name="wsf">The file to gather.</param>
		private FileInfo GetFilePath(WebServiceFile wsf)
		{
			var filePath = new FileInfo(wsf.FullFilePath);
			if (!filePath.Exists)
				throw new FileNotFoundException($"The ID [{wsf.Id}] was found in TABLE [{WebServiceFilesTable.NativeName}]. " +
												$"BUT the file could NOT be located at '{filePath.FullName}'. " +
												$"This might be a data integrity error or remote file access error.");
			return filePath;
		}


		/// <summary>The path system for the files. Modify this method if you want another directory system.</summary>
		/// <param name="id">The id of the file</param>
		/// <param name="name">The file name.</param>
		/// <param name="extension">the extension of the file</param>
		private FileInfo GetPathById(Guid id, string name, string extension)
		{
			return new FileInfo(Path.Combine(StorageDirectory.FullName, id.ToString().Substring(0, 2), $"{id} _ {name}.{extension}"));
		}
	}
}