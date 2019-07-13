using Generic.Common.DAO.Contracts.ServiceLibrary.Connection;
using Generic.Common.DAO.Impl.ServiceLibrary.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Generic.Common.DAO.Impl.ServiceLibrary
{
    public class SqlServerDatabase : ISqlServerDatabase
    {
        public IConnectionString DatabaseConnString { get; set; }
    }
}
