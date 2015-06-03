﻿using System.Collections.Generic;
using LicenseLottery.Core.Entities;

namespace LicenseLottery.Core.UseCases.Implementations
{
    public interface IParticipantRepository
    {
        void Add(Participant participant);
    }
}
