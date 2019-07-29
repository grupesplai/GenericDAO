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

        public string InventoryKey { get; set; }

        public Status CarrierCode { get; set; }

        public CurrencyCode CurrencyCode { get; set; }

        public int? Lid { get; set; }

        public decimal? Price { get; set; }

        public DateTime CreatedDate { get; set; }
    }
}
