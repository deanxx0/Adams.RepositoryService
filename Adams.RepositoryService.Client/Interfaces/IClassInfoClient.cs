using Adams.RepositoryService.Models;
using NAVIAIServices.RepositoryService.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Adams.RepositoryService.Client.Interfaces
{
    public interface IClassInfoClient
    {
        ClassInfo Create(CreateClassInfo createClassInfo);
        List<ClassInfo> GetAll();
        ClassInfo Get(string classInfoId);
        ClassInfo Delete(string classInfoId);
    }
}
