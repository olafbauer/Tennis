using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tennis
{
	public static class UI
	{
		public static void DisplayHistory (Match match)
		{
			History.MatchHistory (match).ForEach (set => set.ForEach (game => game.ForEach (score => Console.WriteLine (score))));
		}

		public static void Display (Match match)
		{
			Set set = match.CurrentSet ();
			Game game = set.CurrentGame ();

			if (!game.IsOver ()) {
				UI.Scoreboard (game);
			} else if (!set.IsOver ()) {
				UI.Scoreboard (set);
			} else {
				UI.Scoreboard (match);
			}
		}

		public static void Scoreboard (Tournament t)
		{
			t.Matches.ForEach (UI.Scoreboard);
		}

		public static void Scoreboard (Match m)
		{
			List<Score> scores = m.Sets.Select (s => s.CurrentScore ()).ToList ();
			var range = Enumerable.Range (1, scores.Count);
			List<int> p1 = scores.Select (score => score.a).ToList ();
			List<int> p2 = scores.Select (score => score.b).ToList ();

			if (Match.IsOver (m)) {
				Console.WriteLine (WinString (Match.CurrentScore (m)));
			}

			Console.WriteLine (range.Aggregate ("Set        |", FormatAgg));
			Console.WriteLine ("---------------------------");
			Console.WriteLine (p1.Aggregate ("Player A   |", FormatAgg));
			Console.WriteLine ("---------------------------");
			Console.WriteLine (p2.Aggregate ("Player B   |", FormatAgg));
			Console.WriteLine ("---------------------------");
		}

		public static void Scoreboard (Set set)
		{
			Console.WriteLine (set.CurrentScoreString());
		}

		public static void Scoreboard (Game game)
		{
			String scoreString = game.CurrentScoreString ();
			Console.WriteLine (scoreString);
		}

		public static string FormatAgg (string acc, int i)
		{
			return acc + String.Format (" {0} |", i);
		}

		public static string WinString (Score score)
		{
			return "Winner: Player " + score.Winner ().ToString ().ToUpper () + " with " + score.WinScore ();
		}
	}
}
