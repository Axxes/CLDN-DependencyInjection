namespace PoetryReader.Api.Repository
{
    internal class InMemoryPoetryRepository : IPoetryReader
    {
        public string GetAPoem()
        {
            return "If you could read a leaf or tree\r\nyou’d have no need of books.\r\n-- © Alistair Cockburn (1987)";
        }

    }
}
