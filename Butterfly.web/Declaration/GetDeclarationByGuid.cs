using ServiceStack.ServiceInterface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Butterfly.web.Declaration
{
    using Butterfly.web.CommonResponse;
    using Butterfly.Declarations.Application.Services;
    using Butterfly.Declarations.Contracts.DeclarationDTO;
    public class GetDeclarationByGuid : Service
    {
        private readonly DeclarationBll declarationBll;
        public GetDeclarationByGuid()
        {
            declarationBll = new DeclarationBll();
        }

        public OperationResponse<DeclarationDto> GET(Guid id)
        {
            OperationResponse<DeclarationDto> response = new OperationResponse<DeclarationDto>();
            try
            {
                var data = declarationBll.GetDeclarationById(id);
                response.OnSuccess(data, "Declaration successfully fetched");
                return response;
            }
            catch(Exception e)
            {
                response.OnException("Failed to Fetch declaration");
                return response;
            }
        }

    }
}