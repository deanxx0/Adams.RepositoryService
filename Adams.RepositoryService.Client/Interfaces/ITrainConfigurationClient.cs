using Adams.RepositoryService.Models;
using NAVIAIServices.RepositoryService.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Adams.RepositoryService.Client.Interfaces
{
    public interface ITrainConfigurationClient
    {
        TrainConfiguration Create(CreateTrainConfiguration createTrainConfiguration);
        List<TrainConfiguration> GetAll();
        TrainConfiguration Get(string trainConfigurationId);
        TrainConfiguration Delete(string trainConfigurationId);
    }
}
