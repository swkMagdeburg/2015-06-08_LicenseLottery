using System;

namespace LicenseLottery.Core.Entities
{
    public class Lottery
    {
        protected Lottery()
        {
        }

        public Guid Id { get; private set; }
        public DateTime Date { get; private set; }
        public string Name { get; private set; }
        public bool Finished { get; private set; }
        public string Winner { get; private set; }

        public static Lottery New(string name)
        {
            return new Lottery
            {
                Id = Guid.NewGuid(),
                Name = name,
                Date = DateTime.Today,
                Finished = false,
                Winner = string.Empty
            };
        }

        public static Lottery Empty()
        {
            return new Lottery { Id = Guid.Empty };
        }
    }
}
