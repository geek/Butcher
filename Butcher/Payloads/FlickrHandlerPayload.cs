using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Butcher.Payloads
{
	public class FlickrHandlerPayload : IFireSheepHandlerPayload
	{
		public string Host
		{
			get { return "flickr.com"; }
		}

		public string CookieValue
		{
			get { return string.Format("cookie_session={0};", Guid.NewGuid().ToString().Replace("-", "")); }
		}
	}
}
