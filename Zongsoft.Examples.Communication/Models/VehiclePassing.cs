using System;
using System.ComponentModel;
using System.Collections.Generic;

namespace Zongsoft.Examples.Communication.Models
{
	public class VehiclePassing
	{
		/// <summary>
		/// 数据流水号
		/// </summary>
		[DisplayName("数据流水号")]
		public Guid PassingId
		{
			get;
			set;
		}

		/// <summary>
		/// 卡口编号
		/// </summary>
		[DisplayName("卡口编号")]
		public string TollgateId
		{
			get;
			set;
		}

		/// <summary>
		/// 卡口名称
		/// </summary>
		[DisplayName("卡口名称")]
		public string TollgateName
		{
			get;
			set;
		}

		/// <summary>
		/// 路口编号
		/// </summary>
		[DisplayName("路口编号")]
		public string CrossingId
		{
			get;
			set;
		}

		/// <summary>
		/// 路口名称
		/// </summary>
		[DisplayName("路口名称")]
		public string CrossingName
		{
			get;
			set;
		}

		/// <summary>
		/// 设备编号
		/// </summary>
		[DisplayName("设备编号")]
		public string AssetsId
		{
			get;
			set;
		}

		/// <summary>
		/// 设备名称
		/// </summary>
		[DisplayName("设备名称")]
		public string AssetsName
		{
			get;
			set;
		}

		/// <summary>
		/// 方向编号
		/// </summary>
		[DisplayName("方向编号")]
		public string DirectionId
		{
			get;
			set;
		}

		/// <summary>
		/// 方向名称
		/// </summary>
		[DisplayName("方向名称")]
		public string DirectionName
		{
			get;
			set;
		}

		/// <summary>
		/// 车道编号
		/// </summary>
		[DisplayName("车道")]
		public string LaneId
		{
			get;
			set;
		}

		/// <summary>
		/// 经过时间
		/// </summary>
		[DisplayName("经过时间")]
		public DateTime Timestamp
		{
			get;
			set;
		}

		/// <summary>
		/// 行驶速度
		/// </summary>
		[DisplayName("行驶速度")]
		public int? RunSpeed
		{
			get;
			set;
		}

		/// <summary>
		/// 车牌号码
		/// </summary>
		[DisplayName("车牌号码")]
		public string PlateNo
		{
			get;
			set;
		}

		/// <summary>
		/// 号牌颜色
		/// </summary>
		[DisplayName("号牌颜色")]
		public string PlateColorId
		{
			get;
			set;
		}

		/// <summary>
		/// 号牌类型
		/// </summary>
		[DisplayName("号牌类型")]
		public string PlateTypeId
		{
			get;
			set;
		}

		/// <summary>
		/// 车辆类型
		/// </summary>
		[DisplayName("车辆类型")]
		public string VehicleTypeId
		{
			get;
			set;
		}

		/// <summary>
		/// 车辆外形
		/// </summary>
		[DisplayName("车辆外形")]
		public string VehicleShape
		{
			get;
			set;
		}

		/// <summary>
		/// 车外廓长
		/// </summary>
		[DisplayName("车外廓长")]
		public string VehicleLength
		{
			get;
			set;
		}

		/// <summary>
		/// 车辆品牌
		/// </summary>
		[DisplayName("车辆品牌")]
		public string VehicleBrand
		{
			get;
			set;
		}

		/// <summary>
		/// 车身颜色
		/// </summary>
		[DisplayName("车身颜色")]
		public string VehicleColor
		{
			get;
			set;
		}

		/// <summary>
		/// 违章标记
		/// </summary>
		[DisplayName("违章标记")]
		public string IllegalTypeId
		{
			get;
			set;
		}

		/// <summary>
		/// 区域代码
		/// </summary>
		[DisplayName("区域代码")]
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
		/// 管辖单位
		/// </summary>
		[DisplayName("管辖单位")]
		public long? DepartmentId
		{
			get;
			set;
		}

		/// <summary>
		/// 管辖单位
		/// </summary>
		public Department Department
		{
			get;
			set;
		}
		/// <summary>
		/// 创建时间
		/// </summary>
		[DisplayName("创建时间")]
		public DateTime CreatedTime
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

		/// <summary>
		/// 超速百分比
		/// </summary>
		[DisplayName("超速百分比")]
		public int? SpeedOver
		{
			get;
			set;
		}
	}
}
