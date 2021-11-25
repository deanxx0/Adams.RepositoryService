using Adams.RepositoryService.Client.Interfaces;
using Adams.RespositoryService.Models;
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
        Project CreateProject(CreateProject createProject);
        List<Project> GetAllProject();
        Project GetProject(string projectId);
        Project DeleteProject(string projectId);
        IProjectClient CreateProjectClient(string projectId);
    }
}
