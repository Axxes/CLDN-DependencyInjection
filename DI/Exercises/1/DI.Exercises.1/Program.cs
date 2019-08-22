using DI.Exercises._1.Classes;
using DI.Exercises.Shared.Models;
using System;

namespace DI.Exercises._1
{
    class Program
    {
        static void Main(string[] args)
        {
            var consultant = new Consultant
            {
                Id = Guid.NewGuid(),
                Name = "Lode Kennes",
                Email = "lode.kennes@axxes.com"
            };

            var checkIn = new CheckIn
            {
                Id = Guid.NewGuid(),
                Description = "My description",
                Trimester = Trimester.Q1,
                Year = 2019,
                Consultant = consultant
            };

            var processor = new CheckInProcessor();
            processor.ProcessCheckIn(checkIn);

            Console.ReadLine();
        }
    }
}
