using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Text;

namespace SignalrDotnetCoreApi.Common.Configuration
{
    public interface IConfigurationParser
    {
        IConfigurationSection GetSection(string name);

        T Get<T>(string sectionName, string itemName);
    }

    public class ConfigurationParser : IConfigurationParser
    {
        public IConfiguration _configuration { get; }

        public ConfigurationParser(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        public IConfigurationSection GetSection(string name)
        {
            return _configuration.GetSection(name);
        }

        public T Get<T>(string sectionName, string itemName)
        {
            var rawValue = _configuration.GetSection(sectionName)[itemName];

            var result = (T)Convert.ChangeType(rawValue, typeof(T));

            return result;
        }
    }
}
