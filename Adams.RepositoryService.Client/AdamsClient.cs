using Adams.RepositoryService.Client.Clients;
using Adams.RepositoryService.Client.Interfaces;
using Adams.RepositoryService.Models;
using NAVIAIServices.RepositoryService.Entities;
using NAVIAIServices.RepositoryService.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Net.Http.Json;
using System.Text;
using System.Threading.Tasks;

namespace Adams.RepositoryService.Client
{
    internal class AdamsClient : IAdamsClient
    {
        private readonly HttpClient _httpClient;

        public AdamsClient(string baseUrl)
        {
            _httpClient = new HttpClient();
            _httpClient.BaseAddress = new Uri(baseUrl);
        }

        public async Task<bool> LoginAsync(string username, string password)
        {
            using (var response = await _httpClient.PostAsync($"/login/{username}/{password}", null))
            {
                if (HttpStatusCode.OK == response.StatusCode)
                {
                    string responseContent = await response.Content.ReadAsStringAsync();
                    var token = responseContent;
                    _httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);
                    return true;
                }
                return false;
            }
        }

        public IProjectClient Projects => new ProjectClient(_httpClient);

        public IProjectManager CreateProjectManager(string projectId) => new ProjectManager(projectId, _httpClient);

        public IProjectService CreateProjectService(string projectId) => new ProjectService(projectId);
    }
}
