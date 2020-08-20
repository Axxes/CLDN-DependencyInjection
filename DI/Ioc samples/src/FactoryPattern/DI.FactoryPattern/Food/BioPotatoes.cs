using System.Diagnostics;

namespace DI.FactoryPattern.Food
{
    public class BioPotatoes : IFood
    {
        public void EatIt()
        {
            Debug.WriteLine(
                "Eating Bio Potatoes. Feeling healthy and a nice person.");
        }
    }
}
