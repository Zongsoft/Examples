using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Zongsoft.Services;
using Zongsoft.Terminals;
using Zongsoft.Runtime.Serialization;

namespace Zongsoft.Examples.Serialization.Commands
{
	[CommandOption("format", Type = typeof(string), DefaultValue = "text")]
	[CommandOption("depth", Type = typeof(int), DefaultValue = 3)]
	[CommandOption("count", Type = typeof(int), DefaultValue = 2)]
	public class SerializeCommand : CommandBase<TerminalCommandContext>
	{
		protected override void Run(TerminalCommandContext context)
		{
			ISerializer serializer;
			string format = (string)context.Options["format"];

			switch(format.ToLowerInvariant())
			{
				case "":
				case "text":
					serializer = Serializer.Text;
					break;
				case "json":
					serializer = Serializer.Json;
					break;
				default:
					throw new NotSupportedException("Cann't obtain serializer format.");
			}

			var target = Utility.GenerateTreeViewNodes((int)context.Options["depth"], (int)context.Options["count"]);

			using(var stream = new MemoryStream())
			{
				serializer.Serialize(stream, target);

				if(stream.Length > 0 && stream.CanSeek)
					stream.Position = 0;

				using(var reader = new StreamReader(stream))
				{
					string line = null;

					while((line = reader.ReadLine()) != null)
					{
						context.Terminal.WriteLine(line);
					}
				}
			}
		}
	}
}
