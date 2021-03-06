using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
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
    public class FileController : ControllerBase
    {
        public string _saveRoot;
        IRepositoryService _repositoryService;
        private string _projectDbRoot;

        public FileController(IRepositoryService repositoryService, IConfiguration configuration)
        {
            _projectDbRoot = configuration.GetValue<string>("ProjectDbRoot");
            _saveRoot = configuration.GetValue<string>("imageRoot");
            _repositoryService = repositoryService;
        }

        [HttpPost("images/{projectId}/{itemId}/{imageInfoId}")]
        public async Task<IActionResult> UploadImage(string projectId, string itemId, string imageInfoId, IFormFile file)
        {
            var dbPath = System.IO.Path.Combine(_projectDbRoot, projectId + ".db");
            if (!System.IO.File.Exists(dbPath)) return BadRequest($"Not valid projectId {projectId}");
            var projectService = _repositoryService.GetProjectService(dbPath, DBType.LiteDB);
            var item = projectService.Items.Find(x => x.IsEnabled == true && x.Id == itemId).FirstOrDefault();
            if (item is null) return BadRequest($"Not valid itemId {itemId}");
            var imageInfo = projectService.ImageInfos.Find(x => x.IsEnabled == true && x.Id == imageInfoId).FirstOrDefault();
            if (imageInfo is null) return BadRequest($"Not valid imageInfoId {imageInfoId}");

            try
            {
                //Path.GetExtension("Asdfsadf");
                var fileType = file.ContentType.Split('/'); // png, jpg, bmp, tiff
                if (file.Length > 0)
                {
                    var filePath = $"{_saveRoot}\\{projectId}\\{imageInfoId}" + "." + fileType[1];
                    if (System.IO.File.Exists(filePath))
                    {
                        return BadRequest("File already exist");
                    }
                    if (!Directory.Exists($"{_saveRoot}\\{projectId}\\"))
                    {
                        Directory.CreateDirectory($"{_saveRoot}\\{projectId}\\");
                    }
                    using (FileStream fileStream = System.IO.File.Create(filePath))
                    {
                        file.CopyTo(fileStream);
                        fileStream.Flush();
                        return Ok($"{_saveRoot}\\{projectId}\\{imageInfoId}" + "." + fileType[1]);
                    }
                }
                else
                {
                    return BadRequest("Failed");
                }
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message.ToString());
            }
        }

        [HttpGet("images/{projectId}/{itemId}/{imageInfoId}")]
        public FileContentResult DownloadImage(string projectId, string itemId, string imageInfoId)
        {
            var dbPath = System.IO.Path.Combine(_projectDbRoot, projectId + ".db");
            if (!System.IO.File.Exists(dbPath)) return null;
            var projectService = _repositoryService.GetProjectService(dbPath, DBType.LiteDB);
            var item = projectService.Items.Find(x => x.IsEnabled == true && x.Id == itemId).FirstOrDefault();
            if (item is null) return null;
            var imageInfo = projectService.ImageInfos.Find(x => x.IsEnabled == true && x.Id == imageInfoId).FirstOrDefault();
            if (imageInfo is null) return null;

            try
            {
                if (!Directory.Exists($"{_saveRoot}\\{projectId}\\"))
                {
                    return null;
                }
                else
                {
                    var files = Directory.GetFiles($"{_saveRoot}\\{projectId}");
                    var targetFilePath = files.Where(x => x.Contains(imageInfoId)).FirstOrDefault();
                    var targetFile = new FileInfo(targetFilePath);
                    return File(System.IO.File.ReadAllBytes(targetFilePath), "application/octet-stream", targetFile.Name);
                }
            }
            catch (Exception ex)
            {
                return null;
            }
        }

        [HttpPost("modelfiles/{projectId}/{trainId}")]
        public ActionResult DownloadModelFile(string projectId, string trainId)
        {


            return Ok();
        }
    }
}
