using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Citrix.Microservices.Utilities.Response;
using Ipfs.Models;

namespace Citrix.ContentCollaboration.Services.Ipfs.Services
{
    public interface IIpfsService
    {
        Task<ResponseWrapper<IpfsModel>> Add(string sfItemId);

        Task<ResponseWrapper<IpfsModel>> Create(string sfItemId);
    }
}
