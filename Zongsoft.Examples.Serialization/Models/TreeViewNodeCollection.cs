using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;

namespace Zongsoft.Examples.Serialization.Models
{
	public class TreeViewNodeCollection : Zongsoft.Collections.NamedCollectionBase<TreeViewNode>
	{
		#region 同步变量
		private readonly object _syncRoot;
		#endregion

		#region 成员变量
		private TreeViewNode _owner;
		#endregion

		#region 构造函数
		public TreeViewNodeCollection() : base(StringComparer.OrdinalIgnoreCase)
		{
			_owner = null;
			_syncRoot = new object();
		}

		internal TreeViewNodeCollection(TreeViewNode owner) : base(StringComparer.OrdinalIgnoreCase)
		{
			if(owner == null)
				throw new ArgumentNullException("owner");

			_owner = owner;
			_syncRoot = new object();
		}
		#endregion

		#region 公共属性
		public TreeViewNode Owner
		{
			get
			{
				return _owner;
			}
		}
		#endregion

		#region 重写方法
		protected override string GetKeyForItem(TreeViewNode item)
		{
			return item.Name;
		}

		protected override void SetItem(int index, TreeViewNode item)
		{
			if(item == null)
				throw new ArgumentNullException("item");

			if(item.Parent != null)
				throw new ArgumentException();

			item.Parent = _owner;

			//调用基类同名方法
			base.SetItem(index, item);
		}

		protected override void InsertItem(int index, TreeViewNode item)
		{
			if(item == null)
				throw new ArgumentNullException("item");

			if(item.Parent != null)
				throw new ArgumentException();

			item.Parent = _owner;

			//使用同步锁，以确保不与删除和清除方法冲突
			lock(_syncRoot)
			{
				//调用基类同名方法
				base.InsertItem(index, item);
			}
		}

		protected override void RemoveItem(int index)
		{
			lock(_syncRoot)
			{
				var item = base[index];

				if(item != null)
					item.Parent = null;

				//调用基类同名方法
				base.RemoveItem(index);
			}
		}

		protected override void ClearItems()
		{
			lock(_syncRoot)
			{
				foreach(var item in base.Items)
				{
					if(item != null)
						item.Parent = null;
				}

				//调用基类同名方法
				base.ClearItems();
			}
		}
		#endregion
	}
}
