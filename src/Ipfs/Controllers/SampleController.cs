using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace Ipfs.Controllers
{
    /// <summary>
    /// Registration Controller
    /// Allow mobile devices to register for push notifications
    /// </summary>
    [Route("api/[controller]")]
    public class SampleController : Controller
    {
        private ILogger<SampleController> Logger { get; }

        public SampleController(ILogger<SampleController> logger)
        {
            Logger = logger;
        }
    }
}
