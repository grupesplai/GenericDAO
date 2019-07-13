using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Generic.Common.DAO.Contracts.ServiceLibrary.Connection
{
    public interface IConnectionString //la implementacion tiene que ir capa superior(WCF, webui)
    {
        string ConnectionString { get; }
    }
}
