using DI.Essentials.Abstraction;
using DI.Essentials.Abstraction.Interfaces;
using Moq;
using NUnit.Framework;

namespace DI.Essentials.Tests
{
    public class UnitTest1
    {
        [Test]
        public void TestMethod1()
        {
            var mockBilling =
                new Mock<IBillingProcessor>();

            var mockCustomer =
                new Mock<ICustomer>();

            var mockNotifier =
                new Mock<INotifier>();

            var mockLogger =
                new Mock<ILogger>();

            var commerce = new Commerce(mockBilling.Object,
                mockCustomer.Object,
                mockNotifier.Object,
                mockLogger.Object);

            commerce.ProcessOrder(new OrderInfo());

            mockBilling.Verify(processor => processor.ProcessPayment(It.IsAny<string>(), It.IsAny<string>(), It.IsAny<double>()), Times.Once);
        }
    }
}