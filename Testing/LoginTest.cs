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
    public class LoginTest
    {
        private readonly ITestOutputHelper _output;
        private readonly IAdamsClient _adamsClient;

        public LoginTest(ITestOutputHelper output)
        {
            _output = output;
            _adamsClient = AdamsClientFactory.Create("http://10.10.1.112:5005");
        }

        [Fact]
        public void LoginSuccess()
        {
            var res = _adamsClient.LoginAsync("u1", "123").Result;
            Assert.True(res);
        }

        [Theory]
        [InlineData("u1", "111")]
        [InlineData("uuu", "123")]
        [InlineData("uu", "111")]
        public void LoginFail(string username, string password)
        {
            var res = _adamsClient.LoginAsync(username, password).Result;
            Assert.False(res);
        }
    }
}
