using System.ServiceModel;

namespace DI.WCF
{
    [ServiceContract]
    public interface ISampleService
    {
        [OperationContract]
        void PerformOperation();
    }
}
