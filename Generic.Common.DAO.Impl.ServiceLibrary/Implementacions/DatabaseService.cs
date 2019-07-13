using System;
using System.Collections.Generic;
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

        public List<CovalcoDTO> GetAllData()
        {
            try
            {
                var covalcoDtos = SqlCmd.NewTextCommand(this._conn.DatabaseConnString)
                    .SetCommandText(@"
                        SELECT TOP (1000) [DepartureStation]
                                    ,[ConnectionStation]
                                    ,[ArrivalStation]
                                    ,[Class]
                                    ,[FeeConnection]
                                    ,[LongConnection]
                                FROM [Connectio].[dbo].[ConnectionFeePrice]")
                    .Execute().ToList<CovalcoDTO>();
                return covalcoDtos;
            }
            catch (Exception ex)
            {
                throw new SqlServerException("", ex);
            }
        }
    }
}
