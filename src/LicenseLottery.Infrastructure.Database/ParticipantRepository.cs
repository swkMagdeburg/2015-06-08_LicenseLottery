using System;
using System.Collections.Generic;
using System.Linq;
using LicenseLottery.Core.Entities;
using LicenseLottery.Core.UseCases.Implementations;

namespace LicenseLottery.Infrastructure.Database
{
    public class ParticipantRepository : IParticipantRepository
    {
        private static readonly HashSet<Participant> Participants = new HashSet<Participant>();

        public void Add(Participant participant)
        {
            Participants.Add(participant);
        }

        public IEnumerable<Participant> All()
        {
            return Participants;
        }

        public Participant GetOneById(Guid id)
        {
            return Participants.FirstOrDefault(p => p.Id == id);
        }
    }
}
