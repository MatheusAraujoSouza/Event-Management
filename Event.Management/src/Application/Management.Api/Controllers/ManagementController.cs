using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;

namespace Management.Api.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ManagementController : ControllerBase
    {
        private readonly ILogger<ManagementController> _logger;
        private readonly IConfiguration _configuration;
        private readonly IConfigurationRoot _configurationRoot;

        public ManagementController(ILogger<ManagementController> logger, IConfiguration configuration, IConfigurationRoot configurationRoot)
        {
            _logger = logger;
            _configuration = configuration;
            _configurationRoot = configurationRoot;
        }

        [HttpGet]
        public IActionResult Get()
        {
            try
            {
                var configurationKeys = _configuration.AsEnumerable().Select(x => x.Key);
                var configurationKeysRoot = _configurationRoot.AsEnumerable().Select(x => x.Key);

                // Access properties from IConfiguration
                var allowedHosts = _configuration["Logging:LogLevel:Default"];
                var allowedHost2s = _configurationRoot["Logging:LogLevel:Default"];




                // Your controller logic
                // ...

                return Ok("Hello World");
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error occurred while getting data");
                return StatusCode(500, "An error occurred");
            }
        }
    }
}