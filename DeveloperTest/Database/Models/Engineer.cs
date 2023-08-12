using System.Collections.Generic;

namespace DeveloperTest.Database.Models
{
    public class Engineer
    {
        public Engineer()
        {
            
        }
        public Engineer( string name)
        {
            Name = name;
        }

        public int EngineerId { get; set; }
        public string Name { get; set; }
        public List<Job> Jobs { get; set; }
    }
}
