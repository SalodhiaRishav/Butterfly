using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Butterfly.Database.Models
{
   public class Consignor
    {
        public int ConsignorId { get; set; }
        public String Name { get; set; }

        public String Address1 { get; set; }

        public String Address2 { get; set; }

        public String PostalCode { get; set; }

        public String City { get; set; }

        public String Country { get; set; }
    }
}
