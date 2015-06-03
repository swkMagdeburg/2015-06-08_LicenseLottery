using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;

namespace LicenseLottery.Core.Entities
{
    public class Lottery
    {
        private readonly Collection<Participant> _participants;

        protected Lottery()
        {
            _participants = new Collection<Participant>();
        }

        public Guid Id { get; private set; }
        public DateTime Date { get; private set; }
        public string Name { get; private set; }
        public bool Finished { get; private set; }
        public string Winner { get; private set; }

        public IReadOnlyCollection<Participant> Participants
        {
            get { return _participants; }
        }

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
            if (_participants.Any(p => p.Id == participant.Id))
            {
                return;
            }
            _participants.Add(participant);
        }
    }
}
