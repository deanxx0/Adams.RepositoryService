using Adams.RepositoryService.Client.Clients;
using Adams.RepositoryService.Client.Interfaces;
using Adams.RespositoryService.Models;
using NAVIAIServices.RepositoryService.Entities;
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

        public async Task<Project> CreateProjectAsync(CreateProject createProject)
        {
            using(var response = await _httpClient.PostAsJsonAsync($"/projects", createProject))
            {
                if (response.Content is object && response.Content.Headers.ContentType.MediaType == "application/json")
                {
                    var model = HttpContentJsonExtensions.ReadFromJsonAsync<Project>(response.Content).Result;
                    return model;
                }
                else
                {
                    Console.WriteLine("HTTP Response was invalid and cannot be deserialised.");
                }
                return null;
            }
        }

        public async Task<List<Project>> GetAllProjectAsync()
        {
            var projects = await _httpClient.GetFromJsonAsync<List<Project>>($"/projects");
            return projects;
        }

        public async Task<Project> GetProjectAsync(string projectId)
        {
            var project = await _httpClient.GetFromJsonAsync<Project>($"/projects/{projectId}");
            return project;
        }

        public async Task<Project> DeleteProjectAsync(string projectId)
        {
            throw new NotImplementedException();
        }

        public IProjectClient CreateProjectClient(string projectId) => new ProjectClient(projectId, _httpClient);
    }
}
