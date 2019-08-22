using System;
using System.Collections.Generic;

namespace DI.Exercises.Shared.Models
{
    public class Consultant
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }

        public IEnumerable<CheckIn> CheckIns { get; set; }
        public IEnumerable<Feedback> Feedbacks { get; set; }
    }
}
