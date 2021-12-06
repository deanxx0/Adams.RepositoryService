using NAVIAIServices.RepositoryService.Entities;
using NAVIAIServices.RepositoryService.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Net.Http;
using System.Net.Http.Json;
using System.Text;
using System.Threading.Tasks;

namespace Adams.RepositoryService.ClientV2.Services
{
    class ImageInfoService : IImageInfoService
    {
        string _projectId;
        HttpClient _httpClient;

        public ImageInfoService(HttpClient httpClient, string projectId)
        {
            _httpClient = httpClient;
            _projectId = projectId;
        }
        public void Add(ImageInfo entity)
        {
            throw new NotImplementedException();
        }

        public int Count()
        {
            throw new NotImplementedException();
        }

        public IEnumerable<ImageInfo> Find(Expression<Func<ImageInfo, bool>> predicate, int page, int perPage = 30)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<ImageInfo> Find(Expression<Func<ImageInfo, bool>> predicate)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<ImageInfo> FindAll()
        {
            var list = _httpClient.GetFromJsonAsync<List<ImageInfo>>($"projects/{_projectId}/imageinfos").Result;
            return list;
        }

        public void Update(ImageInfo entity)
        {
            throw new NotImplementedException();
        }
    }
}
