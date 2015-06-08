using System;

namespace LicenseLottery.Core.UseCases
{
    public interface IAddParticipantToLottery
    {
        void WithIds(Guid lotteryId, Guid participantId);
    }
}
