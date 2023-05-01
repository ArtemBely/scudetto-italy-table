using System;
using System.Collections;
using System.Text.RegularExpressions;

namespace scudetto_italy {
    public class StatisticsFileSerializerDeserializer
    {
        private List<Player> players1;
        private string fileName;

        public StatisticsFileSerializerDeserializer(List<Player> players1, string fileName)
        {
            this.players1 = players1;
            this.fileName = fileName;
        }

        public void Save()
        {
            using (StreamWriter sw = new StreamWriter(fileName))
            {
                foreach (Player player in players1.ToArray())
                {
                    string serializedPlayer = Serialize(player);
                    sw.WriteLine(serializedPlayer);
                    Console.WriteLine("Saved player: " + serializedPlayer); // Debug logging
                }
            }
        }

        public List<Player> Load()
        {
        List<Player> loadedPlayers = new List<Player>();
            using (StreamReader sr = new StreamReader(fileName))
            {
                
                while (!sr.EndOfStream)
                {
                    string line = sr.ReadLine();
                    loadedPlayers.Add(Deserialize(line));
                }   
                foreach (Player player in loadedPlayers) // Debug logging
                {
                    Console.WriteLine("Loaded player: " + Serialize(player));
                }
                return loadedPlayers;
            }
        }

        private static string Serialize(Player p)
        {
            return $"{p.Name},{p.LastName},{p.Club},{p.GoalCount},{p.Assist},{p.Scores}";
        }

        private static Player Deserialize(string s)
        {            
            string[] data = Regex.Split(s, ",(?=[^ ])");

            string name = data[0];
            Console.WriteLine(name + " IS name of player");
            string lastname = data[1];
            string clubStr = data[2];
            int goalCount = int.Parse(data[3]);
            int assists = int.Parse(data[4]);
            int scores = int.Parse(data[5]);

            Team club;
            if (!Enum.TryParse(clubStr, out club))
            {
                throw new ArgumentException("Invalid club value in player data");
            }

            return new Player(name, lastname, club, goalCount, assists, scores);
        }

    }
}