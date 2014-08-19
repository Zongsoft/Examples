using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Zongsoft.Examples.Options.Configuration
{
	public class UseOptionElementExample
	{
		private GeneralOptionElement _general;

		public GeneralOptionElement General
		{
			get
			{
				return _general;
			}
			set
			{
				_general = value;
			}
		}

		public override string ToString()
		{
			if(_general == null)
				return base.ToString();

			StringBuilder text = new StringBuilder(_general.GetType().FullName);
			text.AppendLine();
			text.AppendFormat("Int32Property = {0}", _general.Int32Property);
			text.AppendFormat("DateTimeProperty = {0}", _general.DateTimeProperty);
			text.AppendFormat("TextProperty = {0}", _general.TextProperty);
			text.AppendLine();

			foreach(CmdletOptionElement cmdlet in _general.Cmdlets)
			{
				text.AppendFormat("Cmdlet({0}[{1}])" + Environment.NewLine + "{2}", cmdlet.Name, cmdlet.CommandType, cmdlet.Text);
				text.AppendLine();
			}

			if(_general.Settings.Count > 0)
			{
				text.AppendLine();
				text.AppendLine("***** Settings[" + _general.Settings.Count + "] *****");

				foreach(SettingOptionElement setting in _general.Settings)
				{
					text.AppendFormat("{0} = {1}", setting.Name, setting.Value);
				}
			}

			return text.ToString();
		}
	}
}
