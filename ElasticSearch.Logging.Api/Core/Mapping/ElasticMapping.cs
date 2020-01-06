using ElasticSearch.Logging.Api.Core.DbContext;
using ElasticSearch.Logging.Api.Core.Repository;
using Nest;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ElasticSearch.Logging.Api.Core.Mapping
{
    public class ElasticMapping
    {
        private readonly IDbContextFactory DbContextFactory;

        public ElasticMapping(
             IDbContextFactory dbContextFactory)
        {
            this.DbContextFactory = dbContextFactory;
        }

        public IndexResult CreateIndex<T>() where T : class
        {
            return this.CreateIndex<T>(null);
        }

        public virtual IndexResult CreateIndex<T>(CreateIndexDescriptor createIndexDescriptor) where T : class
        {
            ElasticClient elasticClient = this.DbContextFactory.GetDbContext() as ElasticClient;

            string indexName = typeof(T).Name.ToLower();
            string aliasName = string.Format("{0}_{1}", "alias", indexName);

            if (createIndexDescriptor == null)
            {
                createIndexDescriptor = new CreateIndexDescriptor(indexName)
                     .Mappings(ms => ms
                     .Map<T>(m => m.AutoMap()))
                     .Aliases(a => a.Alias(aliasName));
            }

            var request = new IndexExistsRequest(indexName);
            var result = elasticClient.Indices.Exists(request);
            if (result.Exists)
            {
                return null;
            }

            var response = elasticClient.Indices.Create(createIndexDescriptor);

            return new IndexResult
            {
                IsValid = response.IsValid,
                ResponseMessage = response.DebugInformation,
                Exception = response.OriginalException
            };
        }
    }
}
