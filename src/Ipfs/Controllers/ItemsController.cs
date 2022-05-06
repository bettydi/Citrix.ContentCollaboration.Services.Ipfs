using System.Net;
using System.Threading.Tasks;
using Citrix.ContentCollaboration.Services.Ipfs.Services;
using Ipfs.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Swashbuckle.AspNetCore.Annotations;

namespace Ipfs.Controllers
{
    /// <summary>
    /// Items Controller
    /// Provides basic guidelines for the Api/Controller Description.
    /// </summary>
    [Route("api/[controller]")]
    [Produces("application/json")]
    public class ItemsController : Controller
    {
        private readonly ILogger _logger;
        private readonly IIpfsService _ipfsService;

        public ItemsController(ILogger<ExampleController> logger, IIpfsService ipfsService)
        {
            _logger = logger;
            _ipfsService = ipfsService;
        }

        /// <summary>
        /// Get Cid by Item id
        /// </summary>
        [HttpGet]
        [ProducesResponseType((int)HttpStatusCode.OK)]
        [ProducesResponseType((int)HttpStatusCode.NotFound)]
        [SwaggerOperation(
            OperationId = "My Operation Id 1",
            Summary = "Example Get Request",
            Description = "Example Get call request")]
        public IActionResult GetCid()
        {
            _logger.LogDebug("Get");
            return Ok(new TestModel() { Name = "Test" });
        }

        /// <summary>
        /// Get CID for Item with itemID
        /// </summary>
        /// <example>
        /// GET: api/Items/8
        /// </example>
        /// <param name="itemId">itemId</param>
        /// <response code="200">Returns the CID for item</response>
        /// <response code="404">If the item is null</response>
        [HttpGet("{itemId}/Cid")]
        [ProducesResponseType((int)HttpStatusCode.OK)]
        [ProducesResponseType(typeof(Citrix.Microservices.Models.Error), (int)HttpStatusCode.NotAcceptable)]
        [ProducesResponseType(typeof(Citrix.Microservices.Models.Error), (int)HttpStatusCode.NotFound)]
        [SwaggerOperation(
            OperationId = "My Operation Id 2",
            Summary = "Example Get Request with Id",
            Description = "Example Get call request")]
        public async Task<IActionResult> GetCid(string itemId)
        {
            // TODO: this would lookup CID by itemId
            // simple test to write a new file to IPFS
            _logger.LogDebug("GetCid_itemId");
            var result = await _ipfsService.Create(itemId);

            // TODO: CreatedResult - Created(201)
            return Ok(result);

            // exaple response:
            // ResponseWrapper
            // {
            // "payload": {
            //   "itemId": "{id}",
            //   "cid": "{cid}"
            // },
            // "isSuccessful": true,
            // "code": {
            //   "key": "Success",
            //   "value": 100
            // }
            // }
        }

        /// <summary>
        /// Post Items Request
        /// </summary>
        /// <example>
        /// POST: api/Items
        /// </example>
        /// <param name="value">value from body</param>
        [HttpPost]
        [ProducesResponseType((int)HttpStatusCode.Created)]
        [ProducesResponseType((int)HttpStatusCode.UnsupportedMediaType)]
        [ProducesResponseType((int)HttpStatusCode.Conflict)]
        [ProducesResponseType((int)HttpStatusCode.BadRequest)]
        [SwaggerOperation(
            OperationId = "POST",
            Summary = "Publish Item to IPFS",
            Description = "Publish Item to IPFS and return the CID")]
        public IActionResult Post([FromBody]IpfsModel value)
        {
            _logger.LogDebug("Post");
            return Created(Url.RouteUrl(1), 1);
        }
    }
}
