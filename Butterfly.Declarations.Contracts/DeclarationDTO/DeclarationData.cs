using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Butterfly.Declarations.Contracts.DeclarationDTO
{
    public class DeclarationData
    {
        public DeclarationDto Declaration { get; set; }
        public IEnumerable<ReferenceDto> ReferenceData { get; set; }
    }
}
