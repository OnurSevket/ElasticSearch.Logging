using ElasticSearch.Logging.Api.Core.Configuration;
using System;
using Nest;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ElasticSearch.Logging.Api.Core.DbContext
{
    public class ElasticDbContextFactory : IDbContextFactory
    {
        private readonly AppConfiguration AppConfiguration;

        public ElasticDbContextFactory(
            AppConfiguration appConfiguration)
        {
            this.AppConfiguration = appConfiguration;
        }

        public object GetDbContext()
        {
            var uri = new Uri(this.AppConfiguration.AppSettings.DatabaseCnString);

            var settings = new ConnectionSettings(uri);

            return new ElasticClient(settings);
        }
    }
}
