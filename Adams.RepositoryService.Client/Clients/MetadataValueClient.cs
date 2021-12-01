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
    public class MetadataValueClient : IMetadataValueClient
    {
        private readonly HttpRequester<MetadataValue> _httpRequester;

        public MetadataValueClient(string projectId, HttpClient httpClient, string itemId)
        {
            _httpRequester = new HttpRequester<MetadataValue>(httpClient, projectId, itemId);
        }

        public MetadataValue Create(CreateMetadataValue createMetadataValue)
        {
            var metadataValue = _httpRequester.PostAsync(createMetadataValue).Result;
            return metadataValue;
        }

        public List<MetadataValue> GetAll()
        {
            var metadataValues = _httpRequester.GetListAsync().Result;
            return metadataValues;
        }

        public MetadataValue Get(string metadataValueId)
        {
            var metadataValue = _httpRequester.GetAsync(metadataValueId).Result;
            return metadataValue;
        }

        public MetadataValue Delete(string metadataValueId)
        {
            var metadataValue = _httpRequester.DeleteAsync(metadataValueId).Result;
            return metadataValue;
        }
    }
}
