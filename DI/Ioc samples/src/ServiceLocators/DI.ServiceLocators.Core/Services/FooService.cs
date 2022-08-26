using System;
using DI.ServiceLocators.Core.Services.Abstractions;
using Microsoft.Extensions.DependencyInjection;

namespace DI.ServiceLocators.Core.Services
{
    public class FooService : IFooService
    {
        private readonly IBarService _barService;

        public FooService(IServiceProvider serviceProvider)
        {
            _barService = serviceProvider.GetRequiredService<IBarService>();
        }

        public void Log(string text) => Console.WriteLine(_barService.Trim(text));
    }
}