using Adams.RepositoryService.Models;
using NAVIAIServices.RepositoryService.Entities;
using NAVIAIServices.RepositoryService.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace Adams.RepositoryService.ClientV2.Services
{
    public class ItemService : IItemService
    {
        private readonly HttpRequester<Item> _httpRequester;
        private List<Item> _itemList;

        public ItemService(string projectId, HttpClient _httpClient)
        {
            _httpRequester = new HttpRequester<Item>(_httpClient, projectId);
            _itemList = _httpRequester.GetListAsync(1,30).Result;
        }

        public void Add(Item item)
        {
            CreateItem createItem = new CreateItem(item.Tag);
            var posted = _httpRequester.PostAsync(createItem).Result;
            _itemList.Add(posted);
        }

        public int Count()
        {
            return _httpRequester.GetCountAsync().Result;
        }

        public IEnumerable<Item> Find(Expression<Func<Item, bool>> predicate)
        {
            return _itemList.Where(predicate.Compile());
        }

        //public IEnumerable<Item> Find(Expression<Func<Item, bool>> predicate, int page, int perPage = 30)
        //{
        //    if (page < 1) throw new Exception();

        //    var resItems = _itemList.Where(predicate.Compile()).ToList();

        //    var startIndex = (perPage * (page - 1)) + 1;
        //    var endIndex = startIndex + perPage;
        //    for (int i = startIndex; i < endIndex; i++)
        //    {
        //        yield return resItems[i];
        //    }
        //}
        public IEnumerable<Item> Find(Expression<Func<Item, bool>> predicate, int page, int perPage = 30)
        {
            if (page < 1) throw new Exception();

            var resItems = _itemList.Where(predicate.Compile()).ToList();

            var startIndex = (perPage * (page - 1));
            var endIndex = startIndex + perPage;
            List<Item> pageItems = new();
            try
            {
                for (int i = startIndex; i < endIndex; i++)
                {
                    pageItems.Add(resItems[i]);
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
            var perPage = 50;
            var count = _httpRequester.GetCountAsync().Result;
            var totalPage = Math.Ceiling(count / (double)perPage);

            for (int i = 0; i < totalPage; i++)
            {
                var list = _httpRequester.GetListAsync(i+1, perPage).Result;
                foreach (var l in list)
                {
                    yield return l;
                }
            }
        }

        public void Update(Item entity)
        {
            var updated = _httpRequester.UpdateAsync(entity).Result;

            var index = _itemList.FindIndex(x => x.Id.Contains(entity.Id));
            _itemList[index] = entity;
        }
    }
}
