using Adams.RepositoryService.Client.Interfaces;
using Adams.RepositoryService.Models;
using NAVIAIServices.RepositoryService.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Adams.RepositoryService.Client
{
    public interface IAdamsClient
    {
        Task<bool> LoginAsync(string username, string password);
        //Task<Project> CreateProjectAsync(CreateProject createProject);
        //Task<List<Project>> GetAllProjectAsync();
        //Task<Project> GetProjectAsync(string projectId);
        //Task<Project> DeleteProjectAsync(string projectId);
        IProjectClient Projects { get; }
        IProjectManager CreateProjectManager(string projectId);
    }
}
