using HexagonalThis.Domain;
using HexagonalThis.Infra;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using NFluent;
using NSubstitute;

namespace HexagonalThis.Tests
{
    [TestClass]
    public class AcceptanceTests
    {
        [TestMethod]
        public void Should_give_verses_when_asked_for_poetry()
        {
            //The Test is the first driver, only the inside of the hexagon is tested here no left or right side adapters
            IRequestVerses poetryReader = new PoetryReader();

            var verses = poetryReader.GiveMeSomePoetry();

            Check.That(verses).IsEqualTo("If you could read a leaf or tree\r\nyou’d have no need of books.\r\n-- © Alistair Cockburn (1987)");
        }

        [TestMethod]
        public void Should_give_verses_from_a_PoetryLibrary() 
        {
            //The test is still the driver but we include the secondary actor in the form of a stub
            var poetryLibrary = Substitute.For<IObtainPoems>();
            poetryLibrary.GetAPoem().Returns("I want to sleep\r\nSwat the flies\r\nSoftly, please.\r\n\r\n-- Masaoka Shiki (1867-1902)");

            var poetryReader = new PoetryReader(poetryLibrary);
            var verses = poetryReader.GiveMeSomePoetry();

            Check.That(verses).IsEqualTo("I want to sleep\r\nSwat the flies\r\nSoftly, please.\r\n\r\n-- Masaoka Shiki (1867-1902)");
        }

        [TestMethod]
        public void Should_give_verses_when_asked_for_poetry_from_a_ConsoleAdapter() //the drive is a console application
        {
            //Stub the right-side adapter
            var poetryLibrary = Substitute.For<IObtainPoems>();
            poetryLibrary.GetAPoem().Returns("I want to sleep\r\nSwat the flies\r\nSoftly, please.\r\n\r\n-- Masaoka Shiki (1867-1902)");

            //Instantiate the hexagon
            var poetryReader = new PoetryReader(poetryLibrary);

            // Instantiate the left-side adapter
            var writeStrategy = Substitute.For<IWriteStuffOnTheConsole>();
;           var consoleAdapter = new ConsoleAdapter(poetryReader, writeStrategy);

            consoleAdapter.Ask();
            writeStrategy.Received().WriteLine("A beautiful poem:\n\nI want to sleep\r\nSwat the flies\r\nSoftly, please.\r\n\r\n-- Masaoka Shiki (1867-1902)");
        }

        [TestMethod]
        public void Should_give_different_verses_when_using_a_PoemsLibraryFileAdapter()
        {
            //Instantiate the right side to get outside of the hexagon
            var fileAdapter = new PoemFileAdapter(@".\Rimbaud.txt");

            //Instantiate the hexagon
            var poetryReader = new PoetryReader(fileAdapter);

            //The test is the driver, no console
            var verse = poetryReader.GiveMeSomePoetry();
            Check.That(verse).StartsWith("Comme je descendais des Fleuves impassibles");
        }
    }
}