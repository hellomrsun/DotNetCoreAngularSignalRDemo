using System;
using System.Collections.Generic;
using System.Text;

namespace SignalrDotnetCoreApi.Common.Configuration
{
    public interface IConfigurationRetriever
    {
        string WineDbConnectionString { get; }
    }
    public class ConfigurationRetriever : IConfigurationRetriever
    {
        private readonly IConfigurationParser _parser;

        public ConfigurationRetriever(IConfigurationParser parser)
        {
            this._parser = parser;
        }

        public string WineDbConnectionString
        {
            get
            {
               return _parser.Get<string>("ConnectionStrings", "WineDbConnection");
            }
        }

    }
}
