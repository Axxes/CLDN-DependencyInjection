namespace DI.Unity
{
    public class UnityBillingProcessorFactory : IBillingProcessorFactory
    {
        IBillingProcessor IBillingProcessorFactory.GetBillingProcessor()
        {
            return (IBillingProcessor)Program.Container.Resolve(typeof(IBillingProcessor), string.Empty);
        }
    }
}
