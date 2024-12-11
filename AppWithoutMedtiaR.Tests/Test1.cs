using AppWithoutMediatR.Application.AddGoat;
using FluentAssertions;

namespace AppWithoutMediatR.Tests
{
    [TestClass]
    public sealed class Test1
    {
        private AddGoatHandler _handler = null!;
        [ClassInitialize]
        public static void ClassInit(TestContext context)
        {
            // This method is called once for the test class, before any tests of the class are run.
        }

        [ClassCleanup]
        public static void ClassCleanup()
        {
            // This method is called once for the test class, after all tests of the class are run.
        }

        [TestInitialize]
        public void TestInit()
        {
            // This method is called before each test method.
            _handler = new AddGoatHandler();
        }

        [TestCleanup]
        public void TestCleanup()
        {
            // This method is called after each test method.
        }

        [TestMethod]
        public async Task TestMethod1()
        {
            var command = new AddGoatCommand("Sample", "Sample Data");
            var response = await _handler.Handle(command);
            response.Should().BeOfType<AddGoatResponse>();
        }
    }
}
