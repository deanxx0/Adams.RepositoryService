using Adams.RespositoryService.Models;
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
    public class InputChannelController : ControllerBase
    {
        IRepositoryService _repositoryService;
        private string _projectDbRoot;

        public InputChannelController(IRepositoryService repositoryService, IConfiguration configuration)
        {
            _projectDbRoot = configuration.GetValue<string>("ProjectDbRoot");
            _repositoryService = repositoryService;
        }

        [HttpGet("projects/{projectId}/channels")]
        public ActionResult GetAllChannels(string projectId)
        {
            var dbPath = System.IO.Path.Combine(_projectDbRoot, projectId + ".db");
            if (!System.IO.File.Exists(dbPath)) return BadRequest($"Not valid projectId {projectId}");
            var projectService = _repositoryService.GetProjectService(dbPath, DBType.LiteDB);
            var channels = projectService.InputChannels.Find(x => x.IsEnabled == true).ToList();
            return Ok(channels);
        }

        [HttpGet("projects/{projectId}/channels/{channelId}")]
        public ActionResult GetChannel(string projectId, string channelId)
        {
            var dbPath = Path.Combine(_projectDbRoot, projectId + ".db");
            if (!System.IO.File.Exists(dbPath)) return BadRequest($"Not valid projectId {projectId}");
            var projectService = _repositoryService.GetProjectService(dbPath, DBType.LiteDB);
            var channel = projectService.InputChannels.Find(x => x.IsEnabled == true && x.Id == channelId).FirstOrDefault();
            if (channel == null) return BadRequest($"Not valid configurationId {channelId}");
            return Ok(channel);
        }

        [HttpPost("projects/{projectId}/channels")]
        public ActionResult CreateChannel(string projectId, [FromBody] CreateInputChannel createInputChannel)
        {
            var entity = new InputChannel(
                createInputChannel.Name,
                createInputChannel.IsColor,
                createInputChannel.Description,
                createInputChannel.NamingRegex,
                true
                );
            var dbPath = System.IO.Path.Combine(_projectDbRoot, projectId + ".db");
            if (!System.IO.File.Exists(dbPath)) return BadRequest($"Not valid projectId {projectId}");
            var projectService = _repositoryService.GetProjectService(dbPath, DBType.LiteDB);
            projectService.InputChannels.Add(entity);
            return Ok(entity);
        }

        [HttpDelete("projects/{projectId}/channels/{channelId}")]
        public ActionResult DeleteChannel(string projectId, string channelId)
        {
            var dbPath = System.IO.Path.Combine(_projectDbRoot, projectId + ".db");
            if (!System.IO.File.Exists(dbPath)) return BadRequest($"Not valid projectId {projectId}");
            var projectService = _repositoryService.GetProjectService(dbPath, DBType.LiteDB);

            var channel = projectService.InputChannels.Find(x => x.Id == channelId).FirstOrDefault();
            if (channel == null) return BadRequest($"Not valid configurationId {channelId}");

            channel.SetValue("isenabled", false);

            projectService.InputChannels.Update(channel);

            return Ok(channel);
        }
    }
}
