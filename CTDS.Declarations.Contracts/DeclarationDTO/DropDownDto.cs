using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CTDS.Declarations.Contracts.DeclarationDTO
{
    public class DropDownDto
    {
        public Guid Id { get; set; }
        public String Type { get; set; }
        public String Key { get; set; }
        public String Value { get; set; }
    }
}
