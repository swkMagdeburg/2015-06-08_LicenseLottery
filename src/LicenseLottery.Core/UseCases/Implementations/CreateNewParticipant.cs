using LicenseLottery.Core.Entities;

namespace LicenseLottery.Core.UseCases.Implementations
{
    public class CreateNewParticipant : ICreateNewParticipant
    {
        private readonly IParticipantRepository _participantRepository;

        public CreateNewParticipant(IParticipantRepository participantRepository)
        {
            _participantRepository = participantRepository;
        }

        public void WithFirstAndLastname(string firstname, string lastname)
        {
            _participantRepository.Add(Participant.New(firstname, lastname));
        }
    }
}
