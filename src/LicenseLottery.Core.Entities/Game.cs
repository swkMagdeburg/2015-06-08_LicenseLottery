using System;
using System.Collections.Generic;
using System.Linq;
using LicenseLottery.Core.Entities.Helper;

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
        public Participant Winner { get; set; }
        public Participant Loser { get; set; }

        public static Game New(Participant home, Participant guest)
        {
            return new Game
            {
                Home = home,
                Guest = guest
            };
        }

        public void Play()
        {
            var participants = new List<Participant> { Home, Guest };
            participants.Shuffle();
            Winner = participants.First();
            Loser = participants.Last();
        }
    }
}
