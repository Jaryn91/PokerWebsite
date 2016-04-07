using Microsoft.Data.Entity;
using Moq;
using PokerWebsite.Core.Domain;
using PokerWebsite.Core.Repositories;
using PokerWebsite.Persistence;
using PokerWebsite.Persistence.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using Xunit;

namespace PokerWebsiteTests
{
    public class Class1
    {
        [Fact]
        public void PassingTest()
        {
            var data = TestContext.GetTestContext();

            var mockSet = new Mock<DbSet<Player>>();
            mockSet.As<IQueryable<Player>>().Setup(m => m.Provider).Returns(data.Provider);
            mockSet.As<IQueryable<Player>>().Setup(m => m.Expression).Returns(data.Expression);
            mockSet.As<IQueryable<Player>>().Setup(m => m.ElementType).Returns(data.ElementType);
            mockSet.As<IQueryable<Player>>().Setup(m => m.GetEnumerator()).Returns(data.GetEnumerator());

            var mockContext = new Mock<ApplicationContext>();
            mockContext.Setup(m => m.Set<Player>()).Returns(mockSet.Object);

            var service = new PlayerRepository(mockContext.Object);
            var playersStatistics = service.GetTopSeasonPlayers(2016, 1, 10);
        }

        [Fact]
        public void FailingTest()
        {
            Assert.Equal(5, Add(2, 2));
        }

        int Add(int x, int y)
        {
            return x + y;
        }
    }


}
