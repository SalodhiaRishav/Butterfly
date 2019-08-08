using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Butterfly.Declarations.Contracts.DeclarationDTO
{
    public class ReferenceDto
    {
        public Guid ReferenceId { get; set; }
        public string Type { get; set; }
        public string InvoiceDate { get; set; }
        public string Reference { get; set; }
        public Guid DeclarationId { get; set; }
    }
}
