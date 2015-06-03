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
    public class ReadParticipantsTests
    {
        private Mock<IParticipantRepository> _participantsRepositoryMock;
        private IReadParticipants _readParticipants;

        [TestInitialize]
        public void TestInitialize()
        {
            _participantsRepositoryMock = new Mock<IParticipantRepository>();
            _readParticipants = new ReadParticipants(_participantsRepositoryMock.Object);
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
            var participants = _readParticipants.All();

            // Assert
            existingParticipants.ForEach(ep => Assert.IsTrue(participants.Contains(ep), "Participant {0} {1} should be contained", ep.Firstname, ep.Lastname));
        }
    }
}
