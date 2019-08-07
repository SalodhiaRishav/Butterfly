using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Butterfly.Declarations.Contracts.EndPoints
{
    using ServiceStack.ServiceHost;
    using Butterfly.Declarations.Contracts.DeclarationDTO;
    [Route("/getdropdownitems/{ListType}","GET")]
    public class GetDropDownItems
    {
        public String ListType { get; set; } 
    }
}
