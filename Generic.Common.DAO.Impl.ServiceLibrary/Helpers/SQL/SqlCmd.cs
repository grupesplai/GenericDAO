using System;
using System.Data;
using System.Data.SqlClient;
using System.Collections.Generic;
using Generic.Common.DAO.Contracts.ServiceLibrary.Connection;

namespace Generic.Common.DAO.Impl.ServiceLibrary.Helpers
{
    public class SqlCmd
    {
        public SqlCmd(IConnectionString connDao)
        {
            this.Connection = connDao;
        }

        private IList<SqlParameter> parameters { get; set; }

        public IConnectionString Connection { get; private set; }

        public CommandType CommandType { get; private set; }

        public string CommandText { get; private set; }

        public SqlCmd SetCommandText(string cmdText)
        {
            this.CommandText = cmdText;
            return this;
        }

        public SqlCmd AddParameter(string paramName, object paramValue)
        {
            if (this.parameters == null) this.parameters = new List<SqlParameter>();
            this.parameters.Add(new SqlParameter(paramName, paramValue));

            return this;
        }

        public static SqlCmd NewTextCommand(IConnectionString connDao) => 
            new SqlCmd(connDao) { CommandType = CommandType.Text};


        public DataSet Execute()
        {
            if (this.parameters == null)
                return SqlServerHelper.GetDataSet(this.Connection, this.CommandType, this.CommandText);
            else
                return SqlServerHelper.GetDataSet(this.Connection, this.CommandType, this.CommandText, this.parameters);
        }
    }
}
