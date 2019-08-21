
namespace Locator.Simple
{
    /// <summary>
    /// This class provides the service locator functionality.
    /// </summary>
    public static class ServiceLocator
    {
        private static readonly ISimpleServiceLocator _locator = new SimpleServiceLocator();

        /// <summary>
        /// Returns the Registered <see cref="T"/> from <see cref="Locator"/>.
        /// </summary>
        public static T GetInstance<T>()
        {
            return _locator.Get<T>();
        }

        /// <summary>
        /// Registers an instance of <see cref="T"/> with <see cref="Locator"/>.
        /// </summary>
        public static void SetInstance<T>(T service)
        {
            _locator.Set<T>(service);
        }

    }
}
