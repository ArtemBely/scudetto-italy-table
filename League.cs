
namespace scudetto_italy
{	
    public class League
        {
            private int size;
            public int Id { get; set; }
            public string Name { get; set; }
            public Team[] Club { get; set; }

            public League(int id, string name, Team[] Club)
            {
                Id = id;
                Name = name;
                Club = new Team[size]; 
            }

        }
}