using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Butterfly.Database.Models
{
    public class Consignee
    {
        public int ConsigneeId { get; set; }
        public String Name { get; set; }
        public String OrganisationNumber { get; set; }
        public String Address1 { get; set; }
        public String Address2 { get; set; }
        public String PostalCode { get; set; }
        public String City { get; set; }
        public String Country { get; set; }
        public String CustomCreditNumber { get; set; }

        public String DefferedPayment { get; set; }



    }
}
