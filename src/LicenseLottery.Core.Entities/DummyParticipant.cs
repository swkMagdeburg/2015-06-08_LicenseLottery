namespace LicenseLottery.Core.Entities
{
    public class DummyParticipant : Participant
    {
        private static DummyParticipant _instance;

        protected DummyParticipant()
        {
        }

        public static Participant GetDummyInstance()
        {
            return _instance ?? (_instance = new DummyParticipant());
        }
    }
}
