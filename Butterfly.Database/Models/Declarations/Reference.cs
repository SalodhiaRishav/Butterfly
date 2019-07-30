using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Butterfly.Database.Models
{
    public class ReferenceModel
    {
        public String ReferenceId { get; set; }
        public String Reference { get; set; }
        public String InvoiceDate { get; set; }
        public String Type { get; set; }
    }
}
