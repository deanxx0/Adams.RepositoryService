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
            var projectClient = adamsClient.CreateProjectClient("e020ed9f-0b26-4264-b63a-d26764a42ccd");

            // project
            //var createproject = new CreateProject("pppp1", "descdesc", "Mercury");
            //var createprojectresult = adamsClient.CreateProjectAsync(createproject).Result;
            //var createproject2 = new CreateProject("pppp2", "descdesc", "Mercury");
            //var createprojectresult2 = adamsClient.CreateProjectAsync(createproject).Result;
            //var getprojectallresult = adamsClient.GetAllProjectAsync().Result;
            //var getprojectresult = adamsClient.GetProjectAsync(createprojectresult.Id).Result;
            //var deleteprojectresult = adamsClient.DeleteProjectAsync(createprojectresult.Id).Result; // 아직 구현안함

            // class info
            //var createClassInfo = new CreateClassInfo("testClassInfo2", "dedede", 0, 0, 0);
            //var createClassInfoResult = projectClient.ClassInfos.Create(createClassInfo);
            //var AllClassInfo = projectClient.ClassInfos.GetAll();
            //var classInfo = projectClient.ClassInfos.Get(createClassInfoResult.Id);
            //var deleteClassInfo = projectClient.ClassInfos.Delete("2fc9334a-bcce-495e-be66-cd62e3e51e37");

            // input channel
            //var createModel = new CreateInputChannel("test1", true, "seesete", "rere");
            //var createRes = projectClient.InputChannels.Create(createModel);
            //var createModel2 = new CreateInputChannel("test2", true, "qweqete", "xvvx");
            //var createRes2 = projectClient.InputChannels.Create(createModel2);
            //var getallRes = projectClient.InputChannels.GetAll();
            //var getRes = projectClient.InputChannels.Get(createRes2.Id);
            //var delRes = projectClient.InputChannels.Delete(createRes2.Id);
            //var getallRes2 = projectClient.InputChannels.GetAll();

            // meta key
            var createModel = new CreateMetadataKey("test1", "dfaf", "string");
            var createRes = projectClient.MetadataKeys.Create(createModel);
            var createModel2 = new CreateMetadataKey("test2", "dfaf", "boolean");
            var createRes2 = projectClient.MetadataKeys.Create(createModel2);
            var getallRes = projectClient.MetadataKeys.GetAll();
            var getRes = projectClient.MetadataKeys.Get(createRes2.Id);
            var delRes = projectClient.MetadataKeys.Delete(createRes2.Id);
            var getallRes2 = projectClient.MetadataKeys.GetAll();

        }
    }
}
