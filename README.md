# Butcher

A FireSheep butcher. Inspired by FireShepherd, but written in C#... it sends fairly random requests to make it difficult to block by FireSheep.

Created by:
	* Wyatt Lyon Preul
	
## Building

Grab the source using git.  
	$ git clone https://github.com/wpreul/butcher.git

Build using Visual Studio 2010 with .NET 4.0

## How it works
Butcher will send out requests to your network gateway that when intercepted by FireSheep will disable FireSheep.  It does this by employing the method created with FireShepherd, which is to send a cookie value that FireSheep is unable to parse.  The point of Butcher, however, is to send out fairly random requests to a variety of the handlers that FireSheep supports.  This makes it more difficult for a FireSheep user to filter out the Butcher traffic.  The handler and the request values that are sent are randomly chosen and are different for each request.  Also, the fact that it is sending requests to your internal network gateway should calm concerns about possible DoS scenarios against public sites.  With that being said, you should note that if it cannot determine your gateway IP, it will try and ping an outside server and use the first hop as the gateway.  If this fails, it falls back to using google.com.

There is an optional parameter for overriding the IP to connect to.  For example, to have Butcher connect to 192.168.2.1 run it from the console with like so:
$ Butcher.exe 192.168.2.1

It sends 1 request per second. The requests are very minimal in size, only the http headers that FireSheep uses are sent.

## Install
Simply download and run the exe.  It will detect your gateway IP and start sending requests to it that are intercepted by FireSheep.  

## Running with Mono on Mac OS X
There is an outstanding bug in mono that requires you to specify the gateway IP when executing Butcher.  Here is the bug ticket regarding this issue: https://bugzilla.novell.com/show_bug.cgi?id=594642

Use the following to build and run Butcher
$ xbuild Butcher.xln
$ mono Butcher.exe <IP>

Remember that it needs to connect to non-loopback IP, so don't use 127.0.0.1 to test with.

## License

The MIT License

Copyright (c) 2010 Wyatt Lyon Preul, [http://renaissauce.com](http://renaissauce.com)

Permission is hereby granted, free of charge, to any person obtaining a copy of this software and associated documentation files (the "Software"), to deal in the Software without restriction, including without limitation the rights to use, copy, modify, merge, publish, distribute, sublicense, and/or sell copies of the Software, and to permit persons to whom the Software is furnished to do so, subject to the following conditions:

The above copyright notice and this permission notice shall be included in all copies or substantial portions of the Software.

THE SOFTWARE IS PROVIDED "AS IS", WITHOUT WARRANTY OF ANY KIND, EXPRESS OR IMPLIED, INCLUDING BUT NOT LIMITED TO THE WARRANTIES OF MERCHANTABILITY, FITNESS FOR A PARTICULAR PURPOSE AND NONINFRINGEMENT. IN NO EVENT SHALL THE AUTHORS OR COPYRIGHT HOLDERS BE LIABLE FOR ANY CLAIM, DAMAGES OR OTHER LIABILITY, WHETHER IN AN ACTION OF CONTRACT, TORT OR OTHERWISE, ARISING FROM, OUT OF OR IN CONNECTION WITH THE SOFTWARE OR THE USE OR OTHER DEALINGS IN THE SOFTWARE.