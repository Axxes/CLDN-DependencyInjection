using DI.FactoryPattern.Food;

namespace DI.FactoryPattern.FoodFactories
{
    public class FastFoodFactory : IFoodFactory
    {
        public IFood CreateFood()
        {
            return new CurlyFries();
        }
    }
}