﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;

namespace Zongsoft.Examples.Serialization.Models
{
	[Serializable]
	public class TreeViewNode
	{
		#region 成员变量
		private string _name;
		private string _text;
		private string _url;
		private string _icon;
		private string _toolTip;
		private string _description;
		private string _fullPath;
		private int _depth;
		private bool _selected;
		private bool _visible;
		private TreeViewNode _parent;
		private TreeViewNodeCollection _nodes;
		#endregion

		#region 构造函数
		public TreeViewNode(string name, string text) : this(name, text, string.Empty)
		{
		}

		public TreeViewNode(string name, string text, string url)
		{
			if(string.IsNullOrWhiteSpace(name))
				throw new ArgumentNullException("name");

			if(string.IsNullOrWhiteSpace(text))
				throw new ArgumentNullException("text");

			if(name.Contains("/"))
			{
				if(name.Length == 1)
					name = "@";
				else
					throw new ArgumentException();
			}

			_name = name.Trim();
			_text = text;
			_url = url ?? string.Empty;
			_toolTip = string.Empty;
			_description = string.Empty;
			_fullPath = string.Empty;
			_selected = false;
			_visible = true;
			_parent = null;
			_nodes = new TreeViewNodeCollection(this);
		}
		#endregion

		#region 公共属性
		public string Name
		{
			get
			{
				return _name;
			}
		}

		public string Text
		{
			get
			{
				return _text;
			}
			set
			{
				if(string.IsNullOrWhiteSpace(value))
					throw new ArgumentNullException();

				_text = value;
			}
		}

		public string Url
		{
			get
			{
				return _url;
			}
			set
			{
				_url = value ?? string.Empty;
			}
		}

		/// <summary>
		/// 获取或设置图标名称。
		/// </summary>
		public string Icon
		{
			get
			{
				return _icon;
			}
			set
			{
				_icon = value;
			}
		}

		public string ToolTip
		{
			get
			{
				return _toolTip;
			}
			set
			{
				_toolTip = value ?? string.Empty;
			}
		}

		public string Description
		{
			get
			{
				return _description;
			}
			set
			{
				_description = value ?? string.Empty;
			}
		}

		public int Depth
		{
			get
			{
				if(string.IsNullOrEmpty(_fullPath))
				{
					int depth = -1;
					TreeViewNode node = this;

					while(node != null)
					{
						depth++;
						node = node.Parent;
					}

					_depth = depth;
				}

				return _depth;
			}
		}

		public string FullPath
		{
			get
			{
				if(string.IsNullOrEmpty(_fullPath))
				{
					if(_parent == null)
					{
						_fullPath = _name;
					}
					else
					{
						Stack<string> paths = new Stack<string>();
						paths.Push(_name);

						var node = _parent;

						while(node != null)
						{
							paths.Push(node.Name);
							node = node.Parent;
						}

						StringBuilder text = new StringBuilder();

						while(paths.Count > 0)
						{
							text.Append(paths.Pop());

							if(paths.Count > 0)
								text.Append("/");
						}

						_fullPath = text.ToString();
					}
				}

				return _fullPath;
			}
		}

		[DefaultValue(false)]
		public bool Selected
		{
			get
			{
				return _selected;
			}
			set
			{
				_selected = value;
			}
		}

		[DefaultValue(true)]
		public bool Visible
		{
			get
			{
				return _visible;
			}
			set
			{
				_visible = value;
			}
		}

		public TreeViewNode Parent
		{
			get
			{
				return _parent;
			}
			internal set
			{
				if(object.ReferenceEquals(_parent, value))
					return;

				_parent = value;
				_fullPath = string.Empty;
			}
		}

		public TreeViewNodeCollection Nodes
		{
			get
			{
				return _nodes;
			}
		}
		#endregion
	}
}
