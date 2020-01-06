using ElasticSearch.Logging.Api.Core.Repository;
using ElasticSearch.Logging.Api.Domain.Models;
using ElasticSearch.Logging.Api.Domain.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ElasticSearch.Logging.Api.Domain.Services
{
    public class TransactionLogDomainService
    {
        private readonly ITransactionLogRepository TransactionLogRepository;

        public TransactionLogDomainService(
             ITransactionLogRepository transactionLogRepository)
        {
            this.TransactionLogRepository = transactionLogRepository;
        }

        public IndexResult SaveTransactionLog(
             TransactionLog transactionLog)
        {
            return this.TransactionLogRepository.Save(transactionLog);
        }

        public Task<IndexResult> SaveTransactionLogAync(
            TransactionLog transactionLog)
        {
            return this.TransactionLogRepository.SaveAsync(transactionLog);
        }
    }
}
