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
    public class DatasetController : ControllerBase
    {
        IRepositoryService _repositoryService;
        private string _projectDbRoot;

        public DatasetController(IRepositoryService repositoryService, IConfiguration configuration)
        {
            _projectDbRoot = configuration.GetValue<string>("ProjectDbRoot");
            _repositoryService = repositoryService;
        }

        [HttpPost("projects/{projectId}/datasets")]
        public ActionResult CreateDataset(string projectId, [FromBody] CreateDataset createDataset)
        {
            //DatasetTypes type = DatasetTypes.Training;
            //try
            //{
            //    type = convert(createDataset.Type);
            //}
            //catch (Exception)
            //{
            //    return BadRequest($"invalid type {createDataset.Type}");
            //}

            var entity = new Dataset(
                createDataset.Name,
                createDataset.Description,
                createDataset.Type
                );
            var dbPath = System.IO.Path.Combine(_projectDbRoot, projectId + ".db");
            if (!System.IO.File.Exists(dbPath)) return BadRequest($"Not valid projectId {projectId}");
            var projectService = _repositoryService.GetProjectService(dbPath, DBType.LiteDB);
            projectService.Datasets.Add(entity);
            return Ok(entity);
        }

        [HttpGet("projects/{projectId}/datasets")]
        public ActionResult GetAllDataset(string projectId)
        {
            var dbPath = System.IO.Path.Combine(_projectDbRoot, projectId + ".db");
            if (!System.IO.File.Exists(dbPath)) return BadRequest($"Not valid projectId {projectId}");
            var projectService = _repositoryService.GetProjectService(dbPath, DBType.LiteDB);
            var datasets = projectService.Datasets.Find(x => x.IsEnabled == true).ToList();
            return Ok(datasets);
        }

        [HttpGet("projects/{projectId}/datasets/{datasetId}")]
        public ActionResult GetDataset(string projectId, string datasetId)
        {
            var dbPath = Path.Combine(_projectDbRoot, projectId + ".db");
            if (!System.IO.File.Exists(dbPath)) return BadRequest($"Not valid projectId {projectId}");
            var projectService = _repositoryService.GetProjectService(dbPath, DBType.LiteDB);
            var dataset = projectService.Datasets.Find(x => x.IsEnabled == true && x.Id == datasetId).FirstOrDefault();
            if (dataset is null) return BadRequest($"Not valid datasetId {datasetId}");
            return Ok(dataset);
        }

        [HttpDelete("projects/{projectId}/datasets/{datasetId}")]
        public ActionResult DeleteDataset(string projectId, string datasetId)
        {
            var dbPath = Path.Combine(_projectDbRoot, projectId + ".db");
            if (!System.IO.File.Exists(dbPath)) return BadRequest($"Not valid projectId {projectId}");
            var projectService = _repositoryService.GetProjectService(dbPath, DBType.LiteDB);
            var dataset = projectService.Datasets.Find(x => x.IsEnabled == true && x.Id == datasetId).FirstOrDefault();
            if (dataset is null) return BadRequest($"Not valid datasetId {datasetId}");

            dataset.SetValue("isenabled", false);

            projectService.Datasets.Update(dataset);
            return Ok(dataset);
        }

        [HttpPut("projects/{projectId}/datasets")]
        public ActionResult UpdateDataset(string projectId, [FromBody] Dataset dataset)
        {
            var dbPath = System.IO.Path.Combine(_projectDbRoot, projectId + ".db");
            if (!System.IO.File.Exists(dbPath)) return BadRequest($"Not valid projectId {projectId}");
            var projectService = _repositoryService.GetProjectService(dbPath, DBType.LiteDB);

            var entity = projectService.Datasets.Find(x => x.Id == dataset.Id).FirstOrDefault();
            if (entity == null) return BadRequest($"not valid configurationid {dataset.Id}");

            projectService.Datasets.Update(dataset);
            return Ok(dataset);
        }

        private DatasetTypes convert(string typeStr)
        {
            foreach (DatasetTypes type in Enum.GetValues(typeof(DatasetTypes)))
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
