using System;
using System.IO;
using System.Collections.Generic;
using System.Threading;
using System.Linq;
using System.Text;

using Zongsoft.Services;
using Zongsoft.ComponentModel;
using Zongsoft.Runtime.Serialization;

namespace Zongsoft.Examples.Services
{
	public class TimingWorker : WorkerBase
	{
		#region 成员字段
		private ApplicationContextBase _applicationContext;
		private ISerializer _serializer;
		private Timer _timer;
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
			this.AppendLog("Starting" + Environment.NewLine);

			if(_serializer == null)
				_serializer = Zongsoft.Runtime.Serialization.Serializer.Text;

			if(_timer == null)
				_timer = new Timer(OnTick, null, 5000, 5000);

			this.AppendLog("Started" + Environment.NewLine);
		}
		#endregion

		#region 停止操作
		protected override void OnStop()
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
			string filePath = Path.Combine(_applicationContext.EnsureDirectory("logs"), "TimerService.log");

			using(var stream = new FileStream(filePath, FileMode.Append, FileAccess.Write, FileShare.Read))
			{
				_serializer.Serialize(stream, string.Format("[{0}] {1}", DateTime.Now.ToString(), message));
			}
		}
		#endregion
	}
}
