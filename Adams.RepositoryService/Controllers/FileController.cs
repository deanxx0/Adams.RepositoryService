using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Adams.RepositoryService.Server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FileController : ControllerBase
    {
        [HttpPost("images/{projectId}/{itemId}/{imageInfoId}")]
        public ActionResult UploadImage(string projectId, string itemId, string imageInfoId)
        {
            return Ok();
        }

        [HttpGet("images/{projectId}/{itemId}/{imageInfoId}")]
        public ActionResult DownloadImage(string projectId, string itemId, string imageInfoId)
        {
            return Ok();
        }

        [HttpPost("modelfiles/{projectId}/{trainId}")]
        public ActionResult DownloadModelFile(string projectId, string trainId)
        {
            return Ok();
        }
    }
}
