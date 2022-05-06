using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Ipfs.Models;
using Ipfs.Http;
using Citrix.Microservices.Utilities.Response;
using Citrix.Microservices.AsyncProcessing.ShareFileApi;
using ShareFile.Api.Client;
using Microsoft.Extensions.Logging;
using Citrix.Microservices.Extensions.Logging;
using Microsoft.Extensions.Options;
using Citrix.ContentCollaboration.Services.Ipfs.ConfigModels;

// using ShareFile.Api.Client.Exceptions;
// using ShareFile.Api.Client.Models;
// using ShareFile.Api.Client.Transfers;
namespace Citrix.ContentCollaboration.Services.Ipfs.Services
{
    public class IpfsService : IIpfsService
    {
        private readonly ILogger _logger;
        private readonly IpfsClient _ipfsClient;
        private readonly IInternalShareFileClientFactory _sfClientFactory;
        private readonly AccountConfig _configuration;

        public IpfsService(ILogger<IpfsService> logger, IpfsClient ipfsClient, IInternalShareFileClientFactory sfClientFactory, IOptions<AccountConfig> configuration)
        {
            _logger = logger;
            _ipfsClient = ipfsClient;
            _sfClientFactory = sfClientFactory;
            _configuration = configuration.Value;
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

            Console.WriteLine("Subdomain: " + (string)_configuration.Subdomain);

            // pins the object so it won't be gc'd
            await _ipfsClient.Pin.AddAsync(fsn.Id, true);

            var model = new IpfsModel
            {
                ItemId = itemId,
                Cid = fsn.Id,
            };

            var client = await CreateShareFileClientAsync();
            var capabilities = await client.Capabilities.Get().ExecuteAsync();

            return ResponseWrapper<IpfsModel>.CreateSuccess(model);
        }

        private async Task<IInternalShareFileClient> CreateShareFileClientAsync()
        {
            try
            {
                IInternalShareFileClient client = await _sfClientFactory.GetInternalShareFileClientWithPasswordAsync(_configuration.Subdomain, _configuration.Username, _configuration.Password);
                return client;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, new EventState(new Dictionary<string, object>
                {
                    { "Client Auth Fail", _configuration.Subdomain }
                }));

                throw;
            }
        }
    }
}
