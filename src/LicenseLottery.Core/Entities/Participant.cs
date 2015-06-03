using System;

namespace LicenseLottery.Core.Entities
{
    public class Participant
    {
        protected Participant()
        {
        }

        public Guid Id { get; private set; }
        public string Firstname { get; private set; }
        public string Lastname { get; private set; }

        public static Participant New(string firstname, string lastname)
        {
            return new Participant
            {
                Id = Guid.NewGuid(),
                Firstname = firstname,
                Lastname = lastname
            };
        }
    }
}
