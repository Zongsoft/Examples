using System;
using System.IO;
using System.Net;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Newtonsoft.Json;

using Zongsoft.Communication;
using Zongsoft.Communication.Net;

namespace Zongsoft.Examples.Communication
{
	public class TcpServerTest
	{
		private TcpServer _server;

		public TcpServerTest()
		{
			_server = new TcpServer();

			_server.Failed += new EventHandler<FailureEventArgs>(Server_Failed);
			_server.Received += new EventHandler<ReceivedEventArgs>(Server_Received);
		}

		public void Start()
		{
			_server.Start();
		}

		public void Stop()
		{
			_server.Stop();
		}

		private void Server_Failed(object sender, FailureEventArgs e)
		{
			Console.WriteLine("[{0}] TcpServer 发生异常：{1}", e.Channel.ChannelId, e.Exception);
		}

		private void Server_Received(object sender, ReceivedEventArgs e)
		{
			var stream = e.ReceivedObject as Stream;

			if(stream == null)
				Console.WriteLine("[{0}] TcpServer 接收完成：{1}", e.Channel.ChannelId, e.ReceivedObject);
			else
				Console.WriteLine("[{0}] TcpServer 接收完成：{1:N0} 字节。\t\t[收]", e.Channel.ChannelId, stream.Length);
		}
	}
}
