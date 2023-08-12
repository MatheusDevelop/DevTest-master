using System;
using System.Collections.Generic;

namespace DeveloperTest.Models
{
    public class EngineerModel
    {
        public EngineerModel(int engineerId, string engineerName, List<JobModel> jobs)
        {
            EngineerId = engineerId;
            Name = engineerName;
            Jobs = jobs;
        }

        public int EngineerId { get; set; }

        public string Name { get; set; }
        public List<JobModel> Jobs { get; set; }

    }
}
