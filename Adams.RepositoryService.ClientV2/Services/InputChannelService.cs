using NAVIAIServices.RepositoryService.Entities;
using NAVIAIServices.RepositoryService.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace Adams.RepositoryService.ClientV2.Services
{
    public class InputChannelService : IInputChannelService
    {
        public InputChannelService()
        {

        }
        public void Add(InputChannel entity)
        {
            throw new NotImplementedException();
        }

        public int Count()
        {
            throw new NotImplementedException();
        }

        public IEnumerable<InputChannel> Find(Expression<Func<InputChannel, bool>> predicate)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<InputChannel> FindAll()
        {
            throw new NotImplementedException();
        }

        public void Update(InputChannel entity)
        {
            throw new NotImplementedException();
        }
    }
}
