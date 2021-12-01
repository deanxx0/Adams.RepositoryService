using Adams.RepositoryService.Client.Clients;
using Adams.RepositoryService.Client.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace Adams.RepositoryService.Client.Managers
{
    public class ItemManager : IItemManager
    {
        private readonly string _projectId;
        private readonly HttpClient _httpClient;
        private readonly string _itemId;

        public ItemManager(string projectId, HttpClient httpClient, string itemId)
        {
            _projectId = projectId;
            _httpClient = httpClient;
            _itemId = itemId;
        }

        public IImageInfoClient ImageInfos => new ImageInfoClient(_projectId, _httpClient, _itemId);
        //public IMetadataValueClient MetadataValues => new MetadataValueClient(_projectId, _httpClient, _itemId);
    }
}
