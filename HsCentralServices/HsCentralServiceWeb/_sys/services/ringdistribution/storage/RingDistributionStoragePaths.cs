// Copyright (c) 2016 All rights reserved Christian Sack
// <author>Christian Sack</author>
// <email>christian@sack.at</email>
// <website>christian.sack.at</website>
// <date>2016-09-20</date>

using System;
using System.IO;
using System.Linq;
using CsWpfBase.Ev.Public.Extensions;
using CsWpfBase.Global.remote.clientIdentification.interfaces;






// ReSharper disable InconsistentNaming

namespace HsCentralServiceWeb._sys.services.ringdistribution.storage
{
	public class RingDistributionStoragePaths
	{
		readonly DirectoryInfo _sourceDir = Sys.Services.RingDistribution.Storage.Directory;
		private DirectoryInfo _currentPlayingRingDirectory;
		private DirectoryInfo _extensionDirectory;
		private DirectoryInfo _ringDirectory;
		public string RingExtension = ".dataset";


		private DirectoryInfo Dir_Ringe_Playing => _currentPlayingRingDirectory ?? (_currentPlayingRingDirectory = new DirectoryInfo(Path.Combine(Dir_Ringe.FullName, "#AKTUELL")));
		private DirectoryInfo Dir_Ringe => _ringDirectory ?? (_ringDirectory = new DirectoryInfo(Path.Combine(_sourceDir.FullName, "Ringe")));
		private DirectoryInfo Dir_Extensions => _extensionDirectory ?? (_extensionDirectory = new DirectoryInfo(Path.Combine(_sourceDir.FullName, "#Extensions")));

		public DirectoryInfo Dir_Ringe_ForComputer(ICsClientInfoComputer computer)
		{
			return new DirectoryInfo(Path.Combine(Dir_Ringe.FullName, $"{computer.Name.ToUpper()} - {computer.Id}"));
		}

		public FileInfo RingFilePath(ICsClientInfoComputer computer, int ringId)
		{
			return new FileInfo(Path.Combine(Dir_Ringe_ForComputer(computer).FullName, ringId + RingExtension));
		}

		public FileInfo PlayingRingFilePath(ICsClientInfoComputer computer, int ringId)
		{
			return new FileInfo(Path.Combine(Dir_Ringe_Playing.FullName, $"{computer.Name.ToUpper()} __ {computer.Id.ToString().ToUpper()} __ {ringId}{RingExtension}"));
		}

		public FileInfo GetExtensionFilePath()
		{
			DirectoryInfo extensionDirectory = Dir_Extensions.Create_If_NotExists();
			FileInfo[] files = extensionDirectory.GetFiles();
			return files.FirstOrDefault(x => x.Name.ToLower().EndsWith("addon.*.dll"));
		}
	}
}