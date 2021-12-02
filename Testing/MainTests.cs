using Adams.RepositoryService.Client;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;
using Xunit.Abstractions;

namespace Testing
{
    public class MainTests
    {
        private readonly ITestOutputHelper _output;
        private readonly IAdamsClient _adamsClient;

        public MainTests(ITestOutputHelper output)
        {
            _output = output;
            _adamsClient = AdamsClientFactory.Create("http://10.10.1.112:5005");
        }

        [Fact]
        public void TestOutput()
        {
            Assert.Equal(2, 1 + 1);
        }

        [Fact]
        public void LoginShouldTrue()
        {
            var res = _adamsClient.LoginAsync("u1", "123").Result;
            _output.WriteLine($"True test: {res}");
            Assert.True(res);
        }

        [Fact]
        public void LoginShouldFail()
        {
            var res = _adamsClient.LoginAsync("u11", "123123").Result;
            _output.WriteLine($"Fail test: {res}");
            Assert.False(res);
        }

        //[Theory]
        //[InlineData("u1", "123")]
        //[InlineData("uu", "123")]
        //[InlineData("u1", "1")]
        //public void LoginShouldTrueTheory(string username, string password)
        //{
        //    var res = _adamsClient.LoginAsync(username, password).Result;
        //    Assert.True(res);
        //}
    }
}
