using Adams.RepositoryService.Models;
using NAVIAIServices.RepositoryService.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Adams.RepositoryService.Client.Interfaces
{
    public interface IMetadataValueClient
    {
        MetadataValue Create(CreateMetadataValue createMetadataValue);
        List<MetadataValue> GetAll();
        MetadataValue Get(string metadataValueId);
        MetadataValue Delete(string metadataValueId);
    }
}
