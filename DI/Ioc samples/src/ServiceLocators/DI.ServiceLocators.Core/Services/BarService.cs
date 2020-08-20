using DI.ServiceLocators.Core.Services.Abstractions;

namespace DI.ServiceLocators.Core.Services
{
    public class BarService : IBarService
    {
        public string Trim(string input) => input?.Trim();
    }
}