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
    class AugmentationService : IAugmentationService
    {
        string _projectId;
        HttpClient _httpClient;
        public AugmentationService(HttpClient httpClient, string projectId)
        {
            _httpClient = httpClient;
            _projectId = projectId;
        }

        public void Add(Augmentation augmentation)
        {
            try
            {
                var res = _httpClient.PostAsJsonAsync($"projects/{_projectId}/augmentations", augmentation).Result;
                if (res.StatusCode != System.Net.HttpStatusCode.OK)
                    throw new Exception(res.ReasonPhrase);
                var model = HttpContentJsonExtensions.ReadFromJsonAsync<Augmentation>(res.Content).Result;
            }
            catch (Exception)
            {
                throw;
            }
        }

        public IEnumerable<Augmentation> Find(Expression<Func<Augmentation, bool>> predicate)
        {
            var allList = this.FindAll().ToList();
            var list = allList.Where(predicate.Compile()).ToList();
            return list;
        }

        public IEnumerable<Augmentation> FindAll()
        {
            var list = _httpClient.GetFromJsonAsync<List<Augmentation>>($"projects/{_projectId}/augmentations").Result;
            return list;
        }

        public void Update(Augmentation augmentation)
        {
            try
            {
                var res = _httpClient.PutAsJsonAsync<Augmentation>($"projects/{_projectId}/augmentations", augmentation).Result;
            }
            catch (Exception)
            {

                throw;
            }
        }
    }
}
