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
            try
            {
                var res = _httpClient.PostAsJsonAsync($"projects/{_projectId}/imageinfos", entity).Result;
                if (res.StatusCode != System.Net.HttpStatusCode.OK)
                    throw new Exception(res.ReasonPhrase);
            }
            catch (Exception)
            {
                throw;
            }
        }

        public int Count()
        {
            return _httpClient.GetFromJsonAsync<int>($"projects/{_projectId}/imageinfos/count").Result;
        }

        public IEnumerable<ImageInfo> Find(Expression<Func<ImageInfo, bool>> predicate, int page, int perPage = 30)
        {
            if (page < 1) throw new Exception();

            var all = this.FindAll();
            var list = all.Where(predicate.Compile()).ToList();

            var startIndex = (perPage * (page - 1));
            var endIndex = startIndex + perPage;
            List<ImageInfo> pageImageInfos = new();
            try
            {
                for (int i = startIndex; i < endIndex; i++)
                {
                    pageImageInfos.Add(list[i]);
                }
            }
            catch (Exception e)
            {
                throw;
            }

            return pageImageInfos;
        }

        public IEnumerable<ImageInfo> Find(Expression<Func<ImageInfo, bool>> predicate)
        {
            var all = this.FindAll();
            var list = all.Where(predicate.Compile());
            return list;
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
