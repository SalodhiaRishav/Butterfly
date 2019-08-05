using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Butterfly.web.Declaration
{
    using Butterfly.Declarations.Contracts.EndPoints;
    using ServiceStack.ServiceInterface;
    using Butterfly.Declarations.Contracts.DeclarationDTO;
    using Butterfly.Declarations.Application.Services;
    using Butterfly.web.CommonResponse;
    public class AddDropDownItemService : Service
    {
    
        public OperationResponse<bool> POST(AddDropDownItem NewItem)
        {
            OperationResponse<bool> response = new OperationResponse<bool>();
            DropDownBll dropDownBll = new DropDownBll();
            var newitem = NewItem.AddItem;
            try
            {
                bool data = dropDownBll.AddNewItem(newitem);
                response.OnSuccess(data,"New DropDown List Item successfully added");
                return response;
            }
            catch(Exception e)
            {
                response.OnException(false, "Request to add new Drop down item failed at server side");
                return response;
            }
        }
    }
}