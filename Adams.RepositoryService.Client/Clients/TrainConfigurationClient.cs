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
    internal class TrainConfigurationClient : ITrainConfigurationClient
    {
        private readonly HttpRequester<TrainConfiguration> _httpRequester;

        public TrainConfigurationClient(string projectId, HttpClient httpClient)
        {
            _httpRequester = new HttpRequester<TrainConfiguration>(projectId, httpClient);
        }
        public TrainConfiguration Create(CreateTrainConfiguration createTrainConfiguration)
        {
            var trainConfiguration = _httpRequester.PostAsync(createTrainConfiguration).Result;
            return trainConfiguration;
        }

        public List<TrainConfiguration> GetAll()
        {
            var trainConfigurations = _httpRequester.GetListAsync().Result;
            return trainConfigurations;
        }

        public TrainConfiguration Get(string trainConfigurationId)
        {
            var trainConfiguration = _httpRequester.GetAsync(trainConfigurationId).Result;
            return trainConfiguration;
        }

        public TrainConfiguration Delete(string trainConfigurationId)
        {
            var trainConfiguration = _httpRequester.DeleteAsync(trainConfigurationId).Result;
            return trainConfiguration;
        }
    }
}
