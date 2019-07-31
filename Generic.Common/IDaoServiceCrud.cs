using Generic.Common.DAO.Contracts.ServiceLibrary.DTO;
using System;
using System.Collections.Generic;

namespace Generic.Common.DAO.Contracts.ServiceLibrary
{
    public interface IDaoServiceCrud : IDisposable
    {
        IList<CovalcoDTO> GetAllData();

        void insertBulk(IList<CovalcoDTO> covalcodto);
    }
}
