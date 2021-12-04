using NAVIAIServices.RepositoryService.Entities;
using NAVIAIServices.RepositoryService.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;

namespace Adams.RepositoryService.ClientV2
{
    public class ProjectManager
    {
        private HttpClient _httpClient = null;
        private readonly HttpRequester<Project> _httpRequester;

        public ProjectManager(string baseUrl, string username, string password)
        {
            _httpClient = new HttpClient();
            _httpClient.BaseAddress = new Uri(baseUrl);
            if(!Login(username, password))
                throw new Exception("invalid user");
            _httpRequester = new HttpRequester<Project>(_httpClient);
        }
        bool Login(string username, string password)
        {
            using (var response = _httpClient.PostAsync($"/login/{username}/{password}", null).Result)
            {
                if (HttpStatusCode.OK == response.StatusCode)
                {
                    string responseContent = response.Content.ReadAsStringAsync().Result;
                    var token = responseContent;
                    _httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);
                    return true;
                }
                return false;
            }
        }
        async Task<bool> LoginAsync(string username, string password)
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

        public async Task<List<Project>> FindAllAsync()
        {
            var req = new HttpRequester<Project>(_httpClient);
            return await req.GetListAsync();
        }

        public List<Project> FindAll()
        {
            var projects = _httpRequester.GetListAsync().Result;
            return projects;
        }

        public Project Find(string projectId)
        {
            var project = _httpRequester.GetAsync(projectId).Result;
            return project;
        }


        public IProjectService GetProjectService(string projectId)
        {
            return new ProjectService(projectId, _httpClient);
        }
    }
}
