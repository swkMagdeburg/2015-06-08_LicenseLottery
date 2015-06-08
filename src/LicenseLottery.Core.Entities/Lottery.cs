using System;
using System.Collections.Generic;
using System.Linq;

namespace LicenseLottery.Core.Entities
{
    public class Lottery
    {
        protected Lottery()
        {
            Participants = new List<Participant>();
            Rounds = new List<Round>();
        }

        public Guid Id { get; private set; }
        public string Name { get; private set; }
        public bool Finished { get; private set; }
        public Participant Winner { get; private set; }
        public List<Participant> Participants { get; private set; }
        public List<Round> Rounds { get; private set; }

        public static Lottery New(string name)
        {
            return new Lottery
            {
                Id = Guid.NewGuid(),
                Name = name,
                Finished = false
            };
        }

        public static Lottery Empty()
        {
            return new Lottery { Id = Guid.Empty };
        }

        public void AddParticipant(Participant participant)
        {
            if (Participants.Any(p => p.Id == participant.Id))
            {
                return;
            }
            Participants.Add(participant);
        }

        public void CreateNextRound()
        {
            RemoveNotPlayedRound();
            var lastRoundOrNull = Rounds.Any() ? Rounds.Last() : null;
            var participantsInNextRound = lastRoundOrNull == null ? Participants : lastRoundOrNull.Winners;
            Rounds.Add(Round.New(participantsInNextRound));
        }

        public void PlayRound()
        {
            var roundToPlay = Rounds.Last();
            roundToPlay.Play();
            FinishLotteryIfPossible();
        }

        private void FinishLotteryIfPossible()
        {
            var lastRound = Rounds.Last();
            if (lastRound.Winners.Count > 1) return;

            Finished = true;
            Winner = lastRound.Winners.First();
        }

        private void RemoveNotPlayedRound()
        {
            Rounds.RemoveAll(r => !r.IsPlayed);
        }
    }
}
