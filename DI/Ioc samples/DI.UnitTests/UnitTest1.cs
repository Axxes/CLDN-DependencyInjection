using DI.Abstraction;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;

namespace UnitTestProject1
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void TestMethod1()
        {
            Mock<IBillingProcessor> mockBilling =
                new Mock<IBillingProcessor>();

            Mock<ICustomer> mockCustomer =
                new Mock<ICustomer>();

            Mock<INotifier> mockNotifier =
                new Mock<INotifier>();

            Mock<ILogger> mockLogger =
                new Mock<ILogger>();

            Commerce commerce = new Commerce(mockBilling.Object,
                                             mockCustomer.Object,
                                             mockNotifier.Object,
                                             mockLogger.Object);

            commerce.ProcessOrder(new OrderInfo());

            mockBilling.Verify(processor => processor.ProcessPayment(It.IsAny<string>(), It.IsAny<string>(), It.IsAny<double>()), Times.Once);
        }
    }
}
