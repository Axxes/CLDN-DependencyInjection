namespace Locator.Simple
{
    /// <summary>
    /// This interface provides the abstraction for a service locator.
    /// </summary>
    internal interface ISimpleServiceLocator
    {
        void Set<T>(T service);

        T Get<T>();
    }
}
