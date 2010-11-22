using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Butcher.Payloads
{
	public class TwitterHandlerPayload : IFireSheepHandlerPayload
	{
		public string Host
		{
			get { return "twitter.com"; }
		}

		public string CookieValue
		{
			get { return string.Format("_twitter_sess={0}; auth_token={1};", Guid.NewGuid().ToString().Replace("-", ""), Guid.NewGuid().ToString().Replace("-", "")); }
		}
	}
}
