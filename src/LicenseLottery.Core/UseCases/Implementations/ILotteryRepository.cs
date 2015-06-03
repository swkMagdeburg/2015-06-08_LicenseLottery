using System;
using System.Collections.Generic;
using LicenseLottery.Core.Entities;

namespace LicenseLottery.Core.UseCases.Implementations
{
    public interface ILotteryRepository
    {
        void Add(Lottery lottery);
        IEnumerable<Lottery> GetAll();
        Lottery GetOneById(Guid id);
        void Save(Lottery lottery);
    }
}
