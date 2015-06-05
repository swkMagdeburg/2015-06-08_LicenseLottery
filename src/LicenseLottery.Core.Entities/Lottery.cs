using System;
using System.Collections.Generic;
using System.Linq;

namespace LicenseLottery.Core.Entities
{
    public class Lottery
    {
        protected Lottery()
        {
            Participants = new List<Participant>();
        }

        public Guid Id { get; private set; }
        public DateTime Date { get; private set; }
        public string Name { get; private set; }
        public bool Finished { get; private set; }
        public string Winner { get; private set; }
        public List<Participant> Participants { get; private set; }

        public static Lottery New(string name)
        {
            return new Lottery
            {
                Id = Guid.NewGuid(),
                Name = name,
                Date = DateTime.Today,
                Finished = false,
                Winner = string.Empty
            };
        }

        public static Lottery Empty()
        {
            return new Lottery { Id = Guid.Empty };
        }

        public void AddParticipant(Participant participant)
        {
            if (Participants.Any(p => p.Id == participant.Id))
            {
                return;
            }
            Participants.Add(participant);
        }
    }
}
