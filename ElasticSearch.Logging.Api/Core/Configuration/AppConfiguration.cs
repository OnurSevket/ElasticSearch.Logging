using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ElasticSearch.Logging.Api.Core.Configuration
{
    public class AppConfiguration
    {
        private readonly IOptions<AppSettings> Options;

        public AppConfiguration(
             IOptions<AppSettings> options)
        {
            this.Options = options;
        }

        public AppSettings AppSettings
        {
            get
            {
                return this.Options.Value;
            }
        }
    }
}
