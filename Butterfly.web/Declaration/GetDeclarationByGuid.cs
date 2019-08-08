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
    using Butterfly.Declarations.Contracts.EndPoints;
    public class GetDeclarationByGuid : Service
    {
        private readonly DeclarationBll declarationBll;
        public GetDeclarationByGuid()
        {
            declarationBll = new DeclarationBll();
        }

        public OperationResponse<DeclarationData> GET(Butterfly.Declarations.Contracts.EndPoints.GetDeclarationByGuid guid)
        {
            OperationResponse<DeclarationData> response = new OperationResponse<DeclarationData>();
            try
            {
                var id = guid.guid;
                var declarationData = declarationBll.GetDeclarationById(id);
                var referenceData = declarationBll.GetReferenceData(id);
                DeclarationData data = new DeclarationData();
                data.Declaration = declarationData;
                data.ReferenceData = referenceData;
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