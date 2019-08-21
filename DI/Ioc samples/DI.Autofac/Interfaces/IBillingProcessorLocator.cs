namespace DI
{
    public interface IBillingProcessorLocator
    {
        IBillingProcessor GetBillingProcessor();
    }
}