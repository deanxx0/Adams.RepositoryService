using Adams.RepositoryService.Client.Interfaces;
using Adams.RepositoryService.Client.Utils;
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
        private readonly HttpRequester<ClassInfo> _httpRequester;

        public ClassInfoClient(string projectId, HttpClient httpClient)
        {
            _httpRequester = new HttpRequester<ClassInfo>(projectId, httpClient);
        }

        public ClassInfo Create(CreateClassInfo createClassInfo)
        {
            var classInfo = _httpRequester.PostAsync(createClassInfo).Result;
            return classInfo;
        }

        public List<ClassInfo> GetAll()
        {
            var classInfos = _httpRequester.GetListAsync().Result;
            return classInfos;
        }

        public ClassInfo Get(string classInfoId)
        {
            var classInfo = _httpRequester.GetAsync(classInfoId).Result;
            return classInfo;
        }

        public ClassInfo Delete(string classInfoId)
        {
            var classInfo = _httpRequester.DeleteAsync(classInfoId).Result;
            return classInfo;
        }        
    }
}
