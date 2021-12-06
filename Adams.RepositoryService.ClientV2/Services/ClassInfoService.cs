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
            throw new NotImplementedException();
        }

        public IEnumerable<ClassInfo> Find(Expression<Func<ClassInfo, bool>> predicate)
        {
            throw new NotImplementedException();
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
