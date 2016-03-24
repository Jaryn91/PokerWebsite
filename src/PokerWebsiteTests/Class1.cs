using Moq;
using PokerWebsite.Core.Domain;
using PokerWebsite.Core.Repositories;
using Xunit;

namespace PokerWebsiteTests
{
    public class Class1
    {
        [Fact]
        public void PassingTest()
        {
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
