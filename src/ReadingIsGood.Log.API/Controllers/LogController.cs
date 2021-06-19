using System.Collections.Generic;
using System.Net;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using ReadingIsGood.Business.Attribute;
using ReadingIsGood.Business.DTO.Common;
using ReadingIsGood.Data.Interface;

namespace ReadingIsGood.Log.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class LogController : ControllerBase
    {
        private readonly ILogger<LogController> _logger;
        private readonly IAuditLogService _auditLogService;

        public LogController(ILogger<LogController> logger, IAuditLogService auditLogService)
        {
            _logger = logger;
            _auditLogService = auditLogService;
        }

        [HttpGet]
        [Authorize]
        public IActionResult Get()
        {
            var auditLogs = _auditLogService.All();

            if (auditLogs == null) throw new ApiException("An error occurred while fetching logs.", HttpStatusCode.NotFound);

            return Created(string.Empty, new HttpServiceResponse<IEnumerable<Data.Entity.AuditLog>> { Data = auditLogs, HttpStatusCode = HttpStatusCode.Found });
        }
    }
}