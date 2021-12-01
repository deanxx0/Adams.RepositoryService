using NAVIAIServices.RepositoryService.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Json;
using System.Text;
using System.Threading.Tasks;

namespace Adams.RepositoryService.Client.Utils
{
    class HttpRequester<T>
    {
        HttpClient _httpClient;
        string _projectId;
        bool _isProjectManger;
        
        string _itemId;
        bool _isItemManager;

        string _targetUrl;
        string _fullUrl;


        public HttpRequester(HttpClient httpClient, string projectId = null, string itemId = null)
        {
            _httpClient = httpClient;

            _projectId = projectId;
            if (_projectId is not null) _isProjectManger = true;

            _itemId = itemId;
            if (_itemId is not null) _isItemManager = true;

            _targetUrl = TypeToUrl();
            _fullUrl = GetFullUrl();
        }

        private string GetFullUrl()
        {
            if (_isProjectManger == true)
            {
                if (_isItemManager == true)
                {
                    return $"/projects/{_projectId}/items/{_itemId}/{_targetUrl}";
                }

                return $"/projects/{_projectId}/{_targetUrl}";
            }

            return $"/projects";
        }

        private string TypeToUrl()
        {
            if (typeof(T) == typeof(ClassInfo)) return "classinfos";
            else if (typeof(T) == typeof(InputChannel)) return "channels";
            else if (typeof(T) == typeof(MetadataKey)) return "metadatakeys";
            else if (typeof(T) == typeof(TrainConfiguration)) return "configurations";
            else if (typeof(T) == typeof(Augmentation)) return "augmentations";
            else if (typeof(T) == typeof(Dataset)) return "datasets";
            else if (typeof(T) == typeof(Item)) return "items";
            else if (typeof(T) == typeof(ImageInfo)) return "imageinfos";
            else if (typeof(T) == typeof(MetadataValue)) return "metadatavalues";
            else if (typeof(T) == typeof(Project)) return null;
            else throw new Exception("HttpRequester Type To Url method fail");
        }

        internal async Task<T> PostAsync(object createModel)
        {
            using (var response = await _httpClient.PostAsJsonAsync(_fullUrl, createModel))
            {
                if (response.Content is object && response.Content.Headers.ContentType.MediaType == "application/json")
                {
                    var model = HttpContentJsonExtensions.ReadFromJsonAsync<T>(response.Content).Result;
                    return model;
                }
                else
                {
                    Console.WriteLine("HTTP Response was invalid and cannot be deserialised.");
                }
                return default(T);
            }
        }

        internal async Task<List<T>> GetListAsync()
        {
            var modelList = await _httpClient.GetFromJsonAsync<List<T>>(_fullUrl);
            return modelList;
        }

        internal async Task<T> GetAsync(string modelId)
        {
            var model = await _httpClient.GetFromJsonAsync<T>(_fullUrl + $"/{modelId}");
            return model;
        }

        internal async Task<T> DeleteAsync(string modelId)
        {
            using (var response = await _httpClient.DeleteAsync(_fullUrl + $"/{modelId}"))
            {
                if (response.Content is object && response.Content.Headers.ContentType.MediaType == "application/json")
                {
                    var model = HttpContentJsonExtensions.ReadFromJsonAsync<T>(response.Content).Result;
                    return model;
                }
                else
                {
                    Console.WriteLine("HTTP Response was invalid and cannot be deserialised.");
                }
                return default(T);
            }
        }
    }
}
