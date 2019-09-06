using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CTDS.Declarations.Contracts.DeclarationDTO
{
    public class StatusDto
    {
        public int Processing { get; set; }
        public int Cleared { get; set; }
        public int Rejected { get; set; }
    }
}
