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
    class ClassInfoService : IClassInfoService
    {
        string _projectId;
        HttpClient _httpClient;
        public ClassInfoService(HttpClient httpClient, string projectId)
        {
            _httpClient = httpClient;
            _projectId = projectId;
        }
        public void Add(ClassInfo entity)
        {
            try
            {
                var res = _httpClient.PostAsJsonAsync($"projects/{_projectId}/classinfos", entity).Result;
                if (res.StatusCode != System.Net.HttpStatusCode.OK)
                    throw new Exception(res.ReasonPhrase);
                var model = HttpContentJsonExtensions.ReadFromJsonAsync<ClassInfo>(res.Content).Result;
            }
            catch (Exception)
            {
                throw;
            }
        }

        public int Count()
        {
            return _httpClient.GetFromJsonAsync<int>($"projects/{_projectId}/classinfos/count").Result;
        }

        public IEnumerable<ClassInfo> Find(Expression<Func<ClassInfo, bool>> predicate)
        {
            var allList = this.FindAll().ToList();
            var list = allList.Where(predicate.Compile()).ToList();
            return list;
        }

        public IEnumerable<ClassInfo> FindAll()
        {
            var list = _httpClient.GetFromJsonAsync<List<ClassInfo>>($"projects/{_projectId}/classinfos").Result;
            return list;
        }

        public void Update(ClassInfo entity)
        {
            try
            {
                var res = _httpClient.PutAsJsonAsync<ClassInfo>($"projects/{_projectId}/classinfos", entity).Result;
            }
            catch (Exception)
            {

                throw;
            }
        }
    }
}
