using LicenseLottery.Core.Entities;

namespace LicenseLottery.Core.UseCases.Implementations
{
    public interface ILotteryRepository
    {
        void Add(Lottery lottery);
    }
}
