using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Butterfly.Database.Models
{
    public class DeliveryTransport
    {
        public int DeliveryTransportId { get; set; }
        public String TermsOfDelivery { get; set; }
        public String DeliveryPlace { get; set; }
        public String CountryOfDispatch { get; set; }
        public String NationalityOfTransport { get; set; }
        public String ModeOfTransport { get; set; }
        public String LocationOfGoods { get; set; }
        public String SupervisingCustomOffice { get; set; }
    }
}
