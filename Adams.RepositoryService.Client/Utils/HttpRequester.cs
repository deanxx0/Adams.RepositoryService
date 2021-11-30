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
        string _projectId;
        HttpClient _httpClient;
        string _targetUrl;

        public HttpRequester(string projectId, HttpClient httpClient)
        {
            _projectId = projectId;
            _httpClient = httpClient;
            _targetUrl = TypeToUrl();
        }

        private string TypeToUrl()
        {
            if (typeof(T) == typeof(ClassInfo)) return "classinfos";
            else if (typeof(T) == typeof(InputChannel)) return "channels";
            else if (typeof(T) == typeof(MetadataKey)) return "metadatakeys";
            else if (typeof(T) == typeof(TrainConfiguration)) return "configurations";
            else if (typeof(T) == typeof(Augmentation)) return "augmentations";
            else if (typeof(T) == typeof(Dataset)) return "datasets";
            else throw new Exception("HttpRequester Type To Url method fail");
        }

        internal async Task<T> PostAsync(object createModel)
        {
            using (var response = await _httpClient.PostAsJsonAsync($"/projects/{_projectId}/{_targetUrl}", createModel))
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
            var modelList = await _httpClient.GetFromJsonAsync<List<T>>($"/projects/{_projectId}/{_targetUrl}");
            return modelList;
        }

        internal async Task<T> GetAsync(string modelId)
        {
            var model = await _httpClient.GetFromJsonAsync<T>($"projects/{_projectId}/{_targetUrl}/{modelId}");
            return model;
        }

        internal async Task<T> DeleteAsync(string modelId)
        {
            using (var response = await _httpClient.DeleteAsync($"projects/{_projectId}/{_targetUrl}/{modelId}"))
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
