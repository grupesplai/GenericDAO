using Generic.Common.DAO.Contracts.ServiceLibrary.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Generic.Common.DAO.UnitTest.ServiceLibrary.DTOMocks
{
    public class DataToMapper
    {
        public DataToMapper()
        {

        }
        public Guid Id { get; set; }

        public Guid IdOptional { get; set; }

        public string Key { get; set; }

        public Status Status { get; set; }

        public Code CodeValue { get; set; }

        public int? Order { get; set; }

        public decimal? Amount { get; set; }

        public DateTime CreatedDate { get; set; }
    }
}
