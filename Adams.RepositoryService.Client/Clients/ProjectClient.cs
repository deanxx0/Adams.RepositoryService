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
    public class ProjectClient : IProjectClient
    {
        private readonly HttpRequester<Project> _httpRequester;
        public ProjectClient(HttpClient httpClient)
        {
            _httpRequester = new HttpRequester<Project>(httpClient);
        }

        public Project Create(CreateProject createProject)
        {
            var project = _httpRequester.PostAsync(createProject).Result;
            return project;
        }

        public List<Project> GetAll()
        {
            var projects = _httpRequester.GetListAsync().Result;
            return projects;
        }

        public Project Get(string projectId)
        {
            var project = _httpRequester.GetAsync(projectId).Result;
            return project;
        }

        public Project Delete(string projectId)
        {
            var project = _httpRequester.DeleteAsync(projectId).Result;
            return project;
        }
    }
}
