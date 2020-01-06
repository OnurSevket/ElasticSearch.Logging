using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ElasticSearch.Logging.Api.Contracts.TransactionLog
{
    public class TransactionLogRequestDto
    {
        public long? UserId { get; set; }
        public string Username { get; set; }
        public DateTime RequestDate { get; set; }
        public DateTime ResponseDate { get; set; }
        public string ApplicationCode { get; set; }
        public string ServiceName { get; set; }
        public string MethodName { get; set; }
        public string Inputs { get; set; }
        public string Outputs { get; set; }
        public string PermissionCode { get; set; }
        public string PermissionLogInfo { get; set; }
        public int? PermissionProcessType { get; set; }
        public string Token { get; set; }
        public string TrackId { get; set; }
        public string ClientIp { get; set; }
        public int? RequestChannelType { get; set; }
    }
}
