using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Butcher.Payloads
{
	public class FacebookHandlerPayload : IFireSheepHandlerPayload
	{
		public string Host
		{
			get { return "facebook.com"; }
		}

		public string CookieValue
		{
			get { return string.Format("c_user={0}; sid={1}; xs={2};", Guid.NewGuid().ToString().Replace("-", ""), Guid.NewGuid().ToString().Replace("-", ""), Guid.NewGuid().ToString().Replace("-", "")); }
		}
	}
}
