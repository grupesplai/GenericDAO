using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Generic.Common.DAO.Impl.ServiceLibrary.Exceptions
{
    [Serializable]
    public class SqlServerException : Exception
    {
        public SqlServerException()
        {
        }

        public SqlServerException(string message) : base(message)
        {
        }

        public SqlServerException(string message, Exception innerException) : base(message, innerException)
        {
        }
    }
}
