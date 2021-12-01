using Adams.RepositoryService.Client.Interfaces;
using Adams.RepositoryService.Client.Utils;
using Adams.RepositoryService.Models;
using NAVIAIServices.RepositoryService.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace Adams.RepositoryService.Client.Clients
{
    public class ImageInfoClient : IImageInfoClient
    {
        private readonly HttpRequester<ImageInfo> _httpRequester;
        public ImageInfoClient(string projectId, HttpClient httpClient, string itemId)
        {
            _httpRequester = new HttpRequester<ImageInfo>(projectId, httpClient, itemId);
        }

        public ImageInfo Create(CreateImageInfo createImageInfo)
        {
            var imageInfo = _httpRequester.PostAsync(createImageInfo).Result;
            return imageInfo;
        }

        public List<ImageInfo> GetAll()
        {
            var imageInfos = _httpRequester.GetListAsync().Result;
            return imageInfos;
        }

        public ImageInfo Get(string imageInfoId)
        {
            var imageInfo = _httpRequester.GetAsync(imageInfoId).Result;
            return imageInfo;
        }

        public ImageInfo Delete(string imageInfoId)
        {
            var imageInfo = _httpRequester.DeleteAsync(imageInfoId).Result;
            return imageInfo;
        }
    }
}
