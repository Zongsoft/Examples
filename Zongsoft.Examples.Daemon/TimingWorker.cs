using System;
using System.IO;
using System.ComponentModel;
using System.Collections.Generic;
using System.Threading;
using System.Linq;
using System.Text;

using Zongsoft.Services;
using Zongsoft.ComponentModel;
using Zongsoft.Runtime.Serialization;

namespace Zongsoft.Examples.Daemon
{
	[DisplayName("${Text.TimingWorker.Title}")]
	[Description("${Text.TimingWorker.Description}")]
	public class TimingWorker : WorkerBase
	{
		#region 成员字段
		private ApplicationContextBase _applicationContext;
		private Timer _timer;
		private long _count;
		#endregion

		#region 构造函数
		public TimingWorker(ApplicationContextBase applicationContext)
		{
			if(applicationContext == null)
				throw new ArgumentNullException("applicationContext");

			_applicationContext = applicationContext;
		}
		#endregion

		#region 启动操作
		protected override void OnStart(string[] args)
		{
			Interlocked.Exchange(ref _count, 0);

			this.AppendLog("Starting" + Environment.NewLine);

			if(_timer == null)
				_timer = new Timer(OnTick, null, 5000, 5000);

			this.AppendLog("Started" + Environment.NewLine);
		}
		#endregion

		#region 停止操作
		protected override void OnStop(params string[] args)
		{
			this.AppendLog("Stopping" + Environment.NewLine);

			if(_timer != null)
			{
				_timer.Change(Timeout.Infinite, Timeout.Infinite);
				_timer.Dispose();
				_timer = null;
			}

			this.AppendLog("Stopped" + Environment.NewLine);
		}
		#endregion

		#region 私有方法
		private void OnTick(object state)
		{
			this.AppendLog("OnTick");
		}

		private void AppendLog(string message)
		{
			string filePath = Path.Combine(_applicationContext.EnsureDirectory("logs"), "TimerWorker.log");

			filePath = Zongsoft.IO.PathUtility.GetCurrentFilePathWithSerialNo(filePath, currentFilePath =>
			{
				if(!File.Exists(currentFilePath))
					return false;

				FileInfo fileInfo = new FileInfo(currentFilePath);
				return fileInfo.Length >= 1024 * 1024;
			});

			using(var stream = new FileStream(filePath, FileMode.Append, FileAccess.Write, FileShare.Read))
			{
				using(StreamWriter writer = new StreamWriter(stream))
				{
					var count = Interlocked.Increment(ref _count);
					writer.WriteLine(string.Format("#{0} [{1}] {2}", count, DateTime.Now.ToString(), message));
				}
			}
		}
		#endregion
	}
}
