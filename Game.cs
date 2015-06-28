using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tennis
{
	public class Game : Rally
	{
		public static List<string> ScoreStrings (Rally game)
		{
			List<string> strings = Score.GameScoreList (game.Scores).Select (UI.ScoreStringHuman).ToList ();
			return (Game.IsOver (game)) ? Helper.RemoveLast (strings) : strings;
		}

		public static string Header (int set, int game)
		{
			return String.Format ("Set {0}, Game {1}", set, game);
		}

		public static bool IsOver (Rally game)
		{  
			if (game.GetType () == typeof(Tiebreak)) {
				return Tiebreak.IsOver (game);
			}
			Score score = Game.CurrentScore (game);
			return score.HasMin (4) && score.HasAdvance (2);
		}

		public static Score CurrentScore (Rally game)
		{
			if (game.GetType () == typeof(Tiebreak)) {
				return Tiebreak.CurrentScore (game);
			}
			return Score.SumWithDeuce (game.Scores);
		}
	}
}
