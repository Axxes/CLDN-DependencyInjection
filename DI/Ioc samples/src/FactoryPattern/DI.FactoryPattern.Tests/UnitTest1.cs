using DI.FactoryPattern.FoodFactories;
using NUnit.Framework;

namespace DI.FactoryPattern.Tests
{
    public class Tests
    {
        [Test]
        public void CreateSomeFood()
        {
            var factory = CreateFoodFactory();
            var food = factory.CreateFood();

            food.EatIt();
        }

        private static IFoodFactory CreateFoodFactory()
        {
            return new OrganicFoodFactory();
        }
    }
}