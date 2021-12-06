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
    public class ItemController : ControllerBase
    {
        IRepositoryService _repositoryService;
        private string _projectDbRoot;

        public ItemController(IRepositoryService repositoryService, IConfiguration configuration)
        {
            _projectDbRoot = configuration.GetValue<string>("ProjectDbRoot");
            _repositoryService = repositoryService;
        }

        [HttpPost("projects/{projectId}/items")]
        public ActionResult CreateItem(string projectId, [FromBody] CreateItem createItem)
        {
            var entity = new Item(createItem.Tag);
            var dbPath = Path.Combine(_projectDbRoot, projectId + ".db");
            if (System.IO.File.Exists(dbPath) is false)
                return BadRequest($"Not valid projectId {projectId}");
            var projectService = _repositoryService.GetProjectService(dbPath, DBType.LiteDB);
            projectService.Items.Add(entity);
            return Ok(entity);
        }

        [HttpGet("projects/{projectId}/items")]
        public ActionResult GetAllItem(string projectId)
        {
            var dbPath = Path.Combine(_projectDbRoot, projectId + ".db");
            if (!System.IO.File.Exists(dbPath))
                return BadRequest($"Not valid projectId {projectId}");
            var projectService = _repositoryService.GetProjectService(dbPath, DBType.LiteDB);
            var items = projectService.Items.Find(x => x.IsEnabled == true).ToList();
            return Ok(items);
        }

        [HttpGet("projects/{projectId}/items/count")]
        public ActionResult GetItemCount(string projectId)
        {
            var dbPath = Path.Combine(_projectDbRoot, projectId + ".db");
            if (!System.IO.File.Exists(dbPath))
                return BadRequest($"Not valid projectId {projectId}");

            var projectService = _repositoryService.GetProjectService(dbPath, DBType.LiteDB);
            var count = projectService.Items.Count();
            return Ok(count);
        }

        [HttpGet("projects/{projectId}/items/pages/{page}")]
        public ActionResult GetItemPage(string projectId, int page)
        {
            var dbPath = Path.Combine(_projectDbRoot, projectId + ".db");
            if (!System.IO.File.Exists(dbPath))
                return BadRequest($"Not valid projectId {projectId}");

            var projectService = _repositoryService.GetProjectService(dbPath, DBType.LiteDB);
            var items = projectService.Items.Find(x => x.IsEnabled == true, page - 1, 50).ToList();
            return Ok(items);
        }

        [HttpGet("projects/{projectId}/items/{itemId}")]
        public ActionResult GetItem(string projectId, string itemId)
        {
            var dbPath = Path.Combine(_projectDbRoot, projectId + ".db");
            if (!System.IO.File.Exists(dbPath))
                return BadRequest($"Not valid projectId {projectId}");
            var projectService = _repositoryService.GetProjectService(dbPath, DBType.LiteDB);
            var item = projectService.Items.Find(x => x.IsEnabled == true && x.Id == itemId).FirstOrDefault();
            if (item == null)
                return BadRequest($"Not valid itemId {itemId}");
            return Ok(item);
        }

        [HttpDelete("projects/{projectId}/items/{itemId}")]
        public ActionResult DeleteItem(string projectId, string itemId)
        {
            var dbPath = Path.Combine(_projectDbRoot, projectId + ".db");
            if (!System.IO.File.Exists(dbPath))
                return BadRequest($"Not valid projectId {projectId}");
            var projectService = _repositoryService.GetProjectService(dbPath, DBType.LiteDB);

            var item = projectService.Items.Find(x => x.Id == itemId).FirstOrDefault();
            if (item == null)
                return BadRequest($"Not valid itemId {itemId}");

            item.SetValue("isenabled", false);

            projectService.Items.Update(item);
            return Ok(item);
        }

        [HttpPut("projects/{projectId}/items")]
        public ActionResult UpdateItem(string projectId, [FromBody]Item itemIn)
        {
            var dbPath = Path.Combine(_projectDbRoot, projectId + ".db");
            if (!System.IO.File.Exists(dbPath))
                return BadRequest($"Not valid projectId {projectId}");
            var projectService = _repositoryService.GetProjectService(dbPath, DBType.LiteDB);

            projectService.Items.Update(itemIn);
            return Ok(itemIn);
        }
    }
}
