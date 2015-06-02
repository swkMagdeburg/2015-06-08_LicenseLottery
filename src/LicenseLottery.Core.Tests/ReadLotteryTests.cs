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
    public class ReadLotteryTests
    {
        private Mock<ILotteryRepository> _lotteryRepositoryMock;
        private IReadLottery _readLottery;

        [TestInitialize]
        public void TestInitialize()
        {
            _lotteryRepositoryMock = new Mock<ILotteryRepository>();
            _readLottery = new ReadLottery(_lotteryRepositoryMock.Object);
        }

        [TestMethod]
        public void ReadLottery_All_should_return_all_Lotteries_from_Repository()
        {
            // Arrange
            var existingLotteries = new List<Lottery>
            {
                Lottery.New("6 aus 49"),
                Lottery.New("Glücksspierale"),
                Lottery.New("Spiel77")
            };
            _lotteryRepositoryMock.Setup(r => r.GetAll()).Returns(existingLotteries);

            // Act
            var lotteries = _readLottery.All();

            // Assert
            existingLotteries.ForEach(el => Assert.IsTrue(lotteries.Contains(el), "Lottery {0} should be contained", el.Name));
        }
    }
}
