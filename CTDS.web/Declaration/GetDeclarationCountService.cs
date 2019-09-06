namespace CTDS.Web.Declaration
{
    using System;

    using CTDS.Declarations.Contracts.EndPoints;
    using CTDS.Declarations.Contracts.Interface;
    using CTDS.Web.CommonResponse;

    using Serilog;
    using ServiceStack.ServiceInterface;
   
    public class GetDeclarationCountService :Service
    {
        private readonly IDeclarationBll DeclarationBll;
        public GetDeclarationCountService(IDeclarationBll declarationBll)
        {
            DeclarationBll = declarationBll;
        }
        public OperationResponse<int> Get(GetDeclarationCount req)
        {
            OperationResponse<int> response = new OperationResponse<int>();
            try
            {
                var res = DeclarationBll.GetCount();
                response.OnSuccess(res, "Declaration Count Returned Successfully");
                return response;
            }
            catch (Exception e)
            {
                Log.Error(e.Message + " " + e.StackTrace);
                response.OnException("Request to get Declaration Count Failed at server side");
                return response;
            }
        }

    }
}