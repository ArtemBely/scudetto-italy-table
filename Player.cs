namespace scudetto_italy
{
	public class Player
		{
			public List<Player> playersList = new List<Player>();
			public string Name { get; set; }
			public string LastName { get; set; }
			public Team Club { get; set; }
			public int GoalCount { get; set; }
			public int Assist { get; set; }
			public int Scores { get; set; }

			public Player(string name, string lastname, Team club, int goalCount, int assist, int scores)
			{
				Name = name;
				LastName = lastname;
				Club = club;
				GoalCount = goalCount;
				Assist = assist;
				Scores = scores;
			}
    }
}