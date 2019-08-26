namespace CTDS.web.Declaration
{    
    using System;
    
    using System.Collections.Generic;
    using CTDS.Declarations.Application.Services;
    using CTDS.Declarations.Contracts.DeclarationDTO;
    using CTDS.Declarations.Contracts.EndPoints;
    using CTDS.web.CommonResponse;
    using CTDS.web.Authentication.Filters;

    using Serilog;
    using ServiceStack.ServiceInterface;

    public class GetDropDownItem : Service
    {
        private readonly DropDownBll dropDownBll;
        public GetDropDownItem()
        {
            dropDownBll = new DropDownBll();
        }

        [AuthFilter(RoleName = "User")]
        public OperationResponse<IEnumerable<DropDownDto>> GET(GetDropDownItems ListType )
        {
            OperationResponse<IEnumerable<DropDownDto>> response = new OperationResponse<IEnumerable<DropDownDto>>();
            try
            {
                var listType = ListType.ListType;           
                var data = dropDownBll.GetDropDownItems(listType);
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