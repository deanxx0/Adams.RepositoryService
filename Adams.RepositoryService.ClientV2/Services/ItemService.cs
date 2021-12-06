using Adams.RepositoryService.Models;
using NAVIAIServices.RepositoryService.Entities;
using NAVIAIServices.RepositoryService.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Net.Http;
using System.Net.Http.Json;
using System.Text;
using System.Threading.Tasks;

namespace Adams.RepositoryService.ClientV2.Services
{
    public class ItemService : IItemService
    {
        string _projectId;
        HttpClient _httpClient;

        public ItemService(HttpClient httpClient, string projectId)
        {
            _httpClient = httpClient;
            _projectId = projectId;
        }

        public void Add(Item item)
        {
            throw new NotImplementedException();
        }

        public int Count()
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Item> Find(Expression<Func<Item, bool>> predicate)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Item> Find(Expression<Func<Item, bool>> predicate, int page, int perPage = 30)
        {
            throw new NotImplementedException();
            //if (page < 1) throw new Exception();

            //var resItems = _itemList.Where(predicate.Compile()).ToList();

            //var startIndex = (perPage * (page - 1));
            //var endIndex = startIndex + perPage;
            //List<Item> pageItems = new();
            //try
            //{
            //    for (int i = startIndex; i < endIndex; i++)
            //    {
            //        pageItems.Add(resItems[i]);
            //    }
            //}
            //catch (Exception e)
            //{
            //    return pageItems;
            //}

            //return pageItems;
        }

        public IEnumerable<Item> FindAll()
        {
            var list = _httpClient.GetFromJsonAsync<List<Item>>($"projects/{_projectId}/items").Result;
            return list;
            //var perPage = 50;
            //var count = _httpRequester.GetCountAsync().Result;
            //var totalPage = Math.Ceiling(count / (double)perPage);

            //for (int i = 0; i < totalPage; i++)
            //{
            //    var list = _httpRequester.GetListAsync(i+1, perPage).Result;
            //    foreach (var l in list)
            //    {
            //        yield return l;
            //    }
            //}
        }

        public void Update(Item entity)
        {
            throw new NotImplementedException();
        }
    }
}
