using Adams.RepositoryService.Models;
using NAVIAIServices.RepositoryService.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Adams.RepositoryService.Client.Interfaces
{
    public interface IImageInfoClient
    {
        ImageInfo Create(CreateImageInfo createImageInfo);
        List<ImageInfo> GetAll();
        ImageInfo Get(string imageInfoId);
        ImageInfo Delete(string imageInfoId);
    }
}
