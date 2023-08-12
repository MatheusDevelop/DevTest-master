using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using DeveloperTest.Business.Interfaces;
using DeveloperTest.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace DeveloperTest.Controllers
{
    [ApiController, Route("[controller]")]
    public class EngineerController : ControllerBase
    {
        private readonly IEngineerService engineerService;

        public EngineerController(IEngineerService engineerService)
        {
            this.engineerService = engineerService;
        }

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            return Ok(await engineerService.GetEngineers());
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> Get(int id)
        {
            var job = await engineerService.GetEngineer(id);

            if (job == null)
            {
                return NotFound();
            }

            return Ok(job);
        }

        [HttpPost]
        public async Task<IActionResult> Create(BaseEngineerModel model)
        {
            var engineer = await engineerService.CreateEngineer(model);

            return Created($"engineer/{engineer.EngineerId}", engineer);
        }
    }
}
