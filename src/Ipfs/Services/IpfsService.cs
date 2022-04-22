using System;
using System.Threading.Tasks;
using Ipfs.Models;
using Ipfs.Http;
using Citrix.Microservices.Utilities.Response;

namespace Citrix.ContentCollaboration.Services.Ipfs.Services
{
    public class IpfsService : IIpfsService
    {
        private readonly IpfsClient _ipfsClient;

        public IpfsService(IpfsClient ipfsClient)
        {
            _ipfsClient = ipfsClient;
        }

        public async Task<ResponseWrapper<IpfsModel>> Add(string itemId)
        {
            // just tests that client connection was successful for now
            var peer = await _ipfsClient.IdAsync();
            throw new System.NotImplementedException();
        }

        public async Task<ResponseWrapper<IpfsModel>> Create(string itemId)
        {
            // create a new file with some text into to test that we can push a file
            var fsn = await _ipfsClient.FileSystem.AddTextAsync("Creating file with itemId: " + itemId);
            Console.WriteLine((string)fsn.Id);

            // pins the object so it won't be gc'd
            await _ipfsClient.Pin.AddAsync(fsn.Id, true);

            var model = new IpfsModel
            {
                ItemId = itemId,
                Cid = fsn.Id,
            };

            return ResponseWrapper<IpfsModel>.CreateSuccess(model);
        }
    }
}
