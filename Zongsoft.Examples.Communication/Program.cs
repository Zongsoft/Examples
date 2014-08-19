using System;
using System.IO;
using System.Net;
using System.Collections.Generic;
using System.Threading;

using Newtonsoft.Json;

using Zongsoft.Communication;
using Zongsoft.Communication.Net;

namespace Zongsoft.Examples.Communication
{
	internal class Program
	{
		internal static void Main(string[] args)
		{
			Console.WriteLine("\t" + new string('*', 30));
			Console.WriteLine("\t卡口车辆通行记录网络转发测试器");
			Console.WriteLine("\t" + new string('*', 30));

			Console.WriteLine();
			IPEndPoint remoteEP = null;

			do
			{
				Console.ForegroundColor = ConsoleColor.DarkYellow;
				Console.Write("请输入远程服务器的IP地址和端口号(ip:port)：");
				Console.ResetColor();

				remoteEP = Zongsoft.Communication.IPEndPointConverter.Parse(Console.ReadLine());
			} while(remoteEP == null);

			var serverTest = new TcpServerTest();
			serverTest.Start();

			var clientTest = new TcpClientTest(remoteEP);

			while(true)
			{
				try
				{
					clientTest.SendPackage();
				}
				catch(Exception ex)
				{
					Console.WriteLine("发生未知异常：{0} [{1}]" + Environment.NewLine + "{2}", ex.GetType().FullName, ex.Source, ex.Message);
				}

				//休息一下接着再搞
				Thread.Sleep(1000);
			}
		}

		private static void SendPackage(Zongsoft.Communication.Package package)
		{
			if(package == null)
				return;

			using(var stream = File.Open(Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "package.bin"), FileMode.Create))
			{
				package.Serialize(stream);

			}
		}

		private static void WritePackage(Zongsoft.Communication.Package package)
		{
			if(package == null)
				return;

			var packetizer = new Zongsoft.Communication.Net.TcpPacketizer();

			using(var stream = File.Open(Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "package.bin"), FileMode.Create))
			{
				package.Serialize(stream);

				stream.Position = 0;
				int index = 0;
				foreach(var buffer in packetizer.Pack(stream))
				{
					using(var fragment = File.OpenWrite(Path.Combine(AppDomain.CurrentDomain.BaseDirectory, string.Format("package.fragment#{0}.bin", index++))))
					{
						fragment.Write(buffer.Value, buffer.Offset, buffer.Count);
					}
				}
			}
		}

		private static void TestPackageSerializer(Package package)
		{
			PackageSerializer serializer = new PackageSerializer();

			SplitPackage(package, "source");

			using(var stream = File.OpenWrite(Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "package.bin")))
			{
				serializer.Serialize(stream, package);
			}

			using(var stream = File.OpenRead(Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "package.bin")))
			{
				var result = serializer.Deserialize(stream);

				SplitPackage((Package)result, "resolved");
			}
		}

		private static void SplitPackage(Package package, string name)
		{
			DirectoryInfo directory = new DirectoryInfo(Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "output"));

			if(!directory.Exists)
				directory.Create();

			int index = 0;
			byte[] buffer = new byte[1024];

			foreach(var content in package.Contents)
			{
				var fileName = string.Format("{0}-content#{1}", name, index++);

				if(content.Headers.Contains("content-type"))
				{
					if(content.Headers["content-type"].Value.Contains("image/jpeg"))
						fileName = fileName + ".jpg";
					else if(content.Headers["content-type"].Value.Contains("text"))
						fileName = fileName + ".txt";
					else if(content.Headers["content-type"].Value.Contains("application/json"))
						fileName = fileName + ".json";
				}

				using(var stream = File.OpenWrite(Path.Combine(directory.FullName, fileName)))
				{
					if(content.ContentBuffer != null)
						stream.Write(content.ContentBuffer, 0, content.ContentBuffer.Length);
					else if(content.ContentStream != null)
					{
						int bytesRead;
						content.ContentStream.Position = 0;

						while((bytesRead = content.ContentStream.Read(buffer, 0, buffer.Length)) > 0)
						{
							stream.Write(buffer, 0, bytesRead);
						}
					}
				}
			}
		}
	}
}
