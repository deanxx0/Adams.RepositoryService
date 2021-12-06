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
    public class ImageInfoController : ControllerBase
    {
        IRepositoryService _repositoryService;
        private string _projectDbRoot;

        public ImageInfoController(IRepositoryService repositoryService, IConfiguration configuration)
        {
            _projectDbRoot = configuration.GetValue<string>("ProjectDbRoot");
            _repositoryService = repositoryService;
        }

        [HttpPost("projects/{projectId}/items/{itemId}/imageinfos")]
        public ActionResult CreateImageInfo(string projectId, string itemId, [FromBody] CreateImageInfo createImageInfo)
        {
            // item check
            var dbPath = System.IO.Path.Combine(_projectDbRoot, projectId + ".db");
            if (!System.IO.File.Exists(dbPath)) return BadRequest($"Not valid projectId {projectId}");
            var projectService = _repositoryService.GetProjectService(dbPath, DBType.LiteDB);
            var item = projectService.Items.Find(x => x.IsEnabled == true && x.Id == itemId).FirstOrDefault();
            if (item is null) return BadRequest($"Not valid itemId {itemId}");

            // channel check
            var channel = projectService.InputChannels.Find(x => x.IsEnabled == true && x.Id == createImageInfo.ChannelId).FirstOrDefault();
            if (channel is null) return BadRequest($" Not valid channelId {createImageInfo.ChannelId}");

            // type convert
            // storage convert
            // copy convert
            var storageType = StorageTypes.Local;
            var copyType = CopyTypes.None;
            try
            {
                storageType = convertStorageTypes(createImageInfo.StorageType);
                copyType = convertCopyTypes(createImageInfo.CopyTypes);
            }
            catch
            {
                return BadRequest($"invalid type {createImageInfo.StorageType} or {createImageInfo.CopyTypes}");
            }

            var entity = new ImageInfo(
                itemId,
                createImageInfo.ChannelId,
                createImageInfo.OriginalFilePath,
                storageType,
                copyType
                );

            projectService.ImageInfos.Add(entity);
            return Ok(entity);
        }

        //[HttpGet("projects/{projectId}/items/{itemId}/imageinfos")]
        //public ActionResult GetallImageInfo(string projectId, string itemId)
        //{
        //    var dbPath = System.IO.Path.Combine(_projectDbRoot, projectId + ".db");
        //    if (!System.IO.File.Exists(dbPath)) return BadRequest($"Not valid projectId {projectId}");
        //    var projectService = _repositoryService.GetProjectService(dbPath, DBType.LiteDB);
        //    //item check
        //    var item = projectService.Items.Find(x => x.IsEnabled == true && x.Id == itemId).FirstOrDefault();
        //    if (item is null) return BadRequest($"Not valid itemId {itemId}");

        //    var imageInfo = projectService.ImageInfos.Find(x => x.IsEnabled == true).ToList();
        //    return Ok(imageInfo);
        //}

        [HttpGet("projects/{projectId}/imageinfos")]
        public ActionResult GetImageInfos(string projectId)
        {
            var dbPath = Path.Combine(_projectDbRoot, projectId + ".db");
            if (!System.IO.File.Exists(dbPath))
                return BadRequest($"Not valid projectId {projectId}");
            var projectService = _repositoryService.GetProjectService(dbPath, DBType.LiteDB);
            var imageInfos = projectService.ImageInfos.FindAll();
            return Ok(imageInfos);
        }

        [HttpGet("projects/{projectId}/items/{itemId}/imageinfos/count")]
        public ActionResult GetImageInfoCount(string projectId, string itemId)
        {
            var dbPath = Path.Combine(_projectDbRoot, projectId + ".db");
            if (!System.IO.File.Exists(dbPath))
                return BadRequest($"Not valid projectId {projectId}");
            var projectService = _repositoryService.GetProjectService(dbPath, DBType.LiteDB);
            var item = projectService.Items.Find(x => x.IsEnabled == true && x.Id == itemId).FirstOrDefault();
            if (item is null) return BadRequest($"Not valid itemId {itemId}");

            var count = projectService.ImageInfos.Count();
            return Ok(count);
        }

        [HttpGet("projects/{projectId}/items/{itemId}/imageinfos/pages/{page}")]
        public ActionResult GetImageInfoPage(string projectId, string itemId, int page)
        {
            var dbPath = Path.Combine(_projectDbRoot, projectId + ".db");
            if (!System.IO.File.Exists(dbPath))
                return BadRequest($"Not valid projectId {projectId}");
            var projectService = _repositoryService.GetProjectService(dbPath, DBType.LiteDB);
            var item = projectService.Items.Find(x => x.IsEnabled == true && x.Id == itemId).FirstOrDefault();
            if (item is null) return BadRequest($"Not valid itemId {itemId}");

            var imageInfos = projectService.ImageInfos.Find(x => x.IsEnabled == true, page - 1, 50).ToList();
            return Ok(imageInfos);
        }

        [HttpGet("projects/{projectId}/items/{itemId}/imageinfos/{imageInfoId}")]
        public ActionResult GetImageInfo(string projectId, string itemId, string imageInfoId)
        {
            var dbPath = System.IO.Path.Combine(_projectDbRoot, projectId + ".db");
            if (!System.IO.File.Exists(dbPath)) return BadRequest($"Not valid projectId {projectId}");
            var projectService = _repositoryService.GetProjectService(dbPath, DBType.LiteDB);
            //item check
            var item = projectService.Items.Find(x => x.IsEnabled == true && x.Id == itemId).FirstOrDefault();
            if (item is null) return BadRequest($"Not valid itemId {itemId}");

            var imageInfo = projectService.ImageInfos.Find(x => x.IsEnabled == true && x.Id == imageInfoId).FirstOrDefault();
            if (imageInfo is null) return BadRequest($"Not valid itemId {itemId}");
            return Ok(imageInfo);
        }

        [HttpDelete("projects/{projectId}/items/{itemId}/imageinfos/{imageInfoId}")]
        public ActionResult DeleteImageInfo(string projectId, string itemId, string imageInfoId)
        {
            var dbPath = System.IO.Path.Combine(_projectDbRoot, projectId + ".db");
            if (!System.IO.File.Exists(dbPath)) return BadRequest($"Not valid projectId {projectId}");
            var projectService = _repositoryService.GetProjectService(dbPath, DBType.LiteDB);
            //item check
            var item = projectService.Items.Find(x => x.IsEnabled == true && x.Id == itemId).FirstOrDefault();
            if (item == null) return BadRequest($"Not valid itemId {itemId}");

            var imageInfo = projectService.ImageInfos.Find(x => x.IsEnabled == true && x.Id == imageInfoId).FirstOrDefault();
            if (imageInfo is null) return BadRequest($"Not valid itemId {itemId}");

            imageInfo.SetValue("isenabled", false);
            projectService.ImageInfos.Update(imageInfo);
            return Ok(imageInfo);
        }

        private StorageTypes convertStorageTypes(string typeStr)
        {
            foreach (StorageTypes type in Enum.GetValues(typeof(StorageTypes)))
            {
                if (type.ToString().ToLower() == typeStr.ToLower())
                    return type;
            }
            throw new Exception();
        }

        private CopyTypes convertCopyTypes(string typeStr)
        {
            foreach (CopyTypes type in Enum.GetValues(typeof(CopyTypes)))
            {
                if (type.ToString().ToLower() == typeStr.ToLower())
                    return type;
            }
            throw new Exception();
        }
    }
}
