using System.Collections.Generic;
using LicenseLottery.Core.Entities;

namespace LicenseLottery.Core.UseCases.Implementations
{
    public class ReadLottery : IReadLottery
    {
        private readonly ILotteryRepository _lotteryRepository;

        public ReadLottery(ILotteryRepository lotteryRepository)
        {
            _lotteryRepository = lotteryRepository;
        }

        public IEnumerable<Lottery> All()
        {
            return _lotteryRepository.GetAll();
        }
    }
}
