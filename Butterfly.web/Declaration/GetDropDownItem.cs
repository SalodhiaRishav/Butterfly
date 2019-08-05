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
    public class GetDropDownItem : Service
    {
        private readonly DropDownBll dropDownBll;
        public GetDropDownItem()
        {
            dropDownBll = new DropDownBll();
        }
        public void GET()
        {
            OperationResponse<IEnumerable<DropDownDto>> response = new OperationResponse<IEnumerable<DropDownDto>>();
            try
            {               
                var data = dropDownBll.GetDropDownItems();
                response.OnSuccess(data, "Drop Items Fetched Successfully");
            }
            catch(Exception e)
            {
                response.OnException("Drop down items failed to fetched due internal server error");
            }
        }
    }
}