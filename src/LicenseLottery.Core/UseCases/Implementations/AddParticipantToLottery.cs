using System;

namespace LicenseLottery.Core.UseCases.Implementations
{
    public class AddParticipantToLottery : IAddParticipantToLottery
    {
        private readonly ILotteryRepository _lotteryRepository;
        private readonly IParticipantRepository _participantRepository;

        public AddParticipantToLottery(ILotteryRepository lotteryRepository, IParticipantRepository participantRepository)
        {
            _lotteryRepository = lotteryRepository;
            _participantRepository = participantRepository;
        }

        public void WithIds(Guid lotteryId, Guid participantId)
        {
            var lottery = _lotteryRepository.GetOneById(lotteryId);
            var participant = _participantRepository.GetOneById(participantId);

            lottery.AddParticipant(participant);
            _lotteryRepository.Save(lottery);
        }
    }
}
