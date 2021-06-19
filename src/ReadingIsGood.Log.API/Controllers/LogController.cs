using System.Collections.Generic;
using System.Net;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using ReadingIsGood.Business.Attribute;
using ReadingIsGood.Business.DTO.Common;
using ReadingIsGood.Data.Interface;
using ReadingIsGood.Data.Interface.UOW;

namespace ReadingIsGood.Log.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class LogController : ControllerBase
    {
        private readonly ILogger<LogController> _logger;
        private readonly IUnitOfWork _unitOfWork;

        public LogController(ILogger<LogController> logger, IUnitOfWork unitOfWork)
        {
            _logger = logger;
            _unitOfWork = unitOfWork;
        }

        [HttpGet]
        [Authorize]
        public IActionResult Get()
        {
            var auditLogs = _unitOfWork.AuditLogService.GetAll();

            if (auditLogs == null) throw new ApiException("An error occurred while fetching logs.", HttpStatusCode.NotFound);

            return Created(string.Empty, new HttpServiceResponse<IEnumerable<Data.Entity.AuditLog>> { Data = auditLogs, HttpStatusCode = HttpStatusCode.Found });
        }
    }
}