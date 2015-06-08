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
    public class CreateNewParticipantTests
    {
        private ICreateNewParticipant _createNewParticipant;
        private Mock<IParticipantRepository> _participantRepositoryMock;

        [TestInitialize]
        public void TestInitialize()
        {
            _participantRepositoryMock = new Mock<IParticipantRepository>();
            _createNewParticipant = new CreateNewParticipant(_participantRepositoryMock.Object);
        }

        [TestMethod]
        public void CreateNewParticipant_should_add_a_new_Participant_to_the_Repository()
        {
            // Arrange
            
            // Act
            _createNewParticipant.WithFirstAndLastname(string.Empty, string.Empty);

            // Assert
            _participantRepositoryMock.Verify(r => r.Add(It.IsAny<Participant>()), Times.Once);
        }

        [TestMethod]
        public void CreateNewParticipant_should_set_Firstname_correctly()
        {
            // Arrange
            const string firstname = "Hans";
            Participant addedParticipant = null;
            _participantRepositoryMock.Setup(r => r.Add(It.IsAny<Participant>())).Callback<Participant>(p => addedParticipant = p);

            // Act
            _createNewParticipant.WithFirstAndLastname(firstname, string.Empty);

            // Assert
            Assert.AreEqual(firstname, addedParticipant.Firstname);
        }

        [TestMethod]
        public void CreateNewParticipant_should_set_Lastname_correctly()
        {
            // Arrange
            const string lastname = "Wurst";
            Participant addedParticipant = null;
            _participantRepositoryMock.Setup(r => r.Add(It.IsAny<Participant>())).Callback<Participant>(p => addedParticipant = p);

            // Act
            _createNewParticipant.WithFirstAndLastname(string.Empty, lastname);

            // Assert
            Assert.AreEqual(lastname, addedParticipant.Lastname);
        }

        [TestMethod]
        public void CreateNewParticipant_should_set_unique_Id()
        {
            // Arrange
            var addedParticipants = new List<Participant>();
            _participantRepositoryMock.Setup(r => r.Add(It.IsAny<Participant>())).Callback<Participant>(p => addedParticipants.Add(p));

            // Act
            _createNewParticipant.WithFirstAndLastname("Quentin", "Tarantino");
            _createNewParticipant.WithFirstAndLastname("Samuel", "L. Jackson");

            // Assert
            Assert.AreNotEqual(addedParticipants.First().Id, addedParticipants.Last().Id);
        }
    }
}
