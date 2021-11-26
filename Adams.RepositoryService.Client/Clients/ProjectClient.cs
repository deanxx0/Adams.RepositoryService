using Adams.RepositoryService.Client.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace Adams.RepositoryService.Client.Clients
{
    internal class ProjectClient : IProjectClient
    {
        private readonly string _projectId;
        private readonly HttpClient _httpClient;

        public ProjectClient(string projectId, HttpClient httpClient)
        {
            _projectId = projectId;
            _httpClient = httpClient;
        }

        public IClassInfoClient ClassInfos => new ClassInfoClient(_projectId, _httpClient);
        public IInputChannelClient InputChannels => new InputChannelClient(_projectId, _httpClient);
        public IMetadataKeyClient MetadataKeys => new MetadataKeyClient(_projectId, _httpClient);
        public ITrainConfigurationClient TrainConfigurations => new TrainConfigurationClient(_projectId, _httpClient);
    }
}
