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
    internal class AugmentationClient : IAugmentationClient
    {
        private readonly HttpRequester<Augmentation> _httpRequester;

        public AugmentationClient(string projectId, HttpClient httpClient)
        {
            _httpRequester = new HttpRequester<Augmentation>(httpClient, projectId);
        }

        public Augmentation Create(CreateAugmentation createAugmentation)
        {
            var augmentation = _httpRequester.PostAsync(createAugmentation).Result;
            return augmentation;
        }

        public List<Augmentation> GetAll()
        {
            var augmentations = _httpRequester.GetListAsync().Result;
            return augmentations;
        }

        public Augmentation Get(string augmentationId)
        {
            var augmentation = _httpRequester.GetAsync(augmentationId).Result;
            return augmentation;
        }

        public Augmentation Delete(string augmentationId)
        {
            var augmentation = _httpRequester.DeleteAsync(augmentationId).Result;
            return augmentation;
        }
    }
}
