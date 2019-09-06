namespace CTDS.Web.Declaration
{
    using System;
    using System.Collections.Generic;
    using CTDS.Declarations.Contracts.DeclarationDTO;
    using CTDS.Declarations.Contracts.EndPoints;
    using CTDS.Declarations.Contracts.Interface;
    using CTDS.Web.CommonResponse;

    using Serilog;
    using ServiceStack.ServiceInterface;
    public class GetStatusCountService : Service
    {
        private readonly IDeclarationBll DeclarationBll;

        public GetStatusCountService(IDeclarationBll declarationBll)
        {
            DeclarationBll = declarationBll;
        }
        public OperationResponse<StatusDto> GET(GetStatusCount req)
        {
            OperationResponse<StatusDto> response = new OperationResponse<StatusDto>();
            try
            {
                var result = DeclarationBll.GetStatusCount();
                response.OnSuccess(result, "Success");
                return response;

            }
            catch(Exception e)
            {
                Log.Error(e.Message + " " + e.StackTrace);
                response.OnException("Failed Ay server side");
                return response;
            }
        }

    }
}