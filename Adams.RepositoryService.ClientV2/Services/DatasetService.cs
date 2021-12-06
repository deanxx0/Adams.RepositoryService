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
    class DatasetService : IDatasetService
    {
        string _projectId;
        HttpClient _httpClient;
        public DatasetService(HttpClient httpClient, string projectId)
        {
            _httpClient = httpClient;
            _projectId = projectId;
        }

        public void Add(Dataset dataset)
        {
            try
            {
                var res = _httpClient.PostAsJsonAsync($"projects/{_projectId}/datasets", dataset).Result;
                if (res.StatusCode != System.Net.HttpStatusCode.OK)
                    throw new Exception(res.ReasonPhrase);
                var model = HttpContentJsonExtensions.ReadFromJsonAsync<Dataset>(res.Content).Result;
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

        public IEnumerable<Dataset> Find(Expression<Func<Dataset, bool>> predicate)
        {
            var allList = this.FindAll().ToList();
            var list = allList.Where(predicate.Compile()).ToList();
            return list;
        }

        public IEnumerable<Dataset> FindAll()
        {
            var list = _httpClient.GetFromJsonAsync<List<Dataset>>($"projects/{_projectId}/datasets").Result;
            return list;
        }

        public void Update(Dataset dataset)
        {
            try
            {
                var res = _httpClient.PutAsJsonAsync<Dataset>($"projects/{_projectId}/datasets", dataset).Result;
            }
            catch (Exception)
            {

                throw;
            }
        }
    }
}
