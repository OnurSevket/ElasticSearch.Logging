using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ElasticSearch.Logging.Api.Core.Repository
{
    public class IndexResult
    {
        public string Id { get; set; }
        public bool IsValid { get; set; }
        public string ResponseMessage { get; set; }
        public Exception Exception { get; set; }
    }
}
