using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using NAVIAIServices.RepositoryService;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace Adams.RepositoryService.Server.Controllers
{
    [Route("")]
    [ApiController]
    [Authorize(Policy = PolicyNames.MemberOrAdmin)]
    public class TrainController : ControllerBase
    {
        IRepositoryService _repositoryService;
        private string _projectDbRoot;

        public TrainController(IRepositoryService repositoryService, IConfiguration configuration)
        {
            _projectDbRoot = configuration.GetValue<string>("ProjectDbRoot");
            _repositoryService = repositoryService;
        }

        [HttpGet("projects/{projectId}/trains")]
        public ActionResult GetAllTrain(string projectId)
        {
            var dbPath = System.IO.Path.Combine(_projectDbRoot, projectId + ".db");
            if (!System.IO.File.Exists(dbPath)) return BadRequest($"Not valid projectId {projectId}");
            var projectService = _repositoryService.GetProjectService(dbPath, DBType.LiteDB);
            var trains = projectService.Trains.Find(x => x.IsEnabled == true).ToList();
            return Ok(trains);
        }

        [HttpGet("projects/{projectId}/trains/{trainId}")]
        public ActionResult GetTrain(string projectId, string trainId)
        {
            var dbPath = Path.Combine(_projectDbRoot, projectId + ".db");
            if (!System.IO.File.Exists(dbPath)) return BadRequest($"Not valid projectId {projectId}");
            var projectService = _repositoryService.GetProjectService(dbPath, DBType.LiteDB);
            var train = projectService.Trains.Find(x => x.IsEnabled == true && x.Id == trainId).FirstOrDefault();
            if (train == null) return BadRequest($"Not valid configurationId {trainId}");
            return Ok(train);
        }

        //[HttpPost("projects/{projectId}/trains")]
        //public ActionResult CreateTrain(string projectId, [FromBody] CreateClassInfo createClassInfo)
        //{
        //    var entity = new ClassInfo(
        //        createClassInfo.Name,
        //        createClassInfo.Description,
        //        createClassInfo.R,
        //        createClassInfo.G,
        //        createClassInfo.B,
        //        true
        //        );
        //    var dbPath = System.IO.Path.Combine(_projectDbRoot, projectId + ".db");
        //    if (!System.IO.File.Exists(dbPath)) return BadRequest($"Not valid projectId {projectId}");
        //    var projectService = _repositoryService.GetProjectService(dbPath, DBType.LiteDB);
        //    projectService.ClassInfos.Add(entity);
        //    return Ok(entity);
        //}
    }
}
