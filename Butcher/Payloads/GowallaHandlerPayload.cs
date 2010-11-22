using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Butcher.Payloads
{
	public class GowallaHandlerPayload : IFireSheepHandlerPayload
	{
		public string Host
		{
			get { return "gowalla.com"; }
		}

		public string CookieValue
		{
			get { return string.Format("__utma={0};", Guid.NewGuid().ToString().Replace("-", "")); }
		}
	}
}
