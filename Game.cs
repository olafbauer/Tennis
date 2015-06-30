using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tennis
{
	public class Game
	{
		private ICounter _counter;
		public List<Score> Scores;

		public Game (ICounter counter)
		{
			_counter = counter;
			this.Scores = new List<Score> ();
		}

		public void Serve (char key)
		{
			Scores.Add (Service (key));
		}

		private Score Service (char key)
		{
			return key.Equals ('a') ? new Score (1, 0) : key.Equals ('b') ? new Score (0, 1) : new Score (0, 0);
		}

		public List<Score> GetScores ()
		{
			return Scores;
		}

		public string ScoreString ()
		{
			return _counter.CurrentScoreString (CurrentScore ());
		}

		public string CurrentScoreString ()
		{
			return _counter.CurrentScoreString (CurrentScore ());
		}

		public List<string> ScoreStrings ()
		{
			return _counter.ScoreStrings (this);
		}

		public string Header (int set, int game)
		{
			return _counter.Header (set, game);
		}

		public bool IsOver ()
		{  
			return _counter.IsOver (CurrentScore ());
		}

		public Score CurrentScore ()
		{
			return _counter.CurrentScore (Scores);
		}
	}
}
