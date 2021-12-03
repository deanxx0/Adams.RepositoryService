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
        public ProjectManager(string baseUrl, string username, string password)
        {
            _httpClient = new HttpClient();
            _httpClient.BaseAddress = new Uri(baseUrl);
            if(!LoginAsync(username, password).Result)
                throw new Exception("invalid user");
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

        public List<Project> FindAll()
        {
            return null;
        }

        public Project Find(string projectId)
        {
            return null;
        }


        public IProjectService GetProjectService(string projectId)
        {
            return new ProjectService(projectId, _httpClient);
        }
    }
}
