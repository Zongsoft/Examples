using System;
using System.IO;
using System.Collections.Generic;

using Newtonsoft.Json;

using Zongsoft.Examples.Communication.Models;

namespace Zongsoft.Examples.Communication
{
	internal static class VehiclePassingHelper
	{
		#region 私有变量
		private static readonly Random _random = new Random();
		#endregion

		public static string GenerateEntityJson()
		{
			return JsonConvert.SerializeObject(GenerateEntity(), Formatting.Indented);
		}

		public static Models.VehiclePassing GenerateEntity()
		{
			var entity = new VehiclePassing()
			{
				PassingId = Guid.NewGuid(),
				AreaCode = "420104",
				AssetsId = "",
				AssetsName = "",
				CreatedTime = DateTime.Now,
				CrossingId = "420100120000000027",
				CrossingName = "中山大道利济路路口",
				DirectionId = "4201001200000000272",
				DirectionName = "西-中山大道利济路路口",
				IllegalTypeId = "420100120000000003",
				LaneId = "4",
				PlateColorId = "28",
				PlateNo = "00000000",
				PlateTypeId = "2",
				RunSpeed = _random.Next(180),
				SourceKind = "Local",
				SpeedOver = 0,
				Timestamp = DateTime.Now.AddMinutes(-2),
				TollgateId = "420100120000000033",
				TollgateName = "中山大道利济路路口",
				VehicleBrand = "未知品牌",
				VehicleColor = "未知颜色",
				VehicleLength = null,
				VehicleShape = null,
				VehicleTypeId = null,

				DepartmentId = 420104000000,
				Department = new Department()
				{
					ApplicationName = "Citms.PIS",
					DepartmentId = 420104000000,
					DepartmentNo = "420104000000",
					Name = "硚口大队",
					Level = "198",
					ParentId = 420100000000,
					AreaCode = "420100",
					SourceKind = "Local",
					Flags = "C",
					Disabled = false,
				},
			};

			return entity;
		}
	}
}
