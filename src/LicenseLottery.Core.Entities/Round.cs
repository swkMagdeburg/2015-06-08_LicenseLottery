using System;
using System.Collections.Generic;
using System.Linq;
using LicenseLottery.Core.Entities.Helper;

namespace LicenseLottery.Core.Entities
{
    public class Round
    {
        protected Round()
        {
            Id = Guid.NewGuid();
            Games = new List<Game>();
            Participants = new List<Participant>();
        }

        public Guid Id { get; set; }
        public List<Participant> Participants { get; private set; }
        public List<Game> Games { get; private set; }

        public static Round New(List<Participant> participants)
        {
            var round = new Round();
            participants.ForEach(round.Participants.Add);
            round.CreateGames();
            return round;
        }

        private void CreateGames()
        {
            var pot = new List<Participant>(Participants);
            pot.Shuffle();
            while (pot.Any())
            {
                var home = pot.FetchFirstOrDefault();
                var guest = pot.FetchFirstOrDefault() ?? DummyParticipant.GetDummyInstance();
                Games.Add(Game.New(home, guest));
            }
        }

        public void Play()
        {
            Games.ForEach(game => game.Play());
        }
    }
}
