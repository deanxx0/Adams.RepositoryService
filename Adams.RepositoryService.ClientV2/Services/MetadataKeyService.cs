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
    class MetadataKeyService : IMetadataKeyService
    {
        string _projectId;
        HttpClient _httpClient;
        public MetadataKeyService(HttpClient httpClient, string projectId)
        {
            _httpClient = httpClient;
            _projectId = projectId;
        }

        public void Add(MetadataKey metadataKey)
        {
            try
            {
                var res = _httpClient.PostAsJsonAsync($"projects/{_projectId}/metadatakeys", metadataKey).Result;
                if (res.StatusCode != System.Net.HttpStatusCode.OK)
                    throw new Exception(res.ReasonPhrase);
                var model = HttpContentJsonExtensions.ReadFromJsonAsync<MetadataKey>(res.Content).Result;
            }
            catch (Exception)
            {
                throw;
            }
        }

        public int Count()
        {
            return _httpClient.GetFromJsonAsync<int>($"projects/{_projectId}/metadatakeys/count").Result;
        }

        public IEnumerable<MetadataKey> Find(Expression<Func<MetadataKey, bool>> predicate)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<MetadataKey> FindAll()
        {
            var list = _httpClient.GetFromJsonAsync<List<MetadataKey>>($"projects/{_projectId}/metadatakeys").Result;
            return list;
        }

        public void Update(MetadataKey metadataKey)
        {
            try
            {
                var res = _httpClient.PutAsJsonAsync<MetadataKey>($"projects/{_projectId}/metadatakeys", metadataKey).Result;
            }
            catch (Exception)
            {

                throw;
            }
        }
    }
}
