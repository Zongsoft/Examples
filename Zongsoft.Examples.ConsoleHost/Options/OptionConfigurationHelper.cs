using System;
using System.Reflection;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Zongsoft.Options;
using Zongsoft.Options.Configuration;

namespace Zongsoft.Examples.ConsoleHost.Options
{
	internal static class OptionConfigurationHelper
	{
		public static void DisplayOptionConfigurationElement(OptionConfigurationElement element, int indent)
		{
			if(element == null)
				return;

			string indentText = GetIndentText(indent);

			Console.WriteLine(indentText + element.GetType().FullName);
			Console.WriteLine(indentText + "{");

			var elementProperties = new List<PropertyInfo>();
			var properties = element.GetType().GetProperties(BindingFlags.Instance | BindingFlags.Public | BindingFlags.DeclaredOnly);

			foreach(var property in properties)
			{
				if(!property.CanRead)
					continue;

				if(typeof(OptionConfigurationElement).IsAssignableFrom(property.PropertyType))
				{
					elementProperties.Add(property);
				}
				else
				{
					Console.Write(indentText + "\t");
					Console.WriteLine("{0}({2}) = {1}", property.Name, property.GetValue(element, null), property.PropertyType.Name);
				}
			}

			foreach(var property in elementProperties)
			{
				Console.WriteLine();

				if(typeof(OptionConfigurationElementCollection).IsAssignableFrom(property.PropertyType))
					DisplayOptionConfigurationElementCollection((OptionConfigurationElementCollection)property.GetValue(element, null), indent + 1);
				else
					DisplayOptionConfigurationElement((OptionConfigurationElement)property.GetValue(element, null), indent + 1);
			}

			Console.WriteLine(indentText + "}");
		}

		public static void DisplayOptionConfigurationElementCollection(OptionConfigurationElementCollection collection, int indent)
		{
			if(collection == null)
				return;

			string indentText = GetIndentText(indent);

			Console.WriteLine("{0}{1} ({2})", indentText, collection.GetType().FullName, collection.Count);
			Console.WriteLine(indentText + "[");

			foreach(var item in collection)
			{
				DisplayOptionConfigurationElement(item, indent + 1);
			}

			Console.WriteLine(indentText + "]");
		}

		private static string GetIndentText(int indent)
		{
			if(indent > 0)
				return new string('\t', indent);
			else
				return string.Empty;
		}
	}
}
