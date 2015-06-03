using System.Collections.Generic;
using LicenseLottery.Core.Entities;

namespace LicenseLottery.Core.UseCases.Implementations
{
    public class ReadParticipants : IReadParticipants
    {
        private readonly IParticipantRepository _participantRepository;

        public ReadParticipants(IParticipantRepository participantRepository)
        {
            _participantRepository = participantRepository;
        }

        public IEnumerable<Participant> All()
        {
            return _participantRepository.All();
        }
    }
}
