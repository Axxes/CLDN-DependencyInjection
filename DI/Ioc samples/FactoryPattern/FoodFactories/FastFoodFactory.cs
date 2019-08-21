using FactoryPattern.Food;

namespace FactoryPattern.FoodFactories
{
    public class FastFoodFactory : IFoodFactory
    {
        public IFood CreateFood()
        {
            return new CurlyFries();
        }
    }
}