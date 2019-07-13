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

        public string DepartureStation { get; set; }

        public string ConnectionStation { get; set; }

        public string ArrivalStation { get; set; }

        public string Class { get; set; }

        public decimal FeeConnection { get; set; }

        public Status LongConnection { get; set; }
    }
}
