using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DeveloperTest.Business.Interfaces;
using DeveloperTest.Database;
using DeveloperTest.Database.Models;
using DeveloperTest.Models;
using Microsoft.EntityFrameworkCore;

namespace DeveloperTest.Business
{
    public class JobService : IJobService
    {
        private readonly ApplicationDbContext context;

        public JobService(ApplicationDbContext context)
        {
            this.context = context;
        }

        public JobModel[] GetJobs()
        {
            return context.Jobs.Include(e => e.Engineer).Select(ConvertEntityToModel).ToArray();
        }

        public JobModel GetJob(int jobId)
        {
            return context.Jobs.Include(e => e.Engineer).Where(x => x.JobId == jobId).Select(x => ConvertEntityToModel(x)).SingleOrDefault();
        }

        private static JobModel ConvertEntityToModel(Job x)
        {
            return new JobModel
            {
                JobId = x.JobId,
                EngineerName = x.Engineer.Name,
                EngineerId = x.Engineer.EngineerId,
                When = x.When
            };
        }

        public JobModel CreateJob(BaseJobModel model)
        {
            var engineer = context.Engineers.Include(e=> e.Jobs).FirstOrDefault(e => e.EngineerId == model.EngineerId);
            if (engineer is null)
                throw new System.Exception("Engineer not founded");
            Job newJob = new()
            {
                When = model.When
            };
            engineer.Jobs.Add(newJob);
            context.SaveChanges();

            return new JobModel
            {
                JobId = newJob.JobId,
                EngineerName = engineer.Name,
                EngineerId = engineer.EngineerId,
                When = newJob.When
            };
        }

        public async Task<List<JobModel>> GetEngineerJobs(int engineerId)
        {
            var jobs = await context.Jobs.Where(e => e.Engineer.EngineerId == engineerId).ToListAsync();
            var models = jobs.Select(ConvertEntityToModel).ToList();
            return models;
        }
    }
}
