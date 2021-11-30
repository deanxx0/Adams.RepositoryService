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
    public class DatasetClient : IDatasetClient
    {
        private readonly HttpRequester<Dataset> _httpRequester;

        public DatasetClient(string projectId, HttpClient httpClient)
        {
            _httpRequester = new HttpRequester<Dataset>(projectId, httpClient);
        }

        public Dataset Create(CreateDataset createDataset)
        {
            var dataset = _httpRequester.PostAsync(createDataset).Result;
            return dataset;
        }

        public List<Dataset> GetAll()
        {
            var dataset = _httpRequester.GetListAsync().Result;
            return dataset;
        }        

        public Dataset Get(string datasetId)
        {
            var dataset = _httpRequester.GetAsync(datasetId).Result;
            return dataset;
        }

        public Dataset Delete(string datasetId)
        {
            var dataset = _httpRequester.DeleteAsync(datasetId).Result;
            return dataset;
        }
    }
}
