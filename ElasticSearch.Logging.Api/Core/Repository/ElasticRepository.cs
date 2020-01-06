using ElasticSearch.Logging.Api.Core.DbContext;
using Nest;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ElasticSearch.Logging.Api.Core.Repository
{
    public class ElasticRepository : IElasticRepository
    {
        private readonly IDbContextFactory DbContextFactory;

        public ElasticRepository(
            IDbContextFactory dbContextFactory)
        {
            this.DbContextFactory = dbContextFactory;
        }

        public IndexResult Index<T>(T document) where T : class
        {
            ElasticClient elasticClient = this.DbContextFactory.GetDbContext() as ElasticClient;

            string indexName = typeof(T).Name.ToLower();

            var response = elasticClient.Index(document, i => i.Index(indexName));

            return new IndexResult
            {
                Id = response.Id,
                Exception = response.OriginalException,
                IsValid = response.IsValid,
                ResponseMessage = response.DebugInformation
            };
        }

        public Task<IndexResult> IndexAsync<T>(T document) where T : class
        {
            ElasticClient elasticClient = this.DbContextFactory.GetDbContext() as ElasticClient;

            string indexName = typeof(T).Name.ToLower();

            var task = elasticClient.IndexAsync(document, i => i.Index(indexName));

            return task.ContinueWith(t => new IndexResult
            {
                Id = t.Result.Id,
                Exception = t.Result.OriginalException,
                IsValid = t.Result.IsValid,
                ResponseMessage = t.Result.DebugInformation
            });
        }
    }
}
