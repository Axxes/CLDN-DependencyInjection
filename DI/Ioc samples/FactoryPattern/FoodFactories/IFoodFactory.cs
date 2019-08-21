using FactoryPattern.Food;

namespace FactoryPattern.FoodFactories
{
    public interface IFoodFactory
    {
        IFood CreateFood();
    }
}