using Adams.RepositoryService.Client.Interfaces;
using Adams.RepositoryService.Client.Utils;
using Adams.RepositoryService.Models;
using NAVIAIServices.RepositoryService.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace Adams.RepositoryService.Client.Clients
{
    public class ItemClient : IItemClient
    {
        private readonly HttpRequester<Item> _httpRequester;
        public ItemClient(string projectId, HttpClient httpClient)
        {
            _httpRequester = new HttpRequester<Item>(httpClient, projectId);
        }

        public Item Create(CreateItem createItem)
        {
            var item = _httpRequester.PostAsync(createItem).Result;
            return item;
        }
        public List<Item> GetAll()
        {
            var items = _httpRequester.GetListAsync().Result;
            return items;
        }
        public Item Get(string itemId)
        {
            var item = _httpRequester.GetAsync(itemId).Result;
            return item;
        }

        public Item Delete(string itemId)
        {
            var item = _httpRequester.DeleteAsync(itemId).Result;
            return item;
        }
    }
}
