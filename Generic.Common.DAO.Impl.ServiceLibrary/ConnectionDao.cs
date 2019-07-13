using Generic.Common.DAO.Contracts.ServiceLibrary.Connection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Generic.Common.DAO.Impl.ServiceLibrary
{
    public class ConnectionDao : IConnectionString
    {
        public ConnectionDao(string connString)
        {
            this.ConnectionString = connString;
        }

        public string ConnectionString { get; set; }
    }
}
