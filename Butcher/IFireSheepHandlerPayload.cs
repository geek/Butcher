using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Butcher
{
	public interface IFireSheepHandlerPayload
	{
		string Host { get; }
		string CookieValue { get; }
	}
}
