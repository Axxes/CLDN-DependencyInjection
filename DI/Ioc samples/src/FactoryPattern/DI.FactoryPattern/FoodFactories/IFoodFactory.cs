using DI.FactoryPattern.Food;

namespace DI.FactoryPattern.FoodFactories
{
    public interface IFoodFactory
    {
        IFood CreateFood();
    }
}