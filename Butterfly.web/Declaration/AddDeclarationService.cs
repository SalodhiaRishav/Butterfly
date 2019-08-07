using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
namespace Butterfly.web.Declaration
{
    using Butterfly.Declarations.Contracts.EndPoints;
   // using Butterfly.Declarations.Contracts.DeclarationDTO;
    using ServiceStack.ServiceInterface;
    using Butterfly.web.CommonResponse;
    using Butterfly.Declarations.Application.Services;

    public class AddDeclarationService : Service
    {
        private readonly DeclarationBll declarationBll;
       
        public AddDeclarationService()
        {
            declarationBll = new DeclarationBll();
        }
        public OperationResponse<bool> POST(AddDeclaration NewDeclaration)
        {
            OperationResponse<bool> response = new OperationResponse<bool>();
            try
            {
                var declaration = NewDeclaration.declaration;
                var data = declarationBll.AddDeclaration(declaration);
                response.OnSuccess(data, "Declaration Successfully added!");
                return response;
            }
            catch(Exception e)
            {
                response.OnException("Request to Add new declaration failed at server side.");
                return response;
            }
           
        }
    }
}