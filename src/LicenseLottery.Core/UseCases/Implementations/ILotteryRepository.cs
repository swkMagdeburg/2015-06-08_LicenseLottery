using LicenseLottery.Core.Entities;

namespace LicenseLottery.Core.UseCases.Implementations
{
    internal interface ILotteryRepository
    {
        void Add(Lottery lottery);
    }
}
