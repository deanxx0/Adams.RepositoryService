using Adams.RepositoryService.Models;
using NAVIAIServices.RepositoryService.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Adams.RepositoryService.Client.Interfaces
{
    public interface IItemClient
    {
        Item Create(CreateItem createItem);
        List<Item> GetAll();
        Item Get(string itemId);
        Item Delete(string itemId);
    }
}
