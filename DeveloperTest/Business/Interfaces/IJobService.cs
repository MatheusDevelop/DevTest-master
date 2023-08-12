using DeveloperTest.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace DeveloperTest.Business.Interfaces
{
    public interface IJobService
    {
        JobModel[] GetJobs();

        JobModel GetJob(int jobId);

        JobModel CreateJob(BaseJobModel model);
        Task<List<JobModel>> GetEngineerJobs(int engineerId);
    }
}
