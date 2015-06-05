using System;

namespace LicenseLottery.Core.Entities
{
    public class Game
    {
        protected Game()
        {
            Id = Guid.NewGuid();
        }

        public Guid Id { get; set; }
        public Participant Home { get; set; }
        public Participant Guest { get; set; }

        public static Game New(Participant home, Participant guest)
        {
            return new Game
            {
                Home = home,
                Guest = guest
            };
        }
    }
}
