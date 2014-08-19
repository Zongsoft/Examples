using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Zongsoft.Options;
using Zongsoft.Options.Configuration;

namespace Zongsoft.Examples.Options.Configuration
{
	public class SettingOptionElementCollection : OptionConfigurationElementCollection<SettingOptionElement>
	{
		public SettingOptionElementCollection() : base("setting")
		{
		}

		//protected override OptionConfigurationElement CreateNewElement()
		//{
		//    return new SettingOptionElement();
		//}

		//protected override string GetElementKey(OptionConfigurationElement element)
		//{
		//    return ((SettingOptionElement)element).Key;
		//}
	}
}
