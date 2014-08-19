using System;
using System.ComponentModel;
using System.Collections.Generic;

namespace Zongsoft.Examples.Communication.Models
{
	public class Department
	{
		/// <summary>
		/// 应用名称
		/// </summary>
		[DisplayName("应用名称")]
		public string ApplicationName
		{
			get;
			set;
		}
		/// <summary>
		/// 数据流水号
		/// </summary>
		[DisplayName("数据流水号")]
		public long DepartmentId
		{
			get;
			set;
		}
		/// <summary>
		/// 单位编号
		/// </summary>
		[DisplayName("单位编号")]
		public string DepartmentNo
		{
			get;
			set;
		}
		/// <summary>
		/// 单位名称
		/// </summary>
		[DisplayName("单位名称")]
		public string Name
		{
			get;
			set;
		}
		/// <summary>
		/// 单位负责人
		/// </summary>
		[DisplayName("单位负责人")]
		public string PricipalId
		{
			get;
			set;
		}
		/// <summary>
		/// 单位电话
		/// </summary>
		[DisplayName("单位电话")]
		public string PhoneNumber
		{
			get;
			set;
		}
		/// <summary>
		/// 传真号
		/// </summary>
		[DisplayName("传真号")]
		public string Fax
		{
			get;
			set;
		}
		/// <summary>
		/// 网站地址
		/// </summary>
		[DisplayName("网站地址")]
		public string WebUrl
		{
			get;
			set;
		}
		/// <summary>
		/// 单位级别
		/// </summary>
		[DisplayName("单位级别")]
		public string Level
		{
			get;
			set;
		}
		/// <summary>
		/// 单位地址
		/// </summary>
		[DisplayName("单位地址")]
		public string Address
		{
			get;
			set;
		}
		/// <summary>
		/// 上级单位
		/// </summary>
		[DisplayName("上级单位")]
		public long ParentId
		{
			get;
			set;
		}
		/// <summary>
		/// 所属区域
		/// </summary>
		[DisplayName("所属区域")]
		public string AreaCode
		{
			get;
			set;
		}
		/// <summary>
		/// 数据来源
		/// </summary>
		[DisplayName("数据来源")]
		public string SourceKind
		{
			get;
			set;
		}
		/// <summary>
		/// 添加者
		/// </summary>
		[DisplayName("添加者")]
		public string Creator
		{
			get;
			set;
		}
		/// <summary>
		/// 添加时间
		/// </summary>
		[DisplayName("添加时间")]
		public DateTime CreatedTime
		{
			get;
			set;
		}
		/// <summary>
		/// 修改者
		/// </summary>
		[DisplayName("修改者")]
		public string Modifier
		{
			get;
			set;
		}
		/// <summary>
		/// 修改时间
		/// </summary>
		[DisplayName("修改时间")]
		public DateTime? ModifiedTime
		{
			get;
			set;
		}
		/// <summary>
		/// 扩展标记
		/// </summary>
		[DisplayName("扩展标记")]
		public string Flags
		{
			get;
			set;
		}
		/// <summary>
		/// 删除标记
		/// </summary>
		[DisplayName("删除标记")]
		public bool Disabled
		{
			get;
			set;
		}
		/// <summary>
		/// 备注
		/// </summary>
		[DisplayName("备注")]
		public string Remark
		{
			get;
			set;
		}
	}
}
