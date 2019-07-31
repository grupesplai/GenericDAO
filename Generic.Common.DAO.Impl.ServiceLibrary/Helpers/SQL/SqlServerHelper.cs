using System;
using System.Data;
using System.Data.SqlClient;
using System.Collections.Generic;
using Generic.Common.DAO.Contracts.ServiceLibrary.Connection;
using System.Data.OleDb;

namespace Generic.Common.DAO.Impl.ServiceLibrary.Helpers
{
    public class SqlServerHelper
    {
        public static DataSet GetDataSet(IConnectionString connDao, CommandType type, string SQL)
        {
            return GetDataSet(connDao, type, SQL, null);
        }

        public static DataSet GetDataSet(IConnectionString connDao, CommandType type, string SQL, IList<SqlParameter> parameters)
        {
            using (SqlConnection conn = new SqlConnection(connDao.ConnectionString))
            {
                return getDataSetFromSqlDB(type, parameters, SQL, conn, true);
            }
        }

        private static DataSet getDataSetFromSqlDB(CommandType type, IList<SqlParameter> parameters, string SQL, SqlConnection conn, bool closeConn)
        {
            SqlDataAdapter da = new SqlDataAdapter();
            SqlCommand cmd = conn.CreateCommand();
            cmd.CommandType = type;

            if (parameters != null)
                foreach (var param in parameters)
                    cmd.Parameters.Add(param);

            cmd.CommandTimeout = 3600;
            cmd.CommandText = SQL;
            da.SelectCommand = cmd;
            DataSet ds = new DataSet();

            if (conn.State != ConnectionState.Open)
                conn.Open();

            da.Fill(ds);

            if (closeConn)
                conn.Close();

            return ds;
        }
    }
}
