using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tennis
{
	public class Rally : IRally
	{
		public List<Score> Scores;

		public Rally ()
		{
			this.Scores = new List<Score> ();
		}

		public void Serve (char key)
		{
			Scores.Add (Rally.Service (key));
		}

		private static Score Service (char key)
		{
			return key.Equals ('a') ? new Score (1, 0) : key.Equals ('b') ? new Score (0, 1) : new Score (0, 0);
		}

	}
}
