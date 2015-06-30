using System;
using System.Collections.Generic;
using System.Linq;

namespace Tennis
{
	public class TiebreakCounter : ICounter
	{
		public Score CurrentScore (List<Score> scores)
		{
			return Score.Sum (scores);
		}

		public bool IsOver (Score score)
		{  
			return score.HasMin (7) && score.HasAdvance (2);
		}

		public string CurrentScoreString (Score s)
		{
			return Score.ScoreString (s);
		}
						
		public List<string> ScoreStrings (Game tiebreak)
		{
			return Score.ScoreList (tiebreak.GetScores ()).Select (CurrentScoreString).ToList ();
		}

		public string Header (int set, int game)
		{
			return String.Format ("Set {0}, Tiebreak", set);
		}
	}
}

