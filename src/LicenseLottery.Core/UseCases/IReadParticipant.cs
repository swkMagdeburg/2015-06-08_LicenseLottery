using System;
using System.Collections.Generic;
using LicenseLottery.Core.Entities;

namespace LicenseLottery.Core.UseCases
{
    public interface IReadParticipant
    {
        IEnumerable<Participant> All();
        Participant WithId(Guid id);
    }
}
