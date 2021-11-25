using Adams.RepositoryService.Client.Clients;
using Adams.RepositoryService.Client.Interfaces;
using Adams.RespositoryService.Models;
using NAVIAIServices.RepositoryService.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
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

        public Project CreateProject(CreateProject createProject)
        {
            throw new NotImplementedException();
        }

        public List<Project> GetAllProject()
        {
            throw new NotImplementedException();
        }

        public Project GetProject(string projectId)
        {
            throw new NotImplementedException();
        }

        public Project DeleteProject(string projectId)
        {
            throw new NotImplementedException();
        }

        public IProjectClient CreateProjectClient(string projectId) => new ProjectClient(projectId, _httpClient);
    }
}
