using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Butterfly.web.Declaration
{
    
    using ServiceStack.ServiceInterface;
    using Butterfly.web.CommonResponse;
    using Butterfly.Declarations.Contracts.EndPoints;
    using Butterfly.Declarations.Application.Services;

    public class EditDeclarationService : Service
    {
        private readonly DeclarationBll declarationBll;
        public EditDeclarationService()
        {
            declarationBll = new DeclarationBll();
        }
        public OperationResponse<bool> POST(EditDeclaration editDeclaration)
        {
            OperationResponse<bool> response = new OperationResponse<bool>();
            try
            {
                var newDeclaration = editDeclaration.declaration;
                var data = declarationBll.EditDeclaration(newDeclaration);
                response.OnSuccess(data, "Record Successfully Updated");
                return response;

            }
            catch(Exception e)
            {
                response.OnException("Error in updating record");
                return response;
            }
        }
    }
}