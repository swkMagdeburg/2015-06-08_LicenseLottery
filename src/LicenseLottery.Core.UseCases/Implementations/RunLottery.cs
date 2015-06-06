using System;
using System.Linq;

namespace LicenseLottery.Core.UseCases.Implementations
{
    public class RunLottery : IRunLottery
    {
        private readonly ILotteryRepository _lotteryRepository;

        public RunLottery(ILotteryRepository lotteryRepository)
        {
            _lotteryRepository = lotteryRepository;
        }

        public void CreateNextRound(Guid lotteryId)
        {
            var lottery = _lotteryRepository.GetOneById(lotteryId);
            lottery.CreateNextRound();
            _lotteryRepository.Save(lottery);
        }

        public void PlayNextRound(Guid lotteryId)
        {
            var lottery = _lotteryRepository.GetOneById(lotteryId);
            lottery.Rounds.Last().Play();
            _lotteryRepository.Save(lottery);
        }
    }
}
