using System;
using System.Linq;
using LicenseLottery.Core.Entities;
using LicenseLottery.Core.UseCases;
using LicenseLottery.Core.UseCases.Implementations;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;

namespace LicenseLottery.Core.Tests
{
    [TestClass]
    public class AddParticipantToLotteryTests
    {
        private IAddParticipantToLottery _addParticipantToLottery;
        private Mock<ILotteryRepository> _lotteryRepositoryMock;
        private Mock<IParticipantRepository> _participantRepositoryMock;

        [TestInitialize]
        public void TestInitialize()
        {
            _lotteryRepositoryMock = new Mock<ILotteryRepository>();
            _participantRepositoryMock = new Mock<IParticipantRepository>();
            _addParticipantToLottery = new AddParticipantToLottery(_lotteryRepositoryMock.Object, _participantRepositoryMock.Object);
        }

        [TestMethod]
        public void AddParticipantToLottery_WithIds_should_add_Participant_to_Lottery()
        {
            // Arrange
            var lottery = Lottery.New("6 aus 49");
            _lotteryRepositoryMock.Setup(r => r.GetOneById(lottery.Id)).Returns(lottery);

            var participant = Participant.New("Hans", "Albers");
            _participantRepositoryMock.Setup(r => r.GetOneById(participant.Id)).Returns(participant);

            // Act
            _addParticipantToLottery.WithIds(lottery.Id, participant.Id);

            // Assert
            Assert.IsTrue(lottery.Participants.Contains(participant));
        }

        [TestMethod]
        public void AddParticipantToLottery_should_save_Lottery()
        {
            // Arrange
            var lottery = Lottery.New(string.Empty);
            _lotteryRepositoryMock.Setup(r => r.GetOneById(It.IsAny<Guid>())).Returns(lottery);
            _participantRepositoryMock.Setup(r => r.GetOneById(It.IsAny<Guid>())).Returns(Participant.New(string.Empty, string.Empty));

            // Act
            _addParticipantToLottery.WithIds(Guid.NewGuid(), Guid.NewGuid());

            // Assert
            _lotteryRepositoryMock.Verify(r => r.Save(lottery), Times.Once);
        }

        [TestMethod]
        public void AddParticipantToLottery_should_not_add_a_Participant_twice()
        {
            // Arrange
            var lottery = Lottery.New(string.Empty);
            _lotteryRepositoryMock.Setup(r => r.GetOneById(lottery.Id)).Returns(lottery);

            var participant = Participant.New(string.Empty, string.Empty);
            _participantRepositoryMock.Setup(r => r.GetOneById(participant.Id)).Returns(participant);

            // Act
            _addParticipantToLottery.WithIds(lottery.Id, participant.Id);
            _addParticipantToLottery.WithIds(lottery.Id, participant.Id);

            // Assert
            Assert.AreEqual(1, lottery.Participants.Count);
        }
    }
}
