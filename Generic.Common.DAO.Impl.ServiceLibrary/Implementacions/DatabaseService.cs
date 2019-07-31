using System;
using System.Collections.Generic;
using System.Data;
using System.Globalization;
using Generic.Common.DAO.Contracts.ServiceLibrary;
using Generic.Common.DAO.Contracts.ServiceLibrary.DTO;
using Generic.Common.DAO.Impl.ServiceLibrary.Configuration;
using Generic.Common.DAO.Impl.ServiceLibrary.Exceptions;
using Generic.Common.DAO.Impl.ServiceLibrary.Helpers;
using Generic.Common.DAO.Impl.ServiceLibrary.Helpers.CollectionMapper;

namespace Generic.Common.DAO.Impl.ServiceLibrary
{
    public class DatabaseService : IDaoServiceCrud
    {
        private readonly ISqlServerDatabase _conn;
        public DatabaseService(ISqlServerDatabase sqlServerDatabase)
        {
            this._conn = sqlServerDatabase;
        }

        public void Dispose() => this.Dispose(true);

        protected virtual void Dispose(bool dispose) => GC.SuppressFinalize(this);

        public IList<CovalcoDTO> GetAllData()
        {
            try
            {
                return SqlCmd.NewTextCommand(this._conn.DatabaseConnString)
                    .SetCommandText(@"SELECT TOP (1000) [AirportCode]
                                  ,[CurrencyCode]
                                  ,[Rate]
                                  ,[TaxAmount]
                                  ,[RTOrder]
                                  ,[Details]
                                  ,[CountryCode]
                                  ,[TaxCode]
                                  ,[TaxDefinition]
                                  ,[RemittanceBySelling]
                                  ,[RemittanceByLifting]
                                  ,[AppliedOnDeparture]
                                  ,[AppliedOnArrival]
                                  ,[LastModified]
                                  ,[InsertedDate]
                              FROM [Connectio].[dbo].[CovalcoDetails]")
                    .Execute().ToList<CovalcoDTO>();
            }
            catch (Exception ex)
            {
                throw new SqlServerException("", ex);
            }
        }

        public void insertBulk(IList<CovalcoDTO> airportTaxes)
        {
            this.truncateTable("CovalcoDetails");
            SqlBulk.BulkInsertByTake(_conn.DatabaseConnString, "CovalcoDetails", airportTaxes);
        }

        private void truncateTable(string tableName)
        {
            try
            {
                SqlCmd.NewTextCommand(_conn.DatabaseConnString).SetCommandText($"Truncate Table {tableName}").Execute();
            }
            catch (Exception ex)
            {
                throw new Exception($"Error Truncating all data from {tableName} table", ex);
            }
        }
    }
}
