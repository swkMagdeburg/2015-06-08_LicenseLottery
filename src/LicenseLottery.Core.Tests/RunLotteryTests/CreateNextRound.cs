using System.Collections.Generic;
using System.Linq;
using LicenseLottery.Core.Entities;
using LicenseLottery.Core.UseCases;
using LicenseLottery.Core.UseCases.Implementations;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;

namespace LicenseLottery.Core.Tests.RunLotteryTests
{
    [TestClass]
    public class CreateNextRound
    {
        private Lottery _lottery;
        private Mock<ILotteryRepository> _lotteryRepositoryMock;
        private IRunLottery _runLottery;

        [TestInitialize]
        public void TestInitialize()
        {
            _lottery = Lottery.New(string.Empty);
            _lottery.AddParticipant(Participant.New("Uma", "Thurman"));
            _lottery.AddParticipant(Participant.New("Quentin", "Tarantino"));
            _lottery.AddParticipant(Participant.New("Samuel", "L. Jackson"));
            _lottery.AddParticipant(Participant.New("Harvey", "Keitel"));

            _lotteryRepositoryMock = new Mock<ILotteryRepository>();
            _lotteryRepositoryMock.Setup(r => r.GetOneById(_lottery.Id)).Returns(_lottery);

            _runLottery = new RunLottery(_lotteryRepositoryMock.Object);
        }

        [TestMethod]
        public void RunLottery_CreateNextRound_should_create_a_new_round_with_2_games()
        {
            // Arrange

            // Act
            _runLottery.CreateNextRound(_lottery.Id);

            // Assert
            Assert.AreEqual(1, _lottery.Rounds.Count, "a new Round should be created");
        }

        [TestMethod]
        public void RunLottery_CreateNextRound_should_set_Participants_in_new_round()
        {
            // Arrange

            // Act
            _runLottery.CreateNextRound(_lottery.Id);

            // Assert
            var round = _lottery.Rounds.First();
            Assert.AreEqual(0, _lottery.Participants.Except(round.Participants).Count());
        }

        [TestMethod]
        public void RunLottery_CreateNextRound_should_create_Games_in_first_Round()
        {
            // Arrange
            
            // Act
            _runLottery.CreateNextRound(_lottery.Id);

            // Assert
            var round = _lottery.Rounds.First();
            Assert.AreEqual(2, round.Games.Count, "there should be 2 games");

            var participantsInGames = new List<Participant>();
            round.Games.ForEach(g =>
            {
                participantsInGames.Add(g.Home);
                participantsInGames.Add(g.Guest);
            });

            Assert.AreEqual(0, _lottery.Participants.Except(participantsInGames).Count());
        }


        [TestMethod]
        public void RunLottery_CreateNextRound_should_save_the_Lottery()
        {
            // Arrange

            // Act
            _runLottery.CreateNextRound(_lottery.Id);

            // Assert
            _lotteryRepositoryMock.Verify(r => r.Save(_lottery), Times.Once);
        }

    }
}
