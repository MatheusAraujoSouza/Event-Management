using Management.Api.Entities.Configurations;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace Management.Api.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ManagementController : ControllerBase
    {
        private readonly ILogger<ManagementController> _logger;
        private readonly IConfiguration _configuration;
        private readonly AppSettings _appSettings;

        public ManagementController(ILogger<ManagementController> logger, IConfiguration configuration, AppSettings appSettings)
        {
            _logger = logger;
            _configuration = configuration;
            _appSettings = appSettings;
        }

        [HttpGet]
        public IActionResult Get()
        {
            try
            {
                // Access properties from AppSettings
                //var allowedHosts = _appSettings.AllowedHosts;
                //var swaggerEnabled = _appSettings.Swagger.Enable;
                //var serverPort = _appSettings.Server.Port;

                // ...
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error occurred while getting data");
                return StatusCode(500, "An error occurred");
            }

            return Ok("Hello World");
        }
    }
}