using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DeveloperTest.Business.Interfaces;
using DeveloperTest.Database;
using DeveloperTest.Database.Models;
using DeveloperTest.Models;
using Microsoft.AspNetCore.Routing;
using Microsoft.EntityFrameworkCore;

namespace DeveloperTest.Business
{
    public class EngineerService : IEngineerService
    {
        private readonly ApplicationDbContext context;
        private readonly IJobService jobService;

        public EngineerService(ApplicationDbContext context, IJobService jobService)
        {
            this.context = context;
            this.jobService = jobService;
        }

        public async Task<EngineerModel[]> GetEngineers()
        {
            var engineers = await this.context.Engineers.ToListAsync();
            var models = new List<EngineerModel>();
            foreach (var engineer in engineers)
            {
                EngineerModel model = await ConvertEntityToModel(engineer);
                models.Add(model);
            }
            return models.ToArray();
        }

        private async Task<EngineerModel> ConvertEntityToModel(Engineer engineer)
        {
            var jobs = await this.jobService.GetEngineerJobs(engineer.EngineerId);
            var model = new EngineerModel(engineer.EngineerId, engineer.Name, jobs);
            return model;
        }

        public async Task<EngineerModel> GetEngineer(int engineerId)
        {
            var engineer = await context.Engineers.FindAsync(engineerId);
            if (engineer is null)
                throw new System.Exception("Engineer not founded");
            return await ConvertEntityToModel(engineer);
        }

        public async Task<EngineerModel> CreateEngineer(BaseEngineerModel model)
        {
            var engineer = new Engineer(model.Name);
            context.Engineers.Add(engineer);
            await context.SaveChangesAsync();
            return await ConvertEntityToModel(engineer);
        }
    }
}
