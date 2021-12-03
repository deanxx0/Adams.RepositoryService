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
    public class ItemsService : IItemService
    {
        private readonly HttpRequester<Item> _httpRequester;
        public ItemsService(string projectId, HttpClient client)
        {
            _httpRequester = new HttpRequester<Item>(client, projectId);
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
        }

        public IEnumerable<Item> FindAll()
        {
            var perPgae = 50;
            var count = _httpRequester.GetCountAsync().Result;
            var totalPage = Math.Ceiling(count / (double)perPgae);

            for (int i = 0; i < totalPage; i++)
            {
                var list = _httpRequester.GetListAsync(i+1, perPgae).Result;
                foreach (var l in list)
                {
                    yield return l;
                }
            }
        }

        public void Update(Item entity)
        {
            throw new NotImplementedException();
        }
    }
}
