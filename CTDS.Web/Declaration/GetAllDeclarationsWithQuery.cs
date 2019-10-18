namespace CTDS.Web.Declaration
{
    using System;
    using System.Collections.Generic;

    using CTDS.Declarations.Contracts.DeclarationDTO;
    using CTDS.Declarations.Contracts.EndPoints;
    using CTDS.Web.Authentication.Filters;
    using CTDS.Web.CommonResponse;
    using CTDS.Declarations.Contracts.Interface;

    using Serilog;
    using ServiceStack.ServiceInterface;

    [AuthFilter(RoleName = "User")]
    public class GetAllDeclarationsWithQuery : Service
    {
        private readonly IDeclarationBll DeclarationBll;
        public GetAllDeclarationsWithQuery(IDeclarationBll declarationBll)
        {
            DeclarationBll = declarationBll;
        }

        public OperationResponse<FilterDeclarationsDto> Post(GetDeclarationsWithQuery request)
        {
            OperationResponse<FilterDeclarationsDto> response = new OperationResponse<FilterDeclarationsDto>();
            try
            {
                var data = DeclarationBll.GetAllDeclarationsWithQuery(request.Queries,request.PageNumber,request.MaxRowsPerPage,request.SortBy,request.SortDesc);
                response.OnSuccess(data, "Declarations Fecthed Successfully");
                return response;
            }
            catch (Exception e)
            {
                Log.Error(e.Message + " " + e.StackTrace);
                response.OnException("Declaration failed to fetched");
                return response;
            }
        }
    }
}