using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Zongsoft.Examples.Serialization
{
	public static class Utility
	{
		public static IEnumerable<Models.TreeViewNode> GenerateTreeViewNodes(int depth, int countOfLevel)
		{
			if(depth < 1)
				throw new ArgumentOutOfRangeException("depth");

			if(countOfLevel < 1)
				throw new ArgumentOutOfRangeException("countOfLevel");

			var result = new Models.TreeViewNodeCollection();

			for(int j = 0; j < countOfLevel; j++)
			{
				GenerateNodes(result, 0, j, depth, countOfLevel);
			}

			return result;
		}

		private static void GenerateNodes(Models.TreeViewNodeCollection nodes, int depth, int index, int maxDepth, int countOfLevel)
		{
			var node = new Models.TreeViewNode(Guid.NewGuid().ToString("d"), string.Format("Name <{0}/{1}>", index + 1, depth + 1));
			nodes.Add(node);

			if(depth < maxDepth - 1)
			{
				for(int i = 0; i < countOfLevel; i++)
					GenerateNodes(node.Nodes, depth + 1, i, maxDepth, countOfLevel);
			}
		}
	}
}
