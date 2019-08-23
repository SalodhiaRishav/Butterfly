namespace Butterfly.web.Declaration
{
    using System;
    using System.Collections.Generic;

    using Butterfly.Declarations.Application.Services;
    using Butterfly.Declarations.Contracts.DeclarationDTO;
    using Butterfly.Declarations.Contracts.EndPoints;
    using Butterfly.web.CommonResponse;

    using Serilog;
    using ServiceStack.ServiceInterface;

    public class GetAllDeclarations : Service
    {
        private readonly DeclarationBll declarationBll;
        public GetAllDeclarations()
        {
            declarationBll = new DeclarationBll();
        }

        public OperationResponse<IEnumerable<DeclarationDto>> GET(GetAllDeclaration  Request)
        {
            OperationResponse<IEnumerable<DeclarationDto>> response = new OperationResponse<IEnumerable<DeclarationDto>>();
            try
            {
                var data = declarationBll.GetAllDeclaration();
                response.OnSuccess(data, "Declarations Fecthed Successfully");
                return response;
            }
            catch(Exception e)
            {
                Log.Error(e.Message+" "+e.StackTrace);
                response.OnException("Declaration failed to fetched");
                return response;
            }
        }
    }
}