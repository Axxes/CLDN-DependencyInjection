using System.Diagnostics;

namespace DI.FactoryPattern.Food
{
    public class CurlyFries : IFood
    {

        public void EatIt()
        {
            Debug.WriteLine("Eating Curly Fries. How fat can you get!");
        }

    }
}
