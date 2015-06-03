using System;
using System.Collections.Generic;
using System.Linq;
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

        public IEnumerable<Lottery> GetAll()
        {
            return Lotteries;
        }

        public Lottery GetOneById(Guid id)
        {
            return Lotteries.SingleOrDefault(l => l.Id == id);
        }
    }
}
