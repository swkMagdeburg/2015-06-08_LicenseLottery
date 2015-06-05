using System;

namespace LicenseLottery.Core.UseCases
{
    public interface IRunLottery
    {
        void CreateNextRound(Guid lotteryId);
    }
}
