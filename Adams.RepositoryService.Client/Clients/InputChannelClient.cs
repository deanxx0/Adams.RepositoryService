using Adams.RepositoryService.Client.Interfaces;
using Adams.RepositoryService.Client.Utils;
using Adams.RepositoryService.Models;
using NAVIAIServices.RepositoryService.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace Adams.RepositoryService.Client.Clients
{
    internal class InputChannelClient : IInputChannelClient
    {
        private readonly HttpRequester<InputChannel> _httpRequester;
        public InputChannelClient(string projectId, HttpClient httpClient)
        {
            _httpRequester = new HttpRequester<InputChannel>(projectId, httpClient);
        }

        public InputChannel Create(CreateInputChannel createInputChannel)
        {
            var inputChannel = _httpRequester.PostAsync(createInputChannel).Result;
            return inputChannel;
        }

        public List<InputChannel> GetAll()
        {
            var inputChannels = _httpRequester.GetListAsync().Result;
            return inputChannels;
        }

        public InputChannel Get(string inputChannelId)
        {
            var inputChannel = _httpRequester.GetAsync(inputChannelId).Result;
            return inputChannel;
        }        

        public InputChannel Delete(string inputChannelId)
        {
            var inputChannel = _httpRequester.DeleteAsync(inputChannelId).Result;
            return inputChannel;
        }
    }
}
