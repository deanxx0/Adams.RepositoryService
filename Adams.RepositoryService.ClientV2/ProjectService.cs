using Adams.RepositoryService.ClientV2.Services;
using NAVIAIServices.RepositoryService.Entities;
using NAVIAIServices.RepositoryService.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace Adams.RepositoryService.ClientV2
{
    internal class ProjectService : IProjectService
    {
        HttpClient _client;
        string _projectId;
        public ProjectService(string projectId, HttpClient client)
        {
            _client = client;
            _projectId = projectId;
        }
        public bool IsMultiChannel => throw new NotImplementedException();

        public Project Entity => throw new NotImplementedException();

        public IClassInfoService ClassInfos => throw new NotImplementedException();

        public IDatasetService Datasets => throw new NotImplementedException();

        public IInputChannelService InputChannels => new InputChannelService(_client);

        public IItemService Items => new ItemsService(_projectId, _client);

        public IMetadataValueService MetadataValues => throw new NotImplementedException();

        public IMetadataKeyService MetadataKeys => throw new NotImplementedException();

        public IImageInfoService ImageInfos => throw new NotImplementedException();

        public ITrainConfigurationService TrainConfigurations => throw new NotImplementedException();

        public ITrainService Trains => throw new NotImplementedException();

        public IAugmentationService Augmentations => throw new NotImplementedException();

        public bool BeginTrans()
        {
            throw new NotImplementedException();
        }

        public void CommitTrans()
        {
            throw new NotImplementedException();
        }
    }
}
