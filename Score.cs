using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tennis
{
	public class Score
	{
		public readonly int a;
		public readonly int b;

		public Score (int a, int b)
		{
			this.a = a;
			this.b = b;
		}

		public Score (Score score)
		{
			this.a = score.a;
			this.b = score.b;
		}

		public Score Deuce ()
		{
			return this.a > 2 && this.a == this.b ? new Score (4, 4) : new Score (this);
		}

		public static Score Add (Score first, Score second)
		{
			return new Score (first.a + second.a, first.b + second.b);
		}

		public static Score Sum (List<Score> scores)
		{
			return new Score (scores.Aggregate (new Score (0, 0), Add));
		}

		public static Score AddWithDeuce (Score first, Score second)
		{
			return Add (first, second).Deuce ();
		}

		public static Score SumWithDeuce (List<Score> scores)
		{
			return new Score (scores.Aggregate (new Score (0, 0), AddWithDeuce));
		}

		public static Score AddWin (Score counter, Score score)
		{
			return (score.a > score.b) ? new Score (counter.a + 1, counter.b) : new Score (counter.a, counter.b + 1);
		}

		public static Score SumOfWins (List<Score> scores)
		{
			return new Score (scores.Aggregate (new Score (0, 0), AddWin));
		}

		public static List<Score> ScoreList (List<Score> scores)
		{
			List<Score> list = scores.Aggregate (new List<Score> () { new Score (0, 0) }, AddToScores);
			list.RemoveAt (0);
			return list;
		}

		public static List<Score> AddToScores (List<Score> list, Score score)
		{
			list.Add (Add (list.Last (), score));
			return list;
		}

		public static List<Score> GameScoreList (List<Score> scores)
		{
			List<Score> list = scores.Aggregate (new List<Score> () { new Score (0, 0) }, AddToGameScores);
			list.RemoveAt (0);
			return list;
		}

		public static List<Score> AddToGameScores (List<Score> list, Score score)
		{
			list.Add (AddWithDeuce (list.Last (), score));
			return list;
		}

		public bool HasMin (int minPoints)
		{
			return Max () >= minPoints;
		}

		public bool HasAdvance (int advance)
		{
			return this.a >= this.b + advance || this.b >= this.a + advance;
		}

		public int Max ()
		{
			return this.a > this.b ? this.a : this.b;
		}

		public char Winner ()
		{
			return this.a > this.b ? 'a' : 'b';
		}

		public string WinScore ()
		{
			return this.a > this.b ? this.a + " : " + this.b : this.b + " : " + this.a;
		}

		public bool BothEqualTo (int minGames)
		{
			return (this.a == this.b) && (this.a == minGames);
		}

		public override bool Equals (object obj)
		{
			Score o = obj as Score;
			return (this.a == o.a) && (this.b == o.b);
		}

		public override int GetHashCode ()
		{
			return base.GetHashCode ();
		}

	}
}
