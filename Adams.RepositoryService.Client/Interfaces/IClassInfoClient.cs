using Adams.RespositoryService.Models;
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
        ClassInfo CreateClassInfo(CreateClassInfo createClassInfo);
        List<ClassInfo> GetAllClassInfo();
        ClassInfo GetClassInfo(string classInfoId);
        ClassInfo DeleteClassInfo(string classInfoId);
    }
}
