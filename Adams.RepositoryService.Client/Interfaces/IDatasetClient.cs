using Adams.RepositoryService.Models;
using NAVIAIServices.RepositoryService.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Adams.RepositoryService.Client.Interfaces
{
    public interface IDatasetClient
    {
        Dataset Create(CreateDataset createDataset);
        List<Dataset> GetAll();
        Dataset Get(string datasetId);
        Dataset Delete(string datasetId);
    }
}
