using Adams.RepositoryService.Client.Interfaces;
using Adams.RepositoryService.Client.Managers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace Adams.RepositoryService.Client.Clients
{
    internal class ProjectManager : IProjectManager
    {
        private readonly string _projectId;
        private readonly HttpClient _httpClient;

        public ProjectManager(string projectId, HttpClient httpClient)
        {
            _projectId = projectId;
            _httpClient = httpClient;
        }

        public IClassInfoClient ClassInfos => new ClassInfoClient(_projectId, _httpClient);
        public IInputChannelClient InputChannels => new InputChannelClient(_projectId, _httpClient);
        public IMetadataKeyClient MetadataKeys => new MetadataKeyClient(_projectId, _httpClient);
        public ITrainConfigurationClient TrainConfigurations => new TrainConfigurationClient(_projectId, _httpClient);
        public IAugmentationClient Augmentations => new AugmentationClient(_projectId, _httpClient);
        public IDatasetClient Datasets => new DatasetClient(_projectId, _httpClient);
        public IItemClient Items => new ItemClient(_projectId, _httpClient);
        public IItemManager CreateItemManager(string itemId) => new ItemManager(_projectId, _httpClient, itemId);
    }
}
