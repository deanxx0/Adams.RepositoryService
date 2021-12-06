using Adams.RepositoryService.ClientV2.Services;
using NAVIAIServices.RepositoryService.Entities;
using NAVIAIServices.RepositoryService.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Json;
using System.Text;
using System.Threading.Tasks;

namespace Adams.RepositoryService.ClientV2
{
    internal class ProjectService : IProjectService
    {
        HttpClient _httpClient;
        string _projectId;
        public ProjectService(HttpClient httpClient, string projectId)
        {
            _httpClient = httpClient;
            _projectId = projectId;
        }
        public bool IsMultiChannel => throw new NotImplementedException();

        public Project Entity => _httpClient.GetFromJsonAsync<Project>($"projects/{_projectId}").Result;

        public IClassInfoService ClassInfos => new ClassInfoService(_httpClient, _projectId);

        public IDatasetService Datasets => new DatasetService(_httpClient, _projectId);

        public IInputChannelService InputChannels => new InputChannelService(_httpClient, _projectId);

        public IItemService Items => new ItemService(_httpClient, _projectId);

        public IMetadataValueService MetadataValues => throw new NotImplementedException();

        public IMetadataKeyService MetadataKeys => new MetadataKeyService(_httpClient, _projectId);

        public IImageInfoService ImageInfos => new ImageInfoService(_httpClient, _projectId);

        public ITrainConfigurationService TrainConfigurations => new TrainConfigurationService(_httpClient, _projectId);

        public ITrainService Trains => throw new NotImplementedException();

        public IAugmentationService Augmentations => new AugmentationService(_httpClient, _projectId);

        public bool BeginTrans()
        {
            Console.WriteLine("begin trans");
            return true;
        }

        public void CommitTrans()
        {
            Console.WriteLine("commitTrans");
        }
    }
}
