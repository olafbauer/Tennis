using System;
using System.Collections.Generic;

namespace Tennis
{
	public interface ICounter
	{
		Score CurrentScore (List<Score> scores);

		bool IsOver (Score score);

		string CurrentScoreString (Score s);

		List<string> ScoreStrings (Game game);

		string Header (int set, int game);
	}
}