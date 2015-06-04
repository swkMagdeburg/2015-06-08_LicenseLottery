namespace LicenseLottery.Core.UseCases
{
    public interface ICreateNewParticipant
    {
        void WithFirstAndLastname(string firstname, string lastname);
    }
}
