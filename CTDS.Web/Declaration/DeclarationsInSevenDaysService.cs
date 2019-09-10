namespace CTDS.Web.Declaration
{
    using System;

    using CTDS.Declarations.Contracts.EndPoints;
    using CTDS.Declarations.Contracts.Interface;
    using CTDS.Web.CommonResponse;

    using Serilog;
    using ServiceStack.ServiceInterface;

    public class DeclarationsInSevenDaysService : Service
    {
        private readonly IDeclarationBll DeclarationBll;
        public DeclarationsInSevenDaysService(IDeclarationBll declarationBll)
        {
            DeclarationBll = declarationBll;
        }
        public OperationResponse<int> GET(CountOfSevenDays req) 
        {
            OperationResponse<int> response = new OperationResponse<int>();
            try
            {
                int data = DeclarationBll.GetCountForLastSevenDays();
                response.OnSuccess(data, "Fetched Successfully");
                return response;
            }
            catch(Exception e)
            {
                Log.Error(e.Message + " " + e.StackTrace);
                response.OnException("Server Side Error");
                return response;
            }
        }
    }
}