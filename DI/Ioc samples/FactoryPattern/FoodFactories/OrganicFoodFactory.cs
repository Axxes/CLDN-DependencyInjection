using FactoryPattern.Food;

namespace FactoryPattern.FoodFactories
{
    public class OrganicFoodFactory : IFoodFactory
    {
        public IFood CreateFood()
        {
            return new BioPotatoes();
        }
    }
}