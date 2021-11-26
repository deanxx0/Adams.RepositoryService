using Adams.RepositoryService.Models;
using NAVIAIServices.RepositoryService.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Adams.RepositoryService.Client.Interfaces
{
    public interface IInputChannelClient
    {
        InputChannel Create(CreateInputChannel createInputChannel);
        List<InputChannel> GetAll();
        InputChannel Get(string inputChannelId);
        InputChannel Delete(string inputChannelId);
    }
}
