namespace CTDS.web.Declaration
{
    using System;
    using System.Collections.Generic;

    using CTDS.Declarations.Application.Services;
    using CTDS.Declarations.Contracts.DeclarationDTO;
    using CTDS.Declarations.Contracts.EndPoints;
    using CTDS.web.Authentication.Filters;
    using CTDS.web.CommonResponse;
    using CTDS.Declarations.Contracts.Interface;

    using Serilog;
    using ServiceStack.ServiceInterface;

    [AuthFilter(RoleName = "User")]
    public class GetAllDeclarations : Service
    {
        private readonly IDeclarationBll DeclarationBll;
        public GetAllDeclarations(IDeclarationBll declarationBll)
        {
            DeclarationBll = declarationBll;
        }

        public OperationResponse<IEnumerable<DeclarationDto>> Get(GetAllDeclaration  request)
        {
            OperationResponse<IEnumerable<DeclarationDto>> response = new OperationResponse<IEnumerable<DeclarationDto>>();
            try
            {
                var data = DeclarationBll.GetAllDeclaration();
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