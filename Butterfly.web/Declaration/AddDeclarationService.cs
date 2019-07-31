using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
namespace Butterfly.web.Declaration
{
    using Butterfly.Declarations.Contracts.EndPoints;
    using Butterfly.Declarations.Contracts.DeclarationDTO;
    using ServiceStack.ServiceInterface;

    public class AddDeclarationService : Service
    {
        public bool POST(AddDeclaration NewDeclaration)
        {

            var declaration = NewDeclaration.NewDeclaration;
            // return 
            return true;
        }
    }
}