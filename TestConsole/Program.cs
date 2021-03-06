using Adams.RepositoryService.ClientV2;
using NAVIAIServices.RepositoryService.Entities;
using NAVIAIServices.RepositoryService.Enums;
using NAVIAIServices.RepositoryService.Interfaces;
using NAVIAIServices.StorageService;
using System;
using System.Linq;

namespace TestConsole
{
    class Program
    {
        static void Main(string[] args)
        {


            ProjectManager manager = new ProjectManager("http://10.10.1.112:5000", "1", "1");

            var projectService =  manager.GetProjectService("00bc3a26-2e66-489c-96c7-42dce1c6add3");

            IStorageService storageService = new RestStorageService("http://10.10.1.112:5000");

            storageService.DownloadImage(projectService,"09691833-a495-4b11-ab2d-ba27e989d24a", "0df7d292-08f0-4688-99af-994efafc3643", @"C:\Users\st\Desktop\test.png");
            //foreach(var item in projectService.Items.FindAll())
            //{

            //}

            //var item1 = new Item("hhhhhhhhhhhhhhhh");
            //var item2 = new Item("mmmmmmmmmmmmmm");
            // 내가 만든 item2의 Id는 aaa라면

            //projectService.Items.Add(item1);
            //projectService.Items.Add(item2);
            // 이걸로 서버에서 생성된 Id는 bbb이다

            var items = projectService.Items.Find((x => x.IsEnabled == true), 1, 30);
            var item = projectService.Items.Find((x => x.Id == "f96e8d6d-5ca5-4e99-b598-0f9d96a15024"), 1, 30);
            var itemlist = item.ToList();
            

            if (true)
            {

            }

            //var adamsClient = AdamsClientFactory.Create("http://10.10.1.112:5005");
            //var loginResult = adamsClient.LoginAsync("u1", "123").Result;

            //// projects
            //var p1 = new CreateProject("pr111111", "dededededede", "mercury");
            //var createP1 = adamsClient.Projects.Create(p1);
            //var p2 = new CreateProject("pr222222", "kjkjkj", "mars");
            //var createP2 = adamsClient.Projects.Create(p2);
            //var getall = adamsClient.Projects.GetAll();
            //var get = adamsClient.Projects.Get(createP2.Id);
            //Console.WriteLine("");
            //var project = adamsClient.CreateProjectManager("0960eb1b-a959-4854-b2df-8b244079d497");

            //var itemManager = project.CreateItemManager("04058f9f-8fe9-4957-894c-a667aedf4bca");

            // metadata value
            //var v1 = new CreateMetadataValue("6af677d5-0ee8-4ed7-85c4-5514d1a597ac", "number", "566");
            //var createv1 = itemManager.MetadataValues.Create(v1);
            //var v2 = new CreateMetadataValue("555f7ac7-305a-4716-bf26-73d0927ffbd8", "string", "dfddddd");
            //var createv2 = itemManager.MetadataValues.Create(v2);
            //var getall = itemManager.MetadataValues.GetAll();
            //var get = itemManager.MetadataValues.Get(createv1.Id);
            //var del = itemManager.MetadataValues.Delete(createv1.Id);
            //var getall2 = itemManager.MetadataValues.GetAll();

            // image info
            //var img1 = new CreateImageInfo("f4c279a1-3379-4108-8504-2dfbfd5052a0", "local", "none", "pathpathpath11");
            //var createImg = itemManager.ImageInfos.Create(img1);
            //var img2 = new CreateImageInfo("f4c279a1-3379-4108-8504-2dfbfd5052a0", "local", "none", "pathpathpath22");
            //var createImg2 = itemManager.ImageInfos.Create(img2);
            //var getAll = itemManager.ImageInfos.GetAll();
            //var get = itemManager.ImageInfos.Get(createImg2.Id);
            //var delete = itemManager.ImageInfos.Delete(createImg2.Id);
            //var getall2 = itemManager.ImageInfos.GetAll();

            //item
            //var i1 = new CreateItem("i1");
            //var createItem1 = projectClient.Items.Create(i1);
            //var i2 = new CreateItem("i2");
            //var createItem2 = projectClient.Items.Create(i2);
            //var allItems = projectClient.Items.GetAll();
            //var item = projectClient.Items.Get(createItem1.Id);
            //var deleteItem = projectClient.Items.Delete(createItem2.Id);
            //var allItems2 = projectClient.Items.GetAll();

            // dataset
            //var dto1 = new CreateDataset("dd1", "ddd", "testing");
            //var createDataset1 = projectClient.Datasets.Create(dto1);
            //var dto2 = new CreateDataset("dd2", "ddd", "testing");
            //var createDataset2 = projectClient.Datasets.Create(dto2);
            //var allDataset = projectClient.Datasets.GetAll();
            //var dataset = projectClient.Datasets.Get(createDataset1.Id);
            //var deleteDataset = projectClient.Datasets.Delete(createDataset2.Id);
            //var allDataset2 = projectClient.Datasets.GetAll();

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
            //var createModel = new CreateMetadataKey("test1", "dfaf", "string");
            //var createRes = projectClient.MetadataKeys.Create(createModel);
            //var createModel2 = new CreateMetadataKey("test2", "dfaf", "boolean");
            //var createRes2 = projectClient.MetadataKeys.Create(createModel2);
            //var getallRes = projectClient.MetadataKeys.GetAll();
            //var getRes = projectClient.MetadataKeys.Get(createRes2.Id);
            //var delRes = projectClient.MetadataKeys.Delete(createRes2.Id);
            //var getallRes2 = projectClient.MetadataKeys.GetAll();

            // config
            //var createModel = new CreateTrainConfiguration()
            //{
            //    Name = "test1",
            //    Description = "fadfa",
            //    Width = 10,
            //    Height = 10,
            //    BatchSize = 10,
            //    PretrainModelPath = "afsaf",
            //    MaxIteration = 5,
            //    StepCount = 5,
            //    BaseLearningRate = 0.1,
            //    Gamma = 0.1,
            //    UseCacheMemory = false,
            //    GPUIndex = 0,
            //    SaveBestPosition = false,
            //    SavingPercentage = 0.1
            //};
            //var createRes = projectClient.TrainConfigurations.Create(createModel);
            //var createModel2 = new CreateTrainConfiguration()
            //{
            //    Name = "test2",
            //    Description = "qewqewq",
            //    Width = 10,
            //    Height = 10,
            //    BatchSize = 10,
            //    PretrainModelPath = "wqeq",
            //    MaxIteration = 5,
            //    StepCount = 5,
            //    BaseLearningRate = 0.1,
            //    Gamma = 0.1,
            //    UseCacheMemory = false,
            //    GPUIndex = 0,
            //    SaveBestPosition = false,
            //    SavingPercentage = 0.1
            //};
            //var createRes2 = projectClient.TrainConfigurations.Create(createModel2);
            //var getallRes = projectClient.TrainConfigurations.GetAll();
            //var getRes = projectClient.TrainConfigurations.Get(createRes2.Id);
            //var delRes = projectClient.TrainConfigurations.Delete(createRes2.Id);
            //var getallRes2 = projectClient.TrainConfigurations.GetAll();

            // aug
            //var createModel = new CreateAugmentation()
            //{
            //    Name = "test1",
            //    Description = "fadfa",
            //    Mirror = true,
            //    Flip = false,
            //    Rotation90 = true,
            //    Zoom = 0.1,
            //    Shift = 0.1,
            //    Tilt = 0.1,
            //    Rotation = 0.1,
            //    BorderMode = "Replicate",
            //    Contrast = 0.1,
            //    Brightness = 0.1,
            //    Shade = 0.1,
            //    Hue = 0.1,
            //    Saturation = 0.1,
            //    Noise = 0.1,
            //    Smoothing = 0.1,
            //    ColorNoise = 0.1,
            //    PartialFocus = 0.1,
            //    Probability = 0.1,
            //    RandomCount = 1
            //};
            //var createRes = projectClient.Augmentations.Create(createModel);
            //var createModel2 = new CreateAugmentation()
            //{
            //    Name = "test2",
            //    Description = "fadfa",
            //    Mirror = true,
            //    Flip = false,
            //    Rotation90 = true,
            //    Zoom = 0.1,
            //    Shift = 0.1,
            //    Tilt = 0.1,
            //    Rotation = 0.1,
            //    BorderMode = "Replicate",
            //    Contrast = 0.1,
            //    Brightness = 0.1,
            //    Shade = 0.1,
            //    Hue = 0.1,
            //    Saturation = 0.1,
            //    Noise = 0.1,
            //    Smoothing = 0.1,
            //    ColorNoise = 0.1,
            //    PartialFocus = 0.1,
            //    Probability = 0.1,
            //    RandomCount = 1
            //};
            //var createRes2 = projectClient.Augmentations.Create(createModel2);
            //var getallRes = projectClient.Augmentations.GetAll();
            //var getRes = projectClient.Augmentations.Get(createRes2.Id);
            //var delRes = projectClient.Augmentations.Delete(createRes2.Id);
            //var getallRes2 = projectClient.Augmentations.GetAll();

        }
    }
}
