using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Anthill.Common.Data
{
    public abstract class AbstractConnectionConfiguration
    {
        /// <summary>
        /// Stores the connection name from config file.
        /// </summary>
        protected readonly string _connectionName;

        public AbstractConnectionConfiguration(string connectionName)
        {
            _connectionName = connectionName;
        }

        /// <summary>
        /// Returns a connection string.
        /// The implementer should either return a connection string from a configuration file or it could be a mock object if is used for testing.
        /// </summary>
        public string GetConnectionString()
        {
            return ConfigurationManager.ConnectionStrings[_connectionName].ConnectionString;
        }
    }
}
