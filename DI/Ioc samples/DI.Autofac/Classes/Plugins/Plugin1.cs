using System;

namespace DI
{
    public class Plugin1 : IPostOrderPlugin
    {
        void IPostOrderPlugin.DoSomething()
        {
            Console.WriteLine("Plug-in #1 executed.");
        }
    }
}
