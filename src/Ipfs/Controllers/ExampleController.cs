using System.Net;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Ipfs.Models;
using Swashbuckle.AspNetCore.Annotations;

namespace Ipfs.Controllers
{
    /// <summary>
    /// Example Controller
    /// Provides basic guidelines for the Api/Controller Description.
    /// </summary>
    [Route("api/[controller]")]
    [Produces("application/json")]
    public class ExampleController : Controller
    {
        private readonly ILogger _logger;

        public ExampleController(ILogger<ExampleController> logger)
        {
            _logger = logger;
        }

        /// <summary>
        /// Get Example Request
        /// </summary>
        [HttpGet]
        [ProducesResponseType((int)HttpStatusCode.OK)]
        [ProducesResponseType((int)HttpStatusCode.NotFound)]
        [SwaggerOperation(
            OperationId = "My Operation Id 1",
            Summary = "Example Get Request",
            Description = "Example Get call request")]
        public IActionResult Get()
        {
            _logger.LogDebug("Get");
            return Ok(new TestModel() { Name = "Test" });
        }

        /// <summary>
        /// Get Example Request with Id
        /// </summary>
        /// <example>
        /// GET: api/Example/8
        /// </example>
        /// <param name="id">Id</param>
        /// <response code="200">Returns the item</response>
        /// <response code="404">If the item is null</response>
        [HttpGet("{id}")]
        [ProducesResponseType((int)HttpStatusCode.OK)]
        [ProducesResponseType(typeof(Citrix.Microservices.Models.Error), (int)HttpStatusCode.NotAcceptable)]
        [ProducesResponseType(typeof(Citrix.Microservices.Models.Error), (int)HttpStatusCode.NotFound)]
        [SwaggerOperation(
            OperationId = "My Operation Id 2",
            Summary = "Example Get Request with Id",
            Description = "Example Get call request")]
        public ActionResult<TestModel> Get(int id)
        {
            _logger.LogDebug("Get_id");
            return Ok(new TestModel() { Name = "Test" });
        }

        /// <summary>
        /// Post Example Request
        /// </summary>
        /// <example>
        /// POST: api/Example
        /// </example>
        /// <param name="value">value from body</param>
        [HttpPost]
        [ProducesResponseType((int)HttpStatusCode.Created)]
        [ProducesResponseType((int)HttpStatusCode.UnsupportedMediaType)]
        [ProducesResponseType((int)HttpStatusCode.Conflict)]
        [ProducesResponseType((int)HttpStatusCode.BadRequest)]
        [SwaggerOperation(
            OperationId = "My Operation Id 3",
            Summary = "Example Post Request",
            Description = "Example Post call request")]
        public IActionResult Post([FromBody]TestModel value)
        {
            _logger.LogDebug("Post");
            return Created(Url.RouteUrl(1), 1);
        }

        /// <summary>
        /// Delete Example Request
        /// </summary>
        /// <example>
        /// DELETE: api/Example/5
        /// </example>
        /// <param name="id">Id</param>
        [HttpDelete("{id}")]
        [ProducesResponseType((int)HttpStatusCode.OK)]
        [ProducesResponseType((int)HttpStatusCode.Conflict)]
        [ProducesResponseType((int)HttpStatusCode.NotFound)]
        [ProducesResponseType((int)HttpStatusCode.NoContent)]
        [SwaggerOperation(
            OperationId = "My Operation Id 4",
            Summary = "Example Delete Request with Id",
            Description = "Example Delete call request")]
        public IActionResult Delete(int id)
        {
            _logger.LogDebug("Delete_id");
            return StatusCode((int)HttpStatusCode.NoContent);
        }
    }
}
