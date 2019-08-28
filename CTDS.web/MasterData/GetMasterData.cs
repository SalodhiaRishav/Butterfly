using CTDS.Common.Dto;
using CTDS.Common.Interface;

namespace CTDS.Web.MasterData
{    
    using System;
    using System.Collections.Generic;

    using CTDS.Declarations.Application.Services;
    using CTDS.Declarations.Contracts.DeclarationDTO;
    using CTDS.Declarations.Contracts.EndPoints;
    using CTDS.Web.CommonResponse;
    using CTDS.Web.Authentication.Filters;
    using CTDS.Declarations.Contracts.Interface;

    using Serilog;
    using ServiceStack.ServiceInterface;

    public class GetMasterData : Service
    {
        private readonly IMasterDataBll MasterDataBll;
        public GetMasterData(IMasterDataBll masterDataBll)
        {
            MasterDataBll = masterDataBll;
        }

     
        public OperationResponse<IEnumerable<MasterDataDto>> Get(Common.EndPoints.GetMasterData request )
        {
            OperationResponse<IEnumerable<MasterDataDto>> response = new OperationResponse<IEnumerable<MasterDataDto>>();
            try
            {
                var listType = request.ListType;           
                var data = MasterDataBll.GetMasterData(listType);
                response.OnSuccess(data, "Drop Items Fetched Successfully");
                return response;
            }
            catch(Exception e)
            {
                Log.Error(e.Message +" "+e.StackTrace);
                response.OnException("Drop down items failed to fetched due internal server error");
                return response;
            }
        }
    }
}