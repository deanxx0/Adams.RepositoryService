using Adams.RepositoryService.Client.Interfaces;
using Adams.RespositoryService.Models;
using NAVIAIServices.RepositoryService.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace Adams.RepositoryService.Client.Clients
{
    internal class ClassInfoClient : IClassInfoClient
    {
        private readonly string _projectId;
        private readonly HttpClient _httpClient;
        public ClassInfoClient(string projectId, HttpClient httpClient)
        {
            _projectId = projectId;
            _httpClient = httpClient;
        }

        public ClassInfo CreateClassInfo(CreateClassInfo createClassInfo)
        {
            throw new NotImplementedException();
        }

        public List<ClassInfo> GetAllClassInfo()
        {
            throw new NotImplementedException();
        }

        public ClassInfo GetClassInfo(string classInfoId)
        {
            throw new NotImplementedException();
        }

        public ClassInfo DeleteClassInfo(string classInfoId)
        {
            throw new NotImplementedException();
        }        
    }
}
