using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tennis
{
	public class Tournament
	{
		public List<Match> Matches;
		public Match CurrentMatch;

		public Tournament ()
		{
			Matches = new List<Match> ();
		}

		public void Start ()
		{
			AddNewMatch (); 
			while (true) {
				ProcessUserInput (GetChar);
			}
		}

		public void ProcessUserInput (Func<char> getChar)
		{
			char key = getChar ();
			Console.Clear ();

			switch (key) {
			case 'h':
				UI.DisplayHistory (CurrentMatch);
				break;
			case 'a':
			case 'b':
				CurrentMatch.Continue (key);
				UI.Display (CurrentMatch);
				break;
			case 'i':
				AddNewMatch ();
				break;
			case 's':
				Console.Clear ();
				UI.Scoreboard (CurrentMatch);
				break;
			case 'm':
				Console.Clear ();
				UI.Scoreboard (this);
				break;
			case '0':
			case '1':
			case '2':
			case '3':
			case '4':
			case '5':
			case '6':
			case '7':
			case '8':
			case '9':
				SwitchToMatch (Int32.Parse (key.ToString ()));
				break;
			}
		}

		public void AddNewMatch ()
		{
			CurrentMatch = new Match ();
			Matches.Add (CurrentMatch);
			Console.WriteLine ("New Match " + (Matches.Count - 1));
		}

		public void SwitchToMatch (int num)
		{
			if (num < Matches.Count) {
				Console.WriteLine ("Switching to " + num);
				CurrentMatch = Matches.ElementAt (num);
				UI.Scoreboard (this.CurrentMatch);
			} else {
				Console.WriteLine ("No such game");
			}
		}

		public char GetChar ()
		{
			return Console.ReadKey (true).KeyChar;
		}
	}
}
