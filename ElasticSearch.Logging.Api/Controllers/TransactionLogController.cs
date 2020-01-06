using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ElasticSearch.Logging.Api.Contracts.TransactionLog;
using ElasticSearch.Logging.Api.Domain.Models;
using ElasticSearch.Logging.Api.Domain.Services;
using Microsoft.AspNetCore.Mvc;

namespace ElasticSearch.Logging.Api.Controllers
{
    [Route("api/[controller]")]
    public class TransactionLogController : Controller
    {
        private readonly TransactionLogDomainService TransactionLogDomainService;

        public TransactionLogController(
            TransactionLogDomainService transactionLogDomainService)
        {
            this.TransactionLogDomainService = transactionLogDomainService;
        }

        [HttpPost("Save")]
        public async Task<IActionResult> Save([FromBody]TransactionLogRequestDto request)
        {
            var result = await this.TransactionLogDomainService.SaveTransactionLogAync(new TransactionLog
            {
                ApplicationCode = request.ApplicationCode,
                Inputs = request.Inputs,
                Outputs = request.Outputs,
                RequestDate = request.RequestDate,
                ResponseDate = request.ResponseDate,
                ServiceName = request.ServiceName,
                UserId = request.UserId,
                Username = request.Username,
                MethodName = request.MethodName,
                ClientIp = request.ClientIp,
                PermissionCode = request.PermissionCode,
                PermissionLogInfo = request.PermissionLogInfo,
                RequestChannelType = request.RequestChannelType,
                PermissionProcessType = request.PermissionProcessType,
                Token = request.Token,
                TrackId = request.TrackId
            });

            return Ok(result);
        }
    }
}