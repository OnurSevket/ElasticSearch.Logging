using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ElasticSearch.Logging.Api.Core.DbContext
{
    public interface IDbContextFactory
    {
        object GetDbContext();
    }
}
