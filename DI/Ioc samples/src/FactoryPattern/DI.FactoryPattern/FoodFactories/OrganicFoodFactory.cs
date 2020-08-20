using DI.FactoryPattern.Food;

namespace DI.FactoryPattern.FoodFactories
{
    public class OrganicFoodFactory : IFoodFactory
    {
        public IFood CreateFood()
        {
            return new BioPotatoes();
        }
    }
}