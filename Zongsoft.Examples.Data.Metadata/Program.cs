using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Zongsoft.Data;
using Zongsoft.Data.Metadata;

namespace Zongsoft.Examples.Data.Metadata
{
	class Program
	{
		static void Main(string[] args)
		{
			var resolver = new MetadataFileResolver();
			var metadataFile = resolver.Resolve(@"E:\Zongsoft\Zongsoft.Data\Readme.xml");
		}
	}
}
