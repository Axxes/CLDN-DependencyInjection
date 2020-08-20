using System;

namespace DI
{
    public class Plugin2 : IPostOrderPlugin
    {
        void IPostOrderPlugin.DoSomething()
        {
            Console.WriteLine("Plug-in #2 executed.");
        }
    }
}
