namespace scudetto_italy
{
	public class ClubStats
		{
			public Team Club { get; set; }
			public int GoalCount { get; set; }
			public int Assist { get; set; }
			public int Scores { get; set; }

			public ClubStats(Team club, int goalCount, int assist, int scores)
			{
				Club = club;
				GoalCount = goalCount;
				Assist = assist;
				Scores = scores;
			}
    }
}