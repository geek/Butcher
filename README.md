# Butcher

A FireSheep butcher. Inspired by FireShepherd, but written in C#... it sends fairly random requests to make it difficult to block by FireSheep.

Created by:
	* Wyatt Lyon Preul
	
## Building

Grab the source using git.  
	$ git clone https://github.com/wpreul/butcher.git

Build using Visual Studio 2010 with .NET 4.0

## How it works
Butcher will send out requests to your network gateway that when intercepted by FireSheep will disable FireSheep.  It does this by employing the method created with FireShepherd, which is to send a cookie value that FireSheep is unable to parse.  The point of Butcher, however, is to send out fairly random requests to a variety of the handlers that FireSheep supports.  This makes it more difficult for a FireSheep user to filter out the Butcher traffic.  The handler and the request values that are sent are randomly chosen and are different for each request.  Also, the fact that it is sending requests to your internal network gateway should calm concerns about possible DoS scenarios against public sites.  With that being said, you should note that if it cannot determine your gateway IP, it will try and ping an outside server and use the first hop as the gateway.  If this fails, it falls back to using google.com.  If there is any demand for it, I can add an optional parameter for a user to override the IP to use to connect to for sending requests to.

It sends 1 request per second. The requests are very minimal in size, only the http headers that FireSheep uses are sent.

## Install
Simply download and run the exe.  It will detect your gateway IP and start sending requests to it that are intercepted by FireSheep.  