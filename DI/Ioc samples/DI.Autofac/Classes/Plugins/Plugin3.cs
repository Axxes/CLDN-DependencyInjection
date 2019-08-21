using System;

namespace DI
{
    public class Plugin3 : IPostOrderPlugin
    {
        void IPostOrderPlugin.DoSomething()
        {
            Console.WriteLine("Plug-in #3 executed.");
        }
    }
}
