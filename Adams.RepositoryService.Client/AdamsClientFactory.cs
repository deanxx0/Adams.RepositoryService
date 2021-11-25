using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Adams.RepositoryService.Client
{
    public static class AdamsClientFactory
    {
        public static IAdamsClient Create(string baseUrl)
        {
            return new AdamsClient(baseUrl);
        }
    }
}
