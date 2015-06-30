using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tennis
{
	public static class History
	{
		public static List<List<List<string>>> MatchHistory (Match match)
		{
			List<int> range = Enumerable.Range (1, match.Sets.Count).ToList ();
			return range.Zip (match.Sets, (count, set) => SetHistory (count, set)).ToList ();
		}

		public static List<List<string>> SetHistory (int setNum, Set set)
		{
			List<int> range = Enumerable.Range (1, set.Games.Count).ToList ();
			return range.Zip (set.Games, (count, game) => GameHistory (count, game, setNum)).ToList ();
		}

		public static List<string> GameHistory (int gameNum, Game game, int setNum)
		{
			List<string> scoreStrings = game.ScoreStrings ();
			string header = game.Header (setNum, gameNum);

			List<string> history = new List<string> ();
			history.Add (header);
			history.Add ("------");
			history.AddRange (scoreStrings);
			history.Add ("");
			return history;
		}
	}
}

