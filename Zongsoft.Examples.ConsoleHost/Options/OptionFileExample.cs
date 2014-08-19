using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Zongsoft.Options;
using Zongsoft.Options.Configuration;

namespace Zongsoft.Examples.ConsoleHost.Options
{
	public class OptionFileExample
	{
		public void Test()
		{
			string filePath = null;

			while(true)
			{
				if(string.IsNullOrWhiteSpace(filePath))
					Console.WriteLine("请输入要查看的配置文件路径：");

				filePath = Console.ReadLine();

				if(!string.IsNullOrWhiteSpace(filePath))
				{
					if(File.Exists(filePath))
						break;
					else
						Console.WriteLine("刚输入的文件路径是不存在的，请重新输入配置文件路径：");
				}
			}

			var optionStorage = OptionConfiguration.Load(filePath);

			foreach(var section in optionStorage.Sections)
			{
				Console.WriteLine();
				Console.WriteLine(new string('-', section.Path.Length + 10));
				Console.WriteLine("Section [{0}]", section.Path);
				Console.WriteLine(new string('-', section.Path.Length + 10));

				foreach(var child in section.Children)
				{
					if(child.Value == null)
						continue;

					if(typeof(OptionConfigurationElementCollection).IsAssignableFrom(child.Value.GetType()))
					{
						Console.Write("{0}: ", child.Key);
						OptionConfigurationHelper.DisplayOptionConfigurationElementCollection((OptionConfigurationElementCollection)child.Value, 0);
					}
					else
					{
						Console.Write("{0}: ", child.Key);
						OptionConfigurationHelper.DisplayOptionConfigurationElement(child.Value, 0);
					}

					Console.WriteLine();
				}
			}
		}
	}
}
