using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Configuration;

namespace Tennis
{
	public static class Settings
	{
		public static int MinSets = Int32.Parse (ConfigurationManager.AppSettings ["MinSets"]);
		public static int MinGames = Int32.Parse (ConfigurationManager.AppSettings ["MinGames"]);
		public static bool ApplyTiebreak = (ConfigurationManager.AppSettings ["ApplyTiebreak"] == "true");
	}
}
