using System.Linq;
using LicenseLottery.Core.Entities;
using LicenseLottery.Core.UseCases;
using LicenseLottery.Core.UseCases.Implementations;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;

namespace LicenseLottery.Core.Tests.RunLotteryTests
{
    [TestClass]
    public class PlayNextRound
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
            _runLottery.CreateNextRound(_lottery.Id);
        }

        [TestMethod]
        public void RunLottey_PlayNextRound_should_set_Winner_and_Loser_in_the_game()
        {
            // Arrange

            // Act
            _runLottery.PlayNextRound(_lottery.Id);

            // Assert
            var lastRound = _lottery.Rounds.Last();
            lastRound.Games.ForEach(game => Assert.AreNotEqual(game.Winner, game.Loser, "Winner and Loser should not be the same"));
        }

        [TestMethod]
        public void RunLottery_PlayNextRound_should_save_the_Lottery()
        {
            // Arrange

            // Act
            _runLottery.PlayNextRound(_lottery.Id);

            // Assert
            _lotteryRepositoryMock.Verify(r => r.Save(_lottery));
        }

        [TestMethod]
        public void RunLottery_PlayNextRound_should_set_Winner_in_the_last_Round()
        {
            // Arrange
            
            // Act
            _runLottery.PlayNextRound(_lottery.Id);

            // Assert
            Assert.AreEqual(2, _lottery.Rounds.Last().Winners.Count);
        }
    }
}
