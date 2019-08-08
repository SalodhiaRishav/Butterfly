using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Butterfly.Database.Models.Declarations
{
    public class ReferenceTable
    {
        public Guid ReferenceId { get; set; }
        public string Type { get; set; }
        public DateTime InvoiceDate { get; set; }
        public string Reference { get; set; }
        public Guid DeclarationId { get; set; }
    }
}
