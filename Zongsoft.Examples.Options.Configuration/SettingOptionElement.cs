using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Zongsoft.Options;
using Zongsoft.Options.Configuration;

namespace Zongsoft.Examples.Options.Configuration
{
	public class SettingOptionElement : OptionConfigurationElement
	{
		[OptionConfigurationProperty("name", OptionConfigurationPropertyBehavior.IsKey)]
		public string Name
		{
			get
			{
				return (string)this["name"];
			}
			set
			{
				this["name"] = value;
			}
		}

		[OptionConfigurationProperty("value")]
		public string Value
		{
			get
			{
				return (string)this["value"];
			}
			set
			{
				this["value"] = value;
			}
		}
	}
}
