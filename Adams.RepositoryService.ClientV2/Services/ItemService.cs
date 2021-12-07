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
            try
            {
                var res = _httpClient.PostAsJsonAsync($"projects/{_projectId}/items", item).Result;
                if (res.StatusCode != System.Net.HttpStatusCode.OK)
                    throw new Exception(res.ReasonPhrase);
                var model = HttpContentJsonExtensions.ReadFromJsonAsync<Item>(res.Content).Result;
            }
            catch (Exception)
            {
                throw;
            }
        }

        public int Count()
        {
            var count = _httpClient.GetFromJsonAsync<int>($"projects/{_projectId}/items/count").Result;
            return count;
        }

        public IEnumerable<Item> Find(Expression<Func<Item, bool>> predicate)
        {
            var all = this.FindAll();
            var list = all.Where(predicate.Compile());
            return list;
        }

        public IEnumerable<Item> Find(Expression<Func<Item, bool>> predicate, int page, int perPage = 30)
        {
            if (page < 1) throw new Exception();

            var all = this.FindAll();
            var list = all.Where(predicate.Compile()).ToList();

            var startIndex = (perPage * (page - 1));
            var endIndex = startIndex + perPage;
            List<Item> pageItems = new();
            try
            {
                for (int i = startIndex; i < endIndex; i++)
                {
                    pageItems.Add(list[i]);
                }
            }
            catch (Exception e)
            {
                return pageItems;
            }

            return pageItems;
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
            try
            {
                var res = _httpClient.PutAsJsonAsync<Item>($"projects/{_projectId}/items", entity).Result;
            }
            catch (Exception)
            {

                throw;
            }
        }
    }
}
