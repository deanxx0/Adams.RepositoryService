using Adams.RepositoryService.Models;
using NAVIAIServices.RepositoryService.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Adams.RepositoryService.Client.Interfaces
{
    public interface IMetadataKeyClient
    {
        MetadataKey Create(CreateMetadataKey createMetadataKey);
        List<MetadataKey> GetAll();
        MetadataKey Get(string metadataKeyId);
        MetadataKey Delete(string metadataKeyId);
    }
}
