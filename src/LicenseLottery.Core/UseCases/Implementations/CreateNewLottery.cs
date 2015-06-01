using LicenseLottery.Core.Entities;

namespace LicenseLottery.Core.UseCases.Implementations
{
    public class CreateNewLottery : ICreateNewLottery
    {
        private readonly ILotteryRepository _lotteryRepository;

        public CreateNewLottery(ILotteryRepository lotteryRepository)
        {
            _lotteryRepository = lotteryRepository;
        }

        public Lottery WithName(string name)
        {
            var lottery = Lottery.New(name);
            _lotteryRepository.Add(lottery);
            return lottery;
        }
    }
}
