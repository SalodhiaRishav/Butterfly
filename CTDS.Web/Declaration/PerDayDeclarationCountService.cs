namespace CTDS.Web.Declaration
{
    using System;
    using System.Collections.Generic;
    using CTDS.Declarations.Contracts.EndPoints;
    using CTDS.Declarations.Contracts.Interface;
    using CTDS.Web.CommonResponse;

    using Serilog;
    using ServiceStack.ServiceInterface;

    public class PerDayDeclarationCountService : Service
    {
        private readonly IDeclarationBll DeclarationBll;
        public PerDayDeclarationCountService(IDeclarationBll declarationBll)
        {
            DeclarationBll = declarationBll;
        }
        public OperationResponse<List<int>> GET(GetPerDayDeclarationCountLastWeek req)
        {
            OperationResponse<List<int>> response = new OperationResponse<List<int>>();
            try
            {
                var data = DeclarationBll.GetPerDayDeclarationCount();
                response.OnSuccess(data, "Fetched Successfully");
                return response;
            }
            catch (Exception e)
            {
                Log.Error(e.Message + " " + e.StackTrace);
                response.OnException("Server Side Error");
                return response;
            }
        }
    }
}