using System;
using System.Collections.Generic;
using System.Linq;
using LicenseLottery.Core.Entities;
using LicenseLottery.Core.UseCases.Implementations;

namespace LicenseLottery.Infrastructure.Database
{
    public class ParticipantRepository : IParticipantRepository
    {
        private static readonly List<Participant> Participants = new List<Participant>
        {
            Participant.New("Uma", "Thurman"),
            Participant.New("Quentin", "Tarantino"),
            Participant.New("Samuel", "L. Jackson"),
            Participant.New("Harvey", "Keitel")
        };

        public void Add(Participant participant)
        {
            Participants.Add(participant);
        }

        public List<Participant> All()
        {
            return Participants;
        }

        public Participant GetOneById(Guid id)
        {
            return Participants.FirstOrDefault(p => p.Id == id);
        }
    }
}
