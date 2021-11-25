using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Adams.RepositoryService.Server.Controllers
{
    [ApiController]
    [Route("")]
    [Authorize(Policy = PolicyNames.MemberOrAdmin)]
    public class ProjectInfoController : ControllerBase
    {
        private readonly AppDbContext _appDbContext;

        public ProjectInfoController(AppDbContext appDbContext)
        {
            _appDbContext = appDbContext;
        }

        [HttpGet("projectinfo")]
        public ActionResult GetAllProjectInfo()
        {
            var projectInfos = _appDbContext.ProjectInfos.AsQueryable().ToList();
            return Ok(projectInfos);
        }

        [HttpGet("projectinfo/{id}")]
        public ActionResult GetProjectInfo(string id)
        {
            var projectInfo = _appDbContext.ProjectInfos.AsQueryable().Where(x => x.Id == id).FirstOrDefault();
            if (projectInfo == null) return BadRequest($"Not valid id {id}");
            return Ok(projectInfo);
        }
    }
}
