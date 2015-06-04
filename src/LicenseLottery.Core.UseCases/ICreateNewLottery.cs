using LicenseLottery.Core.Entities;

namespace LicenseLottery.Core.UseCases
{
    public interface ICreateNewLottery
    {
        Lottery WithName(string name);
    }
}
