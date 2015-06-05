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
    public class CreateNextRoundWithOddAmountOfParticipants
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

            _lotteryRepositoryMock = new Mock<ILotteryRepository>();
            _lotteryRepositoryMock.Setup(r => r.GetOneById(_lottery.Id)).Returns(_lottery);

            _runLottery = new RunLottery(_lotteryRepositoryMock.Object);
        }

        [TestMethod]
        public void RunLottery_CreateNextRound_with_3_Participants_should_add_a_DummyParticipant_as_Guest_to_last_Game()
        {
            // Arrange
            
            // Act
            _runLottery.CreateNextRound(_lottery.Id);

            // Assert
            var lastGuestParticipant = _lottery.Rounds.Last().Games.Last().Guest;
            Assert.IsInstanceOfType(lastGuestParticipant, typeof(DummyParticipant));
        }
    }
}
