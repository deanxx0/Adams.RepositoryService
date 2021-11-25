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
    public class TrainConfigurationController : ControllerBase
    {
        IRepositoryService _repositoryService;
        private string _projectDbRoot;

        public TrainConfigurationController(IRepositoryService repositoryService, IConfiguration configuration)
        {
            _projectDbRoot = configuration.GetValue<string>("ProjectDbRoot");
            _repositoryService = repositoryService;
        }

        [HttpGet("projects/{projectId}/configurations")]
        public ActionResult GetAllConfiguration(string projectId)
        {
            var dbPath = System.IO.Path.Combine(_projectDbRoot, projectId + ".db");
            if (!System.IO.File.Exists(dbPath)) return BadRequest($"Not valid projectId {projectId}");
            var projectService = _repositoryService.GetProjectService(dbPath, DBType.LiteDB);
            var configurations = projectService.TrainConfigurations.Find(x => x.IsEnabled == true).ToList();
            return Ok(configurations);
        }

        [HttpGet("projects/{projectId}/configurations/{configurationId}")]
        public ActionResult GetConfiguration(string projectId, string configurationId)
        {
            var dbPath = Path.Combine(_projectDbRoot, projectId + ".db");
            if (!System.IO.File.Exists(dbPath)) return BadRequest($"Not valid projectId {projectId}");
            var projectService = _repositoryService.GetProjectService(dbPath, DBType.LiteDB);
            var configuration = projectService.TrainConfigurations.Find(x => x.IsEnabled == true && x.Id == configurationId).FirstOrDefault();
            if (configuration == null) return BadRequest($"Not valid configurationId {configurationId}");
            return Ok(configuration);
        }

        [HttpPost("projects/{projectId}/configurations")]
        public ActionResult CreateConfiguration(string projectId, [FromBody] CreateTrainConfiguration createTrainConfiguration)
        {
            var entity = new TrainConfiguration(
                createTrainConfiguration.Name,
                createTrainConfiguration.Description,
                createTrainConfiguration.Width,
                createTrainConfiguration.Height,
                createTrainConfiguration.BatchSize,
                createTrainConfiguration.PretrainModelPath,
                createTrainConfiguration.MaxIteration,
                createTrainConfiguration.StepCount,
                createTrainConfiguration.BaseLearningRate,
                createTrainConfiguration.Gamma,
                createTrainConfiguration.UseCacheMemory,
                createTrainConfiguration.GPUIndex,
                createTrainConfiguration.SaveBestPosition,
                createTrainConfiguration.SavingPercentage
                );
            var dbPath = System.IO.Path.Combine(_projectDbRoot, projectId + ".db");
            if (!System.IO.File.Exists(dbPath)) return BadRequest($"Not valid projectId {projectId}");
            var projectService = _repositoryService.GetProjectService(dbPath, DBType.LiteDB);
            projectService.TrainConfigurations.Add(entity);
            return Ok(entity);
        }

        [HttpDelete("projects/{projectId}/configurations/{configurationId}")]
        public ActionResult DeleteConfiguration(string projectId, string configurationId)
        {
            var dbPath = System.IO.Path.Combine(_projectDbRoot, projectId + ".db");
            if (!System.IO.File.Exists(dbPath)) return BadRequest($"Not valid projectId {projectId}");
            var projectService = _repositoryService.GetProjectService(dbPath, DBType.LiteDB);

            var configuration = projectService.TrainConfigurations.Find(x => x.Id == configurationId).FirstOrDefault();
            if (configuration == null) return BadRequest($"Not valid configurationId {configurationId}");

            configuration.SetValue("isenabled", false);

            projectService.TrainConfigurations.Update(configuration);

            return Ok(configuration);
        }
    }
}
