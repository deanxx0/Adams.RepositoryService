using Adams.RepositoryService.Client;
using Adams.RepositoryService.Models;
using NAVIAIServices.RepositoryService.Enums;
using System;

namespace TestConsole
{
    class Program
    {
        static void Main(string[] args)
        {
            var adamsClient = AdamsClientFactory.Create("http://localhost:5005");
            var loginResult = adamsClient.LoginAsync("u1", "123").Result;
            var createproject = new CreateProject("pppp1", "descdesc", "Mercury");
            var createprojectresult = adamsClient.CreateProjectAsync(createproject).Result;
            var createproject2 = new CreateProject("pppp2", "descdesc", "Mercury");
            var createprojectresult2 = adamsClient.CreateProjectAsync(createproject).Result;
            var getprojectallresult = adamsClient.GetAllProjectAsync().Result;
            var getprojectresult = adamsClient.GetProjectAsync(createprojectresult.Id).Result;
            var deleteprojectresult = adamsClient.DeleteProjectAsync(createprojectresult.Id).Result; // 아직 구현안함


        }
    }
}
