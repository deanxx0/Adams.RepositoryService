using Adams.RepositoryService.Models;
using NAVIAIServices.RepositoryService.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Adams.RepositoryService.Client.Interfaces
{
    public interface IProjectClient
    {
        Project Create(CreateProject createProject);
        List<Project> GetAll();
        Project Get(string projectId);
        Project Delete(string projectId);
    }
}
