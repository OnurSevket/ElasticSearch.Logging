using ElasticSearch.Logging.Api.Core.DbContext;
using ElasticSearch.Logging.Api.Core.Repository;
using ElasticSearch.Logging.Api.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ElasticSearch.Logging.Api.Domain.Repositories
{
    public class TransactionLogRepository : ElasticRepository, ITransactionLogRepository
    {
        private readonly IDbContextFactory DbContextFactory;

        public TransactionLogRepository(
             IDbContextFactory dbContextFactory)
             : base(dbContextFactory)
        {
            this.DbContextFactory = dbContextFactory;
        }

        public IndexResult Save(TransactionLog transactionLog)
        {
            return base.Index<TransactionLog>(transactionLog);
        }
        public Task<IndexResult> SaveAsync(TransactionLog transactionLog)
        {
            return base.IndexAsync<TransactionLog>(transactionLog);
        }
    }
}
