using System;
using System.Collections.Generic;
using System.Linq;
using LicenseLottery.Core.Entities;
using LicenseLottery.Core.UseCases.Implementations;

namespace LicenseLottery.Infrastructure.Database
{
    public class LotteryRepository : ILotteryRepository
    {
        private static readonly List<Lottery> Lotteries = new List<Lottery>
        {
            Lottery.New("Softwerkskammer Magdeburg Treffen Nr. 22")
        };

        public void Add(Lottery lottery)
        {
            Lotteries.Add(lottery);
        }

        public List<Lottery> GetAll()
        {
            return Lotteries;
        }

        public Lottery GetOneById(Guid id)
        {
            return Lotteries.SingleOrDefault(l => l.Id == id);
        }

        public void Save(Lottery lottery)
        {
            var existingLottery = Lotteries.FirstOrDefault(l => l.Id == lottery.Id);
            Lotteries.Remove(existingLottery);
            Add(lottery);
        }
    }
}
