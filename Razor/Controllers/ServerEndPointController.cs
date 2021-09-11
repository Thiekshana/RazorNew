using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Razor.Interfaces;
using Razor.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Razor.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ServerEndPointController : ControllerBase
    {
        private readonly IProjectRepository _projectRep;

        public ServerEndPointController(IProjectRepository projectRep)
        {
            _projectRep = projectRep;
        }

        [HttpGet]
        public async Task<IActionResult> GetProjectRecords()
        {
            var result =  await _projectRep.GetProjectRecords();
            return Ok(result);
        }

        [HttpPost]
        public async Task<IActionResult> PostProjectRecords([FromBody] Project project)
        {
            var Id =  await _projectRep.SaveProjectRecords(project);
            return Ok(Id.Value);

        }
    }
}
