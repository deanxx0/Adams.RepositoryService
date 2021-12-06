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
    class TrainConfigurationService : ITrainConfigurationService
    {
        string _projectId;
        HttpClient _httpClient;
        public TrainConfigurationService(HttpClient httpClient, string projectId)
        {
            _httpClient = httpClient;
            _projectId = projectId;
        }

        public void Add(TrainConfiguration configuration)
        {
            try
            {
                var res = _httpClient.PostAsJsonAsync($"projects/{_projectId}/configurations", configuration).Result;
                if (res.StatusCode != System.Net.HttpStatusCode.OK)
                    throw new Exception(res.ReasonPhrase);
                var model = HttpContentJsonExtensions.ReadFromJsonAsync<TrainConfiguration>(res.Content).Result;
            }
            catch (Exception)
            {
                throw;
            }
        }

        public IEnumerable<TrainConfiguration> Find(Expression<Func<TrainConfiguration, bool>> predicate)
        {
            var allList = this.FindAll().ToList();
            var list = allList.Where(predicate.Compile()).ToList();
            return list;
        }

        public IEnumerable<TrainConfiguration> FindAll()
        {
            var list = _httpClient.GetFromJsonAsync<List<TrainConfiguration>>($"projects/{_projectId}/configurations").Result;
            return list;
        }

        public void Update(TrainConfiguration configuration)
        {
            try
            {
                var res = _httpClient.PutAsJsonAsync<TrainConfiguration>($"projects/{_projectId}/configurations", configuration).Result;
            }
            catch (Exception)
            {

                throw;
            }
        }
    }
}
