using System;
using System.Collections.Generic;
using System.Linq;
using LicenseLottery.Core.Entities;
using LicenseLottery.Core.UseCases;
using LicenseLottery.Core.UseCases.Implementations;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;

namespace LicenseLottery.Core.Tests
{
    [TestClass]
    public class ReadParticipantTests
    {
        private Mock<IParticipantRepository> _participantsRepositoryMock;
        private IReadParticipant _readParticipant;

        [TestInitialize]
        public void TestInitialize()
        {
            _participantsRepositoryMock = new Mock<IParticipantRepository>();
            _readParticipant = new ReadParticipant(_participantsRepositoryMock.Object);
        }

        [TestMethod]
        public void ReadParticipants_All_should_return_all_Participants_from_Repository()
        {
            // Arrange
            var existingParticipants = new List<Participant>
            {
                Participant.New("Uma", "Thurman"),
                Participant.New("Bruce", "Willis"),
                Participant.New("John", "Travolta")
            };
            _participantsRepositoryMock.Setup(r => r.All()).Returns(existingParticipants);

            // Act
            var participants = _readParticipant.All();

            // Assert
            existingParticipants.ForEach(ep => Assert.IsTrue(participants.Contains(ep), "Participant {0} {1} should be contained", ep.Firstname, ep.Lastname));
        }

        [TestMethod]
        public void ReadParticipants_WithId_should_return_Participant_from_Repository()
        {
            // Arrange
            var existingParticipant = Participant.New(string.Empty, string.Empty);
            _participantsRepositoryMock.Setup(r => r.GetOneById(existingParticipant.Id)).Returns(existingParticipant);

            // Act
            var participant = _readParticipant.WithId(existingParticipant.Id);

            // Assert
            Assert.AreEqual(existingParticipant, participant);
        }

        [TestMethod]
        public void ReadParticipant_WithId_should_return_empty_Participant_when_Id_does_not_exists_in_Repository()
        {
            // Arrange
            _participantsRepositoryMock.Setup(r => r.GetOneById(It.IsAny<Guid>())).Returns<Participant>(null);

            // Act
            var lottery = _readParticipant.WithId(Guid.NewGuid());

            // Assert
            Assert.AreEqual(Guid.Empty, lottery.Id);
        }
    }
}
