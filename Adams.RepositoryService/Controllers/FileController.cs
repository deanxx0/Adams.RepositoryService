﻿using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
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
        public FileController(IConfiguration configuration)
        {
            _saveRoot = configuration.GetValue<string>("imageRoot");
        }

        [HttpPost("images/{projectId}/{itemId}/{imageInfoId}")]
        public async Task<string> UploadImage(string projectId, string itemId, string imageInfoId, IFormFile file)
        {
            try
            {
                if (file.Length > 0)
                {
                    if (!Directory.Exists(_saveRoot + "\\Upload\\"))
                    {
                        Directory.CreateDirectory(_saveRoot + "\\Upload\\");
                    }
                    using (FileStream fileStream = System.IO.File.Create(_saveRoot + "\\Upload\\" + file.FileName))
                    {
                        file.CopyTo(fileStream);
                        fileStream.Flush();
                        return _saveRoot + "\\Upload\\" + file.FileName;
                    }
                }
                else
                {
                    return "Failed";
                }
            }
            catch (Exception ex)
            {
                return ex.Message.ToString();
            }
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



        //[HttpPost("images/uploadtowwwroot")]
        //public async Task<string> UploadTest(IFormFile file)
        //{
        //    try
        //    {
        //        if (file.Length > 0)
        //        {
        //            if (!Directory.Exists(_environment.WebRootPath + "\\Upload\\"))
        //            {
        //                Directory.CreateDirectory(_environment.WebRootPath + "\\Upload\\");
        //            }
        //            using (FileStream fileStream = System.IO.File.Create(_environment.WebRootPath + "\\Upload\\" + file.FileName))
        //            {
        //                file.CopyTo(fileStream);
        //                fileStream.Flush();
        //                return "\\Upload\\" + file.FileName;
        //            }
        //        }
        //        else
        //        {
        //            return "Failed";
        //        }
        //    }
        //    catch (Exception ex)
        //    {
        //        return ex.Message.ToString();
        //    }
        //}

        //[HttpPost("images/uploadtolocal")]
        //public async Task<string> UploadTestLocal(IFormFile file)
        //{
        //    try
        //    {
        //        if (file.Length > 0)
        //        {
        //            if (!Directory.Exists(_saveRoot + "\\Upload\\"))
        //            {
        //                Directory.CreateDirectory(_saveRoot + "\\Upload\\");
        //            }
        //            using (FileStream fileStream = System.IO.File.Create(_saveRoot + "\\Upload\\" + file.FileName))
        //            {
        //                file.CopyTo(fileStream);
        //                fileStream.Flush();
        //                return "\\Upload\\" + file.FileName;
        //            }
        //        }
        //        else
        //        {
        //            return "Failed";
        //        }
        //    }
        //    catch (Exception ex)
        //    {
        //        return ex.Message.ToString();
        //    }
        //}
    }
}