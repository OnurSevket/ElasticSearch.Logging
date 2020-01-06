using ElasticSearch.Logging.Api.Core.DbContext;
using ElasticSearch.Logging.Api.Core.Mapping;
using ElasticSearch.Logging.Api.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ElasticSearch.Logging.Api.Domain.Mapping
{
    public class TransactionLogMap : ElasticMapping, IElasticMapping
    {
        public TransactionLogMap(
    IDbContextFactory dbContextFactory)
    : base(dbContextFactory)
        {
        }

        public void Map()
        {
            base.CreateIndex<TransactionLog>();
        }
    }
}
