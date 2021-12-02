using Adams.RepositoryService.Client;
using Adams.RepositoryService.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace Testing
{
    public class ProjectTest
    {
        private readonly IAdamsClient _adamsClient;
        public ProjectTest()
        {
            _adamsClient = AdamsClientFactory.Create("http://10.10.1.112:5005");
        }

        [Fact]
        public void CreateProject()
        {
            var model = new CreateProject("testp1", "dddd", "mercury");
            var res = _adamsClient.Projects.Create(model);
            //Assert.Equal()
        }
    }
}
