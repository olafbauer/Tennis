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
		public readonly List<Game> Games;

		public Set ()
		{
			Games = new List<Game> ();
		}

		public void Serve (char key)
		{
			NewOrRunningGame ().Serve (key);
		}

		public Game NewOrRunningGame ()
		{
			return NeedNewGame () ? NewGame () : CurrentGame ();
		}

		public Game NewGame ()
		{
			Games.Add(IsTiebreak() ? new Game(new TiebreakCounter()) : new Game(new GameCounter()));
			return CurrentGame ();
		}

		public bool NeedNewGame ()
		{
			return Games.Count == 0 || Games.Last ().IsOver ();
		}

		public Game CurrentGame ()
		{
			return Games.Count > 0 ? Games.Last () : null;
		}

		public bool IsTiebreak ()
		{
			return Settings.ApplyTiebreak && CurrentScore ().BothEqualTo (Settings.MinGames);
		}

		public bool IsOver ()
		{
			Score score = CurrentScore ();
			return (score.HasMin (Settings.MinGames) && score.HasAdvance (2)) || (Settings.ApplyTiebreak && score.HasMin (7));
		}

		public Score CurrentScore ()
		{
			return Score.SumOfWins (Games.Where (g => g.IsOver ()).Select (g => g.CurrentScore ()).ToList ());
		}

		public string CurrentScoreString ()
		{
			return "Set: " + Score.ScoreString (CurrentScore ());
		}
	}
}
