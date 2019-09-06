namespace CTDS.Web.Declaration
{
    using System;
    using CTDS.Declarations.Contracts.DeclarationDTO;
    using CTDS.Declarations.Contracts.EndPoints;
    using CTDS.Declarations.Contracts.Interface;
    using CTDS.Web.CommonResponse;

    using Serilog;
    using ServiceStack.ServiceInterface;

    public class SendToCustomService : Service
    {
        private readonly IDeclarationBll DeclarationBll;
        public SendToCustomService(IDeclarationBll declarationBll)
        {
            DeclarationBll = declarationBll;
        }
        public OperationResponse<bool> POST(SendToCustom res)
        {
           OperationResponse<bool> response = new OperationResponse<bool>();
            try
            {
                DeclarationDto declaration = res.Declaration;
                var data = DeclarationBll.SendToCustom(declaration);
                response.OnSuccess(data, "Success");
                return response;

            }
            catch(Exception e)
            {
                Log.Error(e.Message + e.StackTrace);
                response.OnException("Failed at server side");
                return response;
            }
        }


    }
}
