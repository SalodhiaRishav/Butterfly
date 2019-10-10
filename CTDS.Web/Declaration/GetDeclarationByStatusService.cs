namespace CTDS.Web.Declaration
{
    using CTDS.Declarations.Contracts.DeclarationDTO;
    using CTDS.Declarations.Contracts.EndPoints;
    using CTDS.Declarations.Contracts.Interface;
    using CTDS.Web.CommonResponse;
    using Serilog;
    using ServiceStack.ServiceInterface;
    using System;
    using System.Collections.Generic;

    public class GetDeclarationByStatusService : Service
    {
        private readonly IDeclarationBll DeclarationBll;
        public GetDeclarationByStatusService(IDeclarationBll declarationBll)
        {
            DeclarationBll = declarationBll;
        }
        public OperationResponse<List<DeclarationTableDto>> Post(GetDeclarationByStatus req)
        {
            OperationResponse<List<DeclarationTableDto>> response = new OperationResponse<List<DeclarationTableDto>>();
            try
            {
                var res = DeclarationBll.GetDeclarationByStatus(req.DeclarationStatus, req.StartDate, req.EndDate);
                if(res != null)
                {
                    response.OnSuccess(res, "Declaration successfully fetched");
                    return response;
                }
                else
                {
                    response.OnError("No case found!!!", null);
                    return response;
                }
            }
            catch (Exception e)
            {
                Log.Error(e.Message + " " + e.StackTrace);
                response.OnException(e.Message);
                return response;
            }
        }

        public OperationResponse<List<DeclarationChartDataDto>> Post(GetDeclarationDashboardChartData req)
        {
            OperationResponse<List<DeclarationChartDataDto>> response = new OperationResponse<List<DeclarationChartDataDto>>();
            try
            {
                var res = DeclarationBll.GetDeclarationChartData(req.DeclarationStatus, req.StartDate, req.EndDate);
                if (res != null)
                {
                    response.OnSuccess(res, "Declaration successfully fetched");
                    return response;
                }
                else
                {
                    response.OnError("No Declarations found!!!", null);
                    return response;
                }
            }
            catch (Exception e)
            {
                Log.Error(e.Message + " " + e.StackTrace);
                response.OnException(e.Message);
                return response;
            }
        }


    }
}