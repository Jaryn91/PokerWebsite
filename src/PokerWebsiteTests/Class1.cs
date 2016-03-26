using Moq;
using PokerWebsite.Core.Domain;
using PokerWebsite.Core.Repositories;
using PokerWebsite.Persistence;
using Xunit;

namespace PokerWebsiteTests
{
    public class Class1
    {
        [Fact]
        public void PassingTest()
        {
            using (var unitOfWork = new UnitOfWork(new ApplicationContext()))
            {
                // Example1
                var players = unitOfWork.Players.GetAll();
            }
            var mock = new Mock<IPlayerRepository>();
            var player = new Player();
            Assert.Equal(4, Add(2, 2));
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
