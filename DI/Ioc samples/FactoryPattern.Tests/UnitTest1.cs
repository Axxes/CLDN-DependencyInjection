using FactoryPattern.Food;
using FactoryPattern.FoodFactories;
using FactoryPattern.Tests.Properties;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Linq;
using System.Reflection;

namespace FactoryPattern.Tests
{
    [TestClass]
    public class FoodFactoryTests
    {
        [TestMethod]
        public void CreateSomeFood()
        {
            IFoodFactory factory = CreateFoodFactory();
            IFood food = factory.CreateFood();

            food.EatIt();
        }

        private IFoodFactory CreateFoodFactory()
        {
            string factoryName = Settings.Default.FoodFactory.Trim();
            Assembly assembly = Assembly.Load(factoryName.Split('.').First());
            object instance = assembly.CreateInstance(factoryName);

            return (IFoodFactory)instance;
        }
    }
}
