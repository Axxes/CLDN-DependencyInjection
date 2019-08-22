using System;

namespace DI.Exercises.Shared.Models
{
    public class CheckIn
    {
        public CheckIn()
        {
            Id = Guid.NewGuid();
        }

        public Guid Id { get; set; }
        public string Description { get; set; }
        public Consultant Consultant { get; set; }
        public Trimester Trimester { get; set; }
        public uint Year { get; set; }
    }
}
