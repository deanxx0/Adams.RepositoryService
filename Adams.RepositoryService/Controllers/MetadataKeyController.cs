using Adams.RepositoryService.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using NAVIAIServices.RepositoryService;
using NAVIAIServices.RepositoryService.Entities;
using NAVIAIServices.RepositoryService.Enums;
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
    public class MetadataKeyController : ControllerBase
    {
        IRepositoryService _repositoryService;
        private string _projectDbRoot;

        public MetadataKeyController(IRepositoryService repositoryService, IConfiguration configuration)
        {
            _projectDbRoot = configuration.GetValue<string>("ProjectDbRoot");
            _repositoryService = repositoryService;
        }

        [HttpGet("projects/{projectId}/metadatakeys")]
        public ActionResult GetAllMetadataKey(string projectId)
        {
            var dbPath = System.IO.Path.Combine(_projectDbRoot, projectId + ".db");
            if (!System.IO.File.Exists(dbPath)) return BadRequest($"Not valid projectId {projectId}");
            var projectService = _repositoryService.GetProjectService(dbPath, DBType.LiteDB);
            var metadataKeys = projectService.MetadataKeys.Find(x => x.IsEnabled == true).ToList();
            return Ok(metadataKeys);
        }

        [HttpGet("projects/{projectId}/metadatakeys/{metadataKeyId}")]
        public ActionResult GetMetadataKey(string projectId, string metadataKeyId)
        {
            var dbPath = Path.Combine(_projectDbRoot, projectId + ".db");
            if (!System.IO.File.Exists(dbPath)) return BadRequest($"Not valid projectId {projectId}");
            var projectService = _repositoryService.GetProjectService(dbPath, DBType.LiteDB);
            var metadataKey = projectService.MetadataKeys.Find(x => x.IsEnabled == true && x.Id == metadataKeyId).FirstOrDefault();
            if (metadataKey == null) return BadRequest($"Not valid configurationId {metadataKeyId}");
            return Ok(metadataKey);
        }

        [HttpPost("projects/{projectId}/metadatakeys")]
        public ActionResult CreateMetadataKey(string projectId, [FromBody] CreateMetadataKey createMetadataKey)
        {

            MetadataTypes type = MetadataTypes.Boolean;
            try
            {
                type = convert(createMetadataKey.Type);
            }
            catch (Exception)
            {
                return BadRequest($"invalid type {createMetadataKey.Type}");
            }

            var entity = new MetadataKey(
                createMetadataKey.Key,
                createMetadataKey.Description,
                type,
                true);
            var dbPath = System.IO.Path.Combine(_projectDbRoot, projectId + ".db");
            if (!System.IO.File.Exists(dbPath)) return BadRequest($"Not valid projectId {projectId}");
            var projectService = _repositoryService.GetProjectService(dbPath, DBType.LiteDB);
            projectService.MetadataKeys.Add(entity);
            return Ok(entity);
        }

        [HttpDelete("projects/{projectId}/metadatakeys/{metadatakeyId}")]
        public ActionResult DeleteMetadataKey(string projectId, string metadatakeyId)
        {
            var dbPath = System.IO.Path.Combine(_projectDbRoot, projectId + ".db");
            if (!System.IO.File.Exists(dbPath)) return BadRequest($"Not valid projectId {projectId}");
            var projectService = _repositoryService.GetProjectService(dbPath, DBType.LiteDB);

            var metadatakey = projectService.MetadataKeys.Find(x => x.Id == metadatakeyId).FirstOrDefault();
            if (metadatakey == null) return BadRequest($"Not valid configurationId {metadatakeyId}");

            metadatakey.SetValue("isenabled", false);

            projectService.MetadataKeys.Update(metadatakey);

            return Ok(metadatakey);
        }

        private MetadataTypes convert(string typeStr)
        {
            foreach (MetadataTypes type in Enum.GetValues(typeof(MetadataTypes)))
            {
                if (type.ToString().ToLower() == typeStr.ToLower())
                    return type;
            }
            throw new Exception("MetadataType convert fail");
        }
    }
}
