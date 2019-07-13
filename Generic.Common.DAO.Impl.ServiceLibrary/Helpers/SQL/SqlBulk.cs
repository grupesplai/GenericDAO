using System.Linq;
using System.Data;
using System.Data.SqlClient;
using System.Collections.Generic;
using Generic.Common.DAO.Contracts.ServiceLibrary.Connection;
using Generic.Common.DAO.Impl.ServiceLibrary.Helpers.CollectionMapper;

namespace Generic.Common.DAO.Impl.ServiceLibrary.Helpers
{
    public class SqlBulk
    {
        private const int SQLBULK_BATCHSIZE = 100000;

        public static void BulkInsertByTake<TEntity>(IConnectionString taxConn, string tableName, IEnumerable<TEntity> collection)
        {
            int totalCount = collection.Count();
            int partialCount = 0;
            int skip = 0;

            while (partialCount <= totalCount)
            {
                var part = collection.Skip(skip).Take(SQLBULK_BATCHSIZE);
                bulkInsert(tableName, part, taxConn);
                partialCount = skip += SQLBULK_BATCHSIZE;
            }
        }

        private static void bulkInsert<TEntity>(string tableName, IEnumerable<TEntity> list, IConnectionString sqlConnection, IDictionary<string, string> columnMappings = null)
        {
            DataTable dataTable = list.ConvertToDataTable(columnMappings);

            var connection = new SqlConnection(sqlConnection.ConnectionString);

            if (connection.State != ConnectionState.Open)
            {
                connection.Open();
            }
            var transaction = connection.BeginTransaction();

            using (SqlBulkCopy bulkCopy = new SqlBulkCopy(connection, SqlBulkCopyOptions.Default | SqlBulkCopyOptions.KeepIdentity, transaction))
            {
                if (columnMappings != null)
                {
                    foreach (DataColumn dc in dataTable.Columns)
                    {
                        bulkCopy.ColumnMappings.Add(new SqlBulkCopyColumnMapping(dc.ColumnName, dc.ColumnName));
                    }
                }

                bulkCopy.DestinationTableName = tableName;
                bulkCopy.BatchSize = SQLBULK_BATCHSIZE;
                try
                {
                    bulkCopy.WriteToServer(dataTable);
                }
                catch
                {
                    transaction.Rollback();
                }
                finally
                {
                    if (transaction.Connection != null && transaction.Connection.State == ConnectionState.Open)
                    {
                        transaction.Commit();
                    }
                    connection.Close();
                    dataTable.Clear();
                    dataTable.Dispose();
                }
            }
        }
    }
}
