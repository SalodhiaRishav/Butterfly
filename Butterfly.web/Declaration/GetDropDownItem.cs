using ServiceStack.ServiceInterface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Butterfly.web.Declaration
{
    using Butterfly.Declarations.Application.Services;
    using Butterfly.web.CommonResponse;
    using Butterfly.Declarations.Contracts.DeclarationDTO;
    using Butterfly.Declarations.Contracts.EndPoints;
    public class GetDropDownItem : Service
    {
        private readonly DropDownBll dropDownBll;
        public GetDropDownItem()
        {
            dropDownBll = new DropDownBll();
        }
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
                response.OnException("Drop down items failed to fetched due internal server error");
                return response;
            }
        }
    }
}