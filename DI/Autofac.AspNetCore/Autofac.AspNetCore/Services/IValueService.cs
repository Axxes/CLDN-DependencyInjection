using System.Collections.Generic;

namespace Autofac.AspNetCore.Services
{
    public interface IValuesService
    {
        IEnumerable<string> FindAll();

        string Find(int id);
    }
}
