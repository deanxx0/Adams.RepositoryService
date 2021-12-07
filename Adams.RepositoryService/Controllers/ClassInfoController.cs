using Adams.RepositoryService.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using NAVIAIServices.RepositoryService;
using NAVIAIServices.RepositoryService.Entities;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace Adams.RepositoryService.Server.Controllers
{
    [ApiController]
    [Route("")]
    [Authorize(Policy = PolicyNames.MemberOrAdmin)]
    public class ClassInfoController : ControllerBase
    {
        IRepositoryService _repositoryService;
        private string _projectDbRoot;

        public ClassInfoController(IRepositoryService repositoryService, IConfiguration configuration)
        {
            _projectDbRoot = configuration.GetValue<string>("ProjectDbRoot");
            _repositoryService = repositoryService;
        }

        [HttpGet("projects/{projectId}/classinfos")]
        public ActionResult GetAllClassInfo(string projectId)
        {
            var dbPath = System.IO.Path.Combine(_projectDbRoot, projectId + ".db");
            if (!System.IO.File.Exists(dbPath)) return BadRequest($"Not valid projectId {projectId}");
            var projectService = _repositoryService.GetProjectService(dbPath, DBType.LiteDB);
            var classInfo = projectService.ClassInfos.Find(x => x.IsEnabled == true).ToList();
            return Ok(classInfo);
        }

        [HttpGet("projects/{projectId}/classinfos/count")]
        public ActionResult GetClassInfoCount(string projectId)
        {
            var dbPath = Path.Combine(_projectDbRoot, projectId + ".db");
            if (!System.IO.File.Exists(dbPath))
                return BadRequest($"Not valid projectId {projectId}");

            var projectService = _repositoryService.GetProjectService(dbPath, DBType.LiteDB);
            var count = projectService.ClassInfos.Count();
            return Ok(count);
        }

        [HttpGet("projects/{projectId}/classinfos/{classInfoId}")]
        public ActionResult GetClassInfo(string projectId, string classInfoId)
        {
            var dbPath = Path.Combine(_projectDbRoot, projectId + ".db");
            if (!System.IO.File.Exists(dbPath)) return BadRequest($"Not valid projectId {projectId}");
            var projectService = _repositoryService.GetProjectService(dbPath, DBType.LiteDB);
            var classInfo = projectService.ClassInfos.Find(x => x.IsEnabled == true && x.Id == classInfoId).FirstOrDefault();
            if (classInfo == null) return BadRequest($"Not valid configurationId {classInfoId}");
            return Ok(classInfo);
        }

        [HttpPost("projects/{projectId}/classinfos")]
        public ActionResult CreateClassInfo(string projectId, [FromBody] CreateClassInfo createClassInfo)
        {
            var entity = new ClassInfo(
                createClassInfo.Name,
                createClassInfo.Description,
                createClassInfo.R,
                createClassInfo.G,
                createClassInfo.B,
                true
                );
            var dbPath = System.IO.Path.Combine(_projectDbRoot, projectId + ".db");
            if (!System.IO.File.Exists(dbPath)) return BadRequest($"Not valid projectId {projectId}");
            var projectService = _repositoryService.GetProjectService(dbPath, DBType.LiteDB);
            projectService.ClassInfos.Add(entity);
            return Ok(entity);
        }

        [HttpDelete("projects/{projectId}/classinfos/{classInfoId}")]
        public ActionResult DeleteClassInfo(string projectId, string classInfoId)
        {
            var dbPath = System.IO.Path.Combine(_projectDbRoot, projectId + ".db");
            if (!System.IO.File.Exists(dbPath)) return BadRequest($"Not valid projectId {projectId}");
            var projectService = _repositoryService.GetProjectService(dbPath, DBType.LiteDB);

            var classInfo = projectService.ClassInfos.Find(x => x.Id == classInfoId).FirstOrDefault();
            if (classInfo == null) return BadRequest($"Not valid configurationId {classInfoId}");

            classInfo.SetValue("isenabled", false);

            projectService.ClassInfos.Update(classInfo);

            return Ok(classInfo);
        }

        [HttpPut("projects/{projectId}/classinfos")]
        public ActionResult UpdateClassInfo(string projectId, [FromBody] ClassInfo classInfo)
        {
            var dbPath = System.IO.Path.Combine(_projectDbRoot, projectId + ".db");
            if (!System.IO.File.Exists(dbPath)) return BadRequest($"Not valid projectId {projectId}");
            var projectService = _repositoryService.GetProjectService(dbPath, DBType.LiteDB);

            var classinfo = projectService.ClassInfos.Find(x => x.Id == classInfo.Id).FirstOrDefault();
            if (classinfo == null) return BadRequest($"Not valid configurationId {classInfo.Id}");

            projectService.ClassInfos.Update(classInfo);
            return Ok(classInfo);
        }
    }
}
