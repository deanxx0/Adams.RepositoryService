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
    class TrainService : ITrainService
    {
        string _projectId;
        HttpClient _httpClient;
        public TrainService(HttpClient httpClient, string projectId)
        {
            _httpClient = httpClient;
            _projectId = projectId;
        }

        public void Add(Train train)
        {
            //object createTrain = new { Name = train.Name, Description = train.Description };
            try
            {
                var res = _httpClient.PostAsJsonAsync($"projects/{_projectId}/trains", train).Result;
                if (res.StatusCode != System.Net.HttpStatusCode.OK)
                    throw new Exception(res.ReasonPhrase);
                var model = HttpContentJsonExtensions.ReadFromJsonAsync<Train>(res.Content).Result;
            }
            catch (Exception)
            {
                throw;
            }
        }

        public IEnumerable<Train> Find(Expression<Func<Train, bool>> predicate)
        {
            var all = this.FindAll();
            var list = all.Where(predicate.Compile());
            return list;
        }

        public IEnumerable<Train> FindAll()
        {
            var list = _httpClient.GetFromJsonAsync<List<Train>>($"projects/{_projectId}/trains").Result;
            return list;
        }

        public void Update(Train train)
        {
            try
            {
                var res = _httpClient.PutAsJsonAsync<Train>($"projects/{_projectId}/trains", train).Result;
            }
            catch (Exception)
            {

                throw;
            }
        }
    }
}
