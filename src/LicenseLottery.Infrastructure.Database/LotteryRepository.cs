using System.Collections.Generic;
using LicenseLottery.Core.Entities;
using LicenseLottery.Core.UseCases.Implementations;

namespace LicenseLottery.Infrastructure.Database
{
    public class LotteryRepository : ILotteryRepository
    {
        private static readonly HashSet<Lottery> Lotteries = new HashSet<Lottery>();

        public void Add(Lottery lottery)
        {
            Lotteries.Add(lottery);
        }
    }
}
