using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Net;
using System.Net.Sockets;
using System.Net.NetworkInformation;
using System.Threading;
using Butcher.Payloads;

namespace Butcher
{
	class Program
	{
		private static List<IFireSheepHandlerPayload> _handlerPayloads;

		static void Main(string[] args)
		{
			IPAddress gatewayAddress = null;
			if (args != null && args.Count() == 1)
				gatewayAddress = IPAddress.Parse(args[0]);

			NetworkUtil.Instance.GetGatewayAddress(gatewayAddress);
			LoadHandlerPayloads();

			Console.Write("Sending FireSheep kill requests, press any key to stop.");
			var timer = new System.Timers.Timer();
			timer.Elapsed += new System.Timers.ElapsedEventHandler(Timer_Elapsed);
			timer.Interval = 1000;
			timer.Enabled = true;

			Console.ReadKey();
		}

		static void Timer_Elapsed(object sender, System.Timers.ElapsedEventArgs e)
		{
			int randomIndex = new Random().Next(0, _handlerPayloads.Count());
			NetworkUtil.Instance.SendRequest(_handlerPayloads[randomIndex]);
			Console.Write(".");
		}

		private static void LoadHandlerPayloads()
		{
			if (_handlerPayloads != null)
				return;

			_handlerPayloads = new List<IFireSheepHandlerPayload>();
			_handlerPayloads.Add(new FacebookHandlerPayload());
			_handlerPayloads.Add(new TwitterHandlerPayload());
			_handlerPayloads.Add(new FlickrHandlerPayload());
			_handlerPayloads.Add(new GowallaHandlerPayload());
		}
	}
}
