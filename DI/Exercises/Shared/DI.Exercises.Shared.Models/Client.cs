using System;
using System.Collections.Generic;

namespace DI.Exercises.Shared.Models
{
    public class Client
    {
        public Client()
        {
            Id = Guid.NewGuid();
        }

        public Guid Id { get; set; }
        public string Name { get; set; }

        public IEnumerable<Feedback> Feedbacks { get; set; }
    }
}
