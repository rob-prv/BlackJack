using NUnit.Framework;

namespace BlackJack.Tests
{
    [TestFixture]
    public abstract class Scenario
    {
        [SetUp]
        public void Setup()
        {
            Given();
            When();
        }

        [TearDown]
        public void Teardown()
        {
            TearDown();
        }

        public abstract void Given();

        public abstract void When();
        public abstract void TearDown();
    }
}
