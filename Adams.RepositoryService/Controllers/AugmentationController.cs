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
    public class AugmentationController : ControllerBase
    {
        IRepositoryService _repositoryService;
        private string _projectDbRoot;

        public AugmentationController(IRepositoryService repositoryService, IConfiguration configuration)
        {
            _projectDbRoot = configuration.GetValue<string>("ProjectDbRoot");
            _repositoryService = repositoryService;
        }

        [HttpGet("projects/{projectId}/augmentations")]
        public ActionResult GetAllAugmentation(string projectId)
        {
            var dbPath = System.IO.Path.Combine(_projectDbRoot, projectId + ".db");
            if (!System.IO.File.Exists(dbPath)) return BadRequest($"Not valid projectId {projectId}");
            var projectService = _repositoryService.GetProjectService(dbPath, DBType.LiteDB);
            var augmentation = projectService.Augmentations.Find(x => x.IsEnabled == true).ToList();
            return Ok(augmentation);
        }

        [HttpGet("projects/{projectId}/augmentations/{augmentationId}")]
        public ActionResult GetAugmentation(string projectId, string augmentationId)
        {
            var dbPath = Path.Combine(_projectDbRoot, projectId + ".db");
            if (!System.IO.File.Exists(dbPath)) return BadRequest($"Not valid projectId {projectId}");
            var projectService = _repositoryService.GetProjectService(dbPath, DBType.LiteDB);
            var augmentation = projectService.Augmentations.Find(x => x.IsEnabled == true && x.Id == augmentationId).FirstOrDefault();
            if (augmentation == null) return BadRequest($"Not valid configurationId {augmentationId}");
            return Ok(augmentation);
        }

        [HttpPost("projects/{projectId}/augmentations")]
        public ActionResult CreateAugmentation(string projectId, [FromBody] CreateAugmentation createAugmentation)
        {
            BorderModes borderMode = default;
            try
            {
                borderMode = Convert(createAugmentation.BorderMode);
            }
            catch
            {
                return BadRequest($"invalid type {createAugmentation.BorderMode}");
            }

            var entity = new Augmentation(
                createAugmentation.Name,
                createAugmentation.Description,
                createAugmentation.Mirror,
                createAugmentation.Flip,
                createAugmentation.Rotation90,
                createAugmentation.Zoom,
                createAugmentation.Shift,
                createAugmentation.Tilt,
                createAugmentation.Rotation,
                borderMode,
                createAugmentation.Contrast,
                createAugmentation.Brightness,
                createAugmentation.Shade,
                createAugmentation.Hue,
                createAugmentation.Saturation,
                createAugmentation.Noise,
                createAugmentation.Smoothing,
                createAugmentation.ColorNoise,
                createAugmentation.PartialFocus,
                createAugmentation.Probability,
                createAugmentation.RandomCount
                );
            var dbPath = System.IO.Path.Combine(_projectDbRoot, projectId + ".db");
            if (!System.IO.File.Exists(dbPath)) return BadRequest($"Not valid projectId {projectId}");
            var projectService = _repositoryService.GetProjectService(dbPath, DBType.LiteDB);
            projectService.Augmentations.Add(entity);
            return Ok(entity);
        }

        [HttpDelete("projects/{projectId}/augmentations/{augmentationId}")]
        public ActionResult DeleteAugmentation(string projectId, string augmentationId)
        {
            var dbPath = System.IO.Path.Combine(_projectDbRoot, projectId + ".db");
            if (!System.IO.File.Exists(dbPath)) return BadRequest($"Not valid projectId {projectId}");
            var projectService = _repositoryService.GetProjectService(dbPath, DBType.LiteDB);

            var augmentation = projectService.Augmentations.Find(x => x.Id == augmentationId).FirstOrDefault();
            if (augmentation == null) return BadRequest($"Not valid configurationId {augmentationId}");

            augmentation.SetValue("isenabled", false);

            projectService.Augmentations.Update(augmentation);

            return Ok(augmentation);
        }

        private BorderModes Convert(string borderModeStr)
        {
            foreach (BorderModes mode in Enum.GetValues(typeof(BorderModes)))
            {
                if (mode.ToString().ToLower() == borderModeStr.ToLower()) return mode;
            }
            throw new Exception("BorderMode convert fail");
        }
    }
}
