using Generic.Common.DAO.Contracts.ServiceLibrary.Connection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Generic.Common.DAO.Impl.ServiceLibrary.Configuration
{
    public interface ISqlServerDatabase
    {
        IConnectionString DatabaseConnString { get; }
    }
}
