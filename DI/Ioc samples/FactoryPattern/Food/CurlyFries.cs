using System.Diagnostics;

namespace FactoryPattern.Food
{
    public class CurlyFries : IFood
    {

        public void EatIt()
        {
            Debug.WriteLine("Eating Curly Fries. How fat can you get!");
        }

    }
}
