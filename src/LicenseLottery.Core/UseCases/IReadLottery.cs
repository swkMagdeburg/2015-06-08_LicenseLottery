﻿using System.Collections.Generic;
using LicenseLottery.Core.Entities;

namespace LicenseLottery.Core.UseCases
{
    public interface IReadLottery
    {
        IEnumerable<Lottery> All();
    }
}