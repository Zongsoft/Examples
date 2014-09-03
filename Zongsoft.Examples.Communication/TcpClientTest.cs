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
	public class TcpClientTest
	{
		#region 私有字段
		private Random _random;
		private TcpClient _client;
		private DirectoryInfo _direcotry;
		#endregion

		#region 构造函数
		public TcpClientTest(string remoteEP)
		{
			_random = new Random();
			_client = new TcpClient(remoteEP);

			_client.Sent += Client_Sent;
			_client.Failed += Client_Failed;
		}

		public TcpClientTest(IPEndPoint remoteEP)
		{
			_random = new Random();
			_client = new TcpClient(remoteEP);

			_client.Sent += Client_Sent;
			_client.Failed += Client_Failed;
		}
		#endregion

		#region 公共属性
		public DirectoryInfo ImagesDirectory
		{
			get
			{
				if(_direcotry == null)
				{
					_direcotry = new DirectoryInfo(Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "images"));

					if(!_direcotry.Exists)
						_direcotry.Create();
				}

				return _direcotry;
			}
		}
		#endregion

		public Package GetPackage()
		{
			Package package = new Package("/Tollgates/VehiclePassing");
			package.Headers.Add(new PackageHeader("Content-Type", "multipart/related"));

			var body = new PackageContent()
			{
				ContentBuffer = Encoding.UTF8.GetBytes(VehiclePassingHelper.GenerateEntityJson()),
			};
			body.Headers.Add(new PackageHeader("Content-Type", "application/json; charset=utf-8"));
			package.Contents.Add(body);

			var files = this.ImagesDirectory.GetFiles("*.jpeg");

			if(files == null || files.Length < 1)
				return package;

			var file = files[_random.Next(0, files.Length - 1)];
			var attachment = new PackageContent()
			{
				ContentStream = File.OpenRead(file.FullName),
			};
			attachment.Headers.Add(new PackageHeader("Content-Disposition", string.Format(@"inline; name=""PanoramaImage"" filename=""{0}""", file.Name)));
			attachment.Headers.Add(new PackageHeader("Content-Type", "image/jpeg"));
			package.Contents.Add(attachment);

			if(files.Length > 1)
			{
				file = files[_random.Next(0, files.Length - 1)];
				attachment = new PackageContent()
				{
					ContentStream = File.OpenRead(file.FullName),
				};
				attachment.Headers.Add(new PackageHeader("Content-Disposition", string.Format(@"inline; name=""FeatureImage"" filename=""{0}""", file.Name)));
				attachment.Headers.Add(new PackageHeader("Content-Type", "image/jpeg"));
				package.Contents.Add(attachment);
			}

			return package;
		}

		public void SendPackage()
		{
			this.SendPackage(this.GetPackage());
		}

		public void SendPackage(Package package)
		{
			if(package == null)
				throw new ArgumentNullException("package");

			using(var stream = new MemoryStream())
			{
				package.Serialize(stream);
				stream.Position = 0;

				_client.Send(stream, stream.Length);
			}
		}

		private void Client_Failed(object sender, ChannelFailureEventArgs e)
		{
			Console.WriteLine("[{0}] TcpClient 发送异常：{1}", e.Channel.ChannelId, e.Exception);
		}

		private void Client_Sent(object sender, SentEventArgs e)
		{
			Console.WriteLine("[{0}] TcpClient 发送成功：{1:N0} 字节。\t\t<发>", e.Channel.ChannelId, e.AsyncState);
		}
	}
}
