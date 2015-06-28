using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tennis
{
	public class Tiebreak : Rally
	{

		public static List<string> ScoreStrings (Rally tiebreak)
		{
			return Score.ScoreList (tiebreak.Scores).Select (UI.ScoreString).ToList ();
		}

		public static string Header (int set, int game)
		{
			return String.Format ("Set {0}, Tiebreak", set);
		}

		public static bool IsOver (Rally tiebreak)
		{  
			Score score = Tiebreak.CurrentScore (tiebreak);
			return score.HasMin (7) && score.HasAdvance (2);
		}

		public static Score CurrentScore (Rally tiebreak)
		{
			return Score.Sum (tiebreak.Scores);
		}
	}
}
