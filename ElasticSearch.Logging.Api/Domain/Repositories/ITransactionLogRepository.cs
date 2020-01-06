using ElasticSearch.Logging.Api.Core.Repository;
using ElasticSearch.Logging.Api.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ElasticSearch.Logging.Api.Domain.Repositories
{
    public interface ITransactionLogRepository
    {
        IndexResult Save(TransactionLog transactionLog);
        Task<IndexResult> SaveAsync(TransactionLog transactionLog);
    }
}
