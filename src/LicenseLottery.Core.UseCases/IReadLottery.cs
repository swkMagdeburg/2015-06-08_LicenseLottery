using System;
using System.Collections.Generic;
using LicenseLottery.Core.Entities;

namespace LicenseLottery.Core.UseCases
{
    public interface IReadLottery
    {
        List<Lottery> All();
        Lottery WithId(Guid id);
    }
}
