﻿namespace Butterfly.web.Declaration
{
   
    using System;

    using Butterfly.Declarations.Application.Services;
    using Butterfly.Declarations.Contracts.DeclarationDTO;
    using Butterfly.web.CommonResponse;

    using Serilog;
    using ServiceStack.ServiceInterface;

    using Butterfly.web.Authentication.Filters;

    public class GetDeclarationByGuid : Service
    {
        private readonly DeclarationBll declarationBll;
        public GetDeclarationByGuid()
        {
            declarationBll = new DeclarationBll();
        }

        [AuthFilter(RoleName = "User")]
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
                Log.Error(e.Message+" "+e.StackTrace);
                response.OnException("Failed to Fetch declaration");
                return response;
            }
        }

    }
}