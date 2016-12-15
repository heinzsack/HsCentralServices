// Copyright (c) 2016 All rights reserved Christian Sack
// <author>Christian Sack</author>
// <email>christian@sack.at</email>
// <website>christian.sack.at</website>
// <date>2016-09-18</date>

using ErrorLogging;
using RingPlayer24._sys.services.ringPlayerService;
using RingPlayer24._sys.services.ringPlayerService.ringDownloader;

namespace RingPlayer24._sys.services
{
	public class Services
	{
		private RingPlayerService _ringPlayerService;
	public RingPlayerService RingPlayerService => _ringPlayerService ?? (_ringPlayerService = new RingPlayerService());

	}



}