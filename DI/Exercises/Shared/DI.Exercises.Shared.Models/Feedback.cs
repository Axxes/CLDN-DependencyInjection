using System;

namespace DI.Exercises.Shared.Models
{
    public class Feedback
    {
        public Guid Id { get; set; }
        public string Description { get; set; }

        public Client Client { get; set; }
        public Consultant Consultant { get; set; }
    }
}
