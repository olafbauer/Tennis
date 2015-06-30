using System;
using System.Collections.Generic;
using System.Linq;

namespace Tennis
{
	public class GameCounter : ICounter
	{
		public Score CurrentScore (List<Score> scores)
		{
			return Score.SumWithDeuce (scores);
		}

		public bool IsOver (Score score)
		{  
			return score.HasMin (4) && score.HasAdvance (2);
		}

		public string CurrentScoreString (Score s)
		{
			return "Game: " + Score.ScoreStringHuman (s);
		}

		public List<string> ScoreStrings (Game game)
		{
			List<string> strings = Score.GameScoreList (game.GetScores ()).Select (Score.ScoreStringHuman).ToList ();
			return (game.IsOver ()) ? Helper.RemoveLast (strings) : strings;
		}

		public string Header (int set, int game)
		{
			return String.Format ("Set {0}, Game {1}", set, game);
		}
	}
}

