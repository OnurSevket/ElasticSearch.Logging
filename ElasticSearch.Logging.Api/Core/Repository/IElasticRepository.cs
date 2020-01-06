using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ElasticSearch.Logging.Api.Core.Repository
{
    public interface IElasticRepository
    {
        IndexResult Index<T>(T document) where T : class;
        Task<IndexResult> IndexAsync<T>(T document) where T : class;

    }
}
