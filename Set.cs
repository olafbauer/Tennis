using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Configuration;

namespace Tennis
{
	public class Set
	{
		public readonly List<Rally> Games;

		public Set ()
		{
			Games = new List<Rally> ();
		}

		public void Serve (char key)
		{
			NewOrRunningGame ().Serve (key);
		}

		public Rally NewOrRunningGame ()
		{
			return NeedNewGame () ? NewGame () : CurrentGame ();
		}

		public Rally NewGame ()
		{
			Games.Add (IsTiebreak () ? new Tiebreak () as Rally : new Game () as Rally);
			return CurrentGame ();
		}

		public bool NeedNewGame ()
		{
			return Games.Count == 0 || Game.IsOver (Games.Last ());
		}

		public Rally CurrentGame ()
		{
			return Games.Count > 0 ? Games.Last () : null;
		}

		public bool IsTiebreak ()
		{
			return Settings.ApplyTiebreak && Set.CurrentScore (this).BothEqualTo (Settings.MinGames);
		}

		public char GetChar ()
		{
			return Console.ReadKey (true).KeyChar;
		}

		public static bool IsOver (Set set)
		{
			Score score = Set.CurrentScore (set);
			return (score.HasMin (Settings.MinGames) && score.HasAdvance (2)) || (Settings.ApplyTiebreak && score.HasMin (7));
		}

		public static Score CurrentScore (Set set)
		{
			return Score.SumOfWins (set.Games.Where (Game.IsOver).Select (Game.CurrentScore).ToList ());
		}
	}
}
