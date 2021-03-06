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
    public class InputChannelService : IInputChannelService
    {
        string _projectId;
        HttpClient _httpClient;
        public InputChannelService(HttpClient httpClient, string projectId)
        {
            _httpClient = httpClient;
            _projectId = projectId;
        }

        public void Add(InputChannel entity)
        {
            try
            {
                var res = _httpClient.PostAsJsonAsync($"projects/{_projectId}/channels", entity).Result;
                if (res.StatusCode != System.Net.HttpStatusCode.OK)
                    throw new Exception(res.ReasonPhrase);
                var model = HttpContentJsonExtensions.ReadFromJsonAsync<InputChannel>(res.Content).Result;
            }
            catch (Exception)
            {
                throw;
            }
        }

        public int Count()
        {
            return _httpClient.GetFromJsonAsync<int>($"projects/{_projectId}/channels/count").Result;
        }

        public IEnumerable<InputChannel> Find(Expression<Func<InputChannel, bool>> predicate)
        {
            var allList = this.FindAll().ToList();
            var list = allList.Where(predicate.Compile()).ToList();
            return list;
        }

        public IEnumerable<InputChannel> FindAll()
        {
            var list = _httpClient.GetFromJsonAsync<List<InputChannel>>($"projects/{_projectId}/channels").Result;
            return list;
        }

        public void Update(InputChannel entity)
        {
            try
            {
                var res = _httpClient.PutAsJsonAsync<InputChannel>($"projects/{_projectId}/channels", entity).Result;
            }
            catch (Exception)
            {

                throw;
            }
      
        }
    }
}
