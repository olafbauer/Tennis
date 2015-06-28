using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tennis
{
	public static class Helper
	{
		public static List<T> RemoveLast<T> (List<T> t)
		{
			return t.GetRange (0, t.Count - 1);
		}
	}
}
