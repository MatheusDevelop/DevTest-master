using System;

namespace DeveloperTest.Database.Models
{
    public class Job
    {
        public int JobId { get; set; }

        public Engineer Engineer { get; set; }
        public DateTime When { get; set; }
    }
}
