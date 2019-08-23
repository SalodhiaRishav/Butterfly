namespace Butterfly.web.Declaration
{
    
    using System;
    

    using System.Collections.Generic;
    using Butterfly.Declarations.Application.Services;
    using Butterfly.Declarations.Contracts.DeclarationDTO;
    using Butterfly.Declarations.Contracts.EndPoints;
    using Butterfly.web.CommonResponse;

    using Serilog;
    using ServiceStack.ServiceInterface;


    using Butterfly.web.Authentication.Filters;

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