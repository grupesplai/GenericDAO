using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Generic.Common.DAO.Contracts.ServiceLibrary.DTO
{
    public class CovalcoDTO
    {
        public CovalcoDTO()
        {

        }

        public string AirportCode { get; set; }

        public string CurrencyCode { get; set; }

        public double Rate { get; set; }

        public string TaxAmount { get; set; }

        public int RTOrder { get; set; }

        public string Detail { get; set; }

        public string CountryCode { get; set; }

        public string TaxCode { get; set; }

        public string TaxDefinition { get; set; }

        public bool RemittanceBySelling { get; set; }

        public bool RemittanceByLifting { get; set; }

        public bool AppliedOnDeparture { get; set; }

        public bool AppliedOnArrival { get; set; }

        public DateTime LastModified { get; set; }

        public DateTime InsertedDate { get; set; } = DateTime.Now;
    }
}
