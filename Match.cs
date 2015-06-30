using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tennis
{
	public class Match
	{
		public readonly List<Set> Sets;

		public Match ()
		{
			this.Sets = new List<Set> ();
		}

		public void Continue (char key)
		{
			if (!Match.IsOver (this)) {
				Serve (key);
			}
		}

		public void Serve (char key)
		{
			NewOrRunningSet ().Serve (key);
		}

		public Set NewOrRunningSet ()
		{
			return NeedNewSet () ? NewSet () : CurrentSet ();
		}

		public Set NewSet ()
		{
			Sets.Add (new Set ());
			return CurrentSet ();
		}

		public bool NeedNewSet ()
		{
			return Sets.Count == 0 || Sets.Last ().IsOver ();
		}

		public Set CurrentSet ()
		{
			return Sets.Count > 0 ? Sets.Last () : null;
		}

		public static bool IsOver (Match match)
		{
			return Match.CurrentScore (match).HasMin (Settings.MinSets);
		}

		public static Score CurrentScore (Match match)
		{
			return Score.SumOfWins (match.Sets.Where (s => s.IsOver ()).Select (s => s.CurrentScore ()).ToList ());
		}
	}
}
