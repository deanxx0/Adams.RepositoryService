using Adams.RepositoryService.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using NAVIAIServices.RepositoryService;
using NAVIAIServices.RepositoryService.Entities;
using NAVIAIServices.RepositoryService.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Adams.RepositoryService.Server.Controllers
{
    [ApiController]
    [Route("")]
    [Authorize(Policy = PolicyNames.MemberOrAdmin)]
    public class MetadataValueController : ControllerBase
    {
        IRepositoryService _repositoryService;
        private string _projectDbRoot;

        public MetadataValueController(IRepositoryService repositoryService, IConfiguration configuration)
        {
            _projectDbRoot = configuration.GetValue<string>("ProjectDbRoot");
            _repositoryService = repositoryService;
        }

        [HttpPost("projects/{projectId}/items/{itemId}/metadatavalues")]
        public ActionResult CreateMetadataValue(string projectId, string itemId, [FromBody] CreateMetadataValue createMetadataValue)
        {
            // item check
            var dbPath = System.IO.Path.Combine(_projectDbRoot, projectId + ".db");
            if (!System.IO.File.Exists(dbPath)) return BadRequest($"Not valid projectId {projectId}");
            var projectService = _repositoryService.GetProjectService(dbPath, DBType.LiteDB);
            var item = projectService.Items.Find(x => x.IsEnabled == true && x.Id == itemId).FirstOrDefault();
            if (item == null) return BadRequest($"Not valid itemId {itemId}");

            // key check
            var key = projectService.MetadataKeys.Find(x => x.IsEnabled == true && x.Id == createMetadataValue.KeyId).FirstOrDefault();
            if (key == null) return BadRequest($"Not valid configurationId {createMetadataValue.KeyId}");

            // type convert
            MetadataTypes type = MetadataTypes.Boolean;
            try
            {
                type = convert(createMetadataValue.Type);
            }
            catch
            {
                return BadRequest($"invalid type {createMetadataValue.Type}");
            }

            var entity = new MetadataValue(
                itemId,
                createMetadataValue.KeyId,
                type,
                createMetadataValue.Value
                );
            projectService.MetadataValues.Add(entity);
            return Ok(entity);
        }

        [HttpGet("projects/{projectId}/items/{itemId}/metadatavalues")]
        public ActionResult GetAllMetadataValue(string projectId, string itemId)
        {
            var dbPath = System.IO.Path.Combine(_projectDbRoot, projectId + ".db");
            if (!System.IO.File.Exists(dbPath)) return BadRequest($"Not valid projectId {projectId}");
            var projectService = _repositoryService.GetProjectService(dbPath, DBType.LiteDB);
            //item check
            var item = projectService.Items.Find(x => x.IsEnabled == true && x.Id == itemId).FirstOrDefault();
            if (item == null) return BadRequest($"Not valid itemId {itemId}");

            var metadataValues = projectService.MetadataValues.Find(x => x.IsEnabled == true).ToList();
            return Ok(metadataValues);
        }

        [HttpGet("projects/{projectId}/items/{itemId}/metadatavalues/{metadataValueId}")]
        public ActionResult GetMetadataValue(string projectId, string itemId, string metadataValueId)
        {
            var dbPath = System.IO.Path.Combine(_projectDbRoot, projectId + ".db");
            if (!System.IO.File.Exists(dbPath)) return BadRequest($"Not valid projectId {projectId}");
            var projectService = _repositoryService.GetProjectService(dbPath, DBType.LiteDB);
            //item check
            var item = projectService.Items.Find(x => x.IsEnabled == true && x.Id == itemId).FirstOrDefault();
            if (item == null) return BadRequest($"Not valid itemId {itemId}");

            var metadataValue = projectService.MetadataValues.Find(x => x.IsEnabled == true && x.Id == metadataValueId).FirstOrDefault();
            if (metadataValue == null) return BadRequest($"Not valid metadataValue {metadataValueId}");
            return Ok(metadataValue);
        }

        [HttpDelete("projects/{projectId}/items/{itemId}/metadatavalues/{metadataValueId}")]
        public ActionResult DeleteMetadataValue(string projectId, string itemId, string metadataValueId)
        {
            var dbPath = System.IO.Path.Combine(_projectDbRoot, projectId + ".db");
            if (!System.IO.File.Exists(dbPath)) return BadRequest($"Not valid projectId {projectId}");
            var projectService = _repositoryService.GetProjectService(dbPath, DBType.LiteDB);
            //item check
            var item = projectService.Items.Find(x => x.IsEnabled == true && x.Id == itemId).FirstOrDefault();
            if (item == null) return BadRequest($"Not valid itemId {itemId}");

            var metadataValue = projectService.MetadataValues.Find(x => x.IsEnabled == true && x.Id == metadataValueId).FirstOrDefault();
            if (metadataValue == null) return BadRequest($"Not valid metadataValue {metadataValueId}");

            metadataValue.SetValue("isenabled", false);
            projectService.MetadataValues.Update(metadataValue);
            return Ok(metadataValue);
        }

        private MetadataTypes convert(string typeStr)
        {
            foreach (MetadataTypes type in Enum.GetValues(typeof(MetadataTypes)))
            {
                if (type.ToString().ToLower() == typeStr.ToLower())
                {
                    return type;
                }
            }
            throw new Exception();
        }
    }
}
