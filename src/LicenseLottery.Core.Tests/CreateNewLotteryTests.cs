using System;
using LicenseLottery.Core.UseCases;
using LicenseLottery.Core.UseCases.Implementations;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;

namespace LicenseLottery.Core.Tests
{
    [TestClass]
    public class CreateNewLotteryTests
    {
        private ICreateNewLottery _createNewLottery;
        private Mock<ILotteryRepository> _lotteryRepositoryMock;

        [TestInitialize]
        public void TestInitialize()
        {
            _lotteryRepositoryMock = new Mock<ILotteryRepository>();
            _createNewLottery = new CreateNewLottery(_lotteryRepositoryMock.Object);
        }

        [TestMethod]
        public void CreateNewLottery_WithName_should_return_a_new_Lottery()
        {
            // Arrange

            // Act
            var lottery = _createNewLottery.WithName(string.Empty);

            // Assert
            Assert.IsNotNull(lottery);
        }

        [TestMethod]
        public void CreateNewLottery_WithName_should_set_name_correctly()
        {
            // Arrange
            const string lotteryName = "My first Lottery";
            
            // Act
            var lottery = _createNewLottery.WithName(lotteryName);

            // Assert
            Assert.AreEqual(lotteryName, lottery.Name);
        }

        [TestMethod]
        public void CreateNewLottery_WithName_should_set_Id_to_an_equal_value()
        {
            // Arrange
            
            // Act
            var lotteryA = _createNewLottery.WithName(string.Empty);
            var lotteryB = _createNewLottery.WithName(string.Empty);

            // Assert
            Assert.AreNotEqual(lotteryA.Id, lotteryB.Id);
        }

        [TestMethod]
        public void CreateNewLottery_WithName_should_set_Finished()
        {
            // Arrange
            
            // Act
            var lottery = _createNewLottery.WithName(string.Empty);

            // Assert
            Assert.IsFalse(lottery.Finished);
        }

        [TestMethod]
        public void CreateNewLottery_WithName_should_set_Winner()
        {
            // Arrange

            // Act
            var lottery = _createNewLottery.WithName("the sunday lottery");

            // Assert
            Assert.IsNull(lottery.Winner);
        }

        [TestMethod]
        public void CreateNewLottery_WithName_should_add_the_created_Lottery_to_Repository()
        {
            // Arrange
            
            // Act
            var lottery = _createNewLottery.WithName(string.Empty);

            // Assert
            _lotteryRepositoryMock.Verify(r => r.Add(lottery), Times.Once);
        }
    }
}
