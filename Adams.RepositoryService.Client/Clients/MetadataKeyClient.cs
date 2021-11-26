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
    internal class MetadataKeyClient : IMetadataKeyClient
    {
        private readonly HttpRequester<MetadataKey> _httpRequester;

        public MetadataKeyClient(string projectId, HttpClient httpClient)
        {
            _httpRequester = new HttpRequester<MetadataKey>(projectId, httpClient);
        }

        public MetadataKey Create(CreateMetadataKey createMetadataKey)
        {
            var metadataKey = _httpRequester.PostAsync(createMetadataKey).Result;
            return metadataKey;
        }

        public List<MetadataKey> GetAll()
        {
            var metadataKeys = _httpRequester.GetListAsync().Result;
            return metadataKeys;
        }

        public MetadataKey Get(string metadataKeyId)
        {
            var metadataKey = _httpRequester.GetAsync(metadataKeyId).Result;
            return metadataKey;
        }        

        public MetadataKey Delete(string metadataKeyId)
        {
            var metadataKey = _httpRequester.DeleteAsync(metadataKeyId).Result;
            return metadataKey;
        }
    }
}
