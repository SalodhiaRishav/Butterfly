namespace CTDS.web.Declaration
{
    using System;

    using CTDS.Declarations.Application.Services;
    using CTDS.Declarations.Contracts.EndPoints;
    using CTDS.web.CommonResponse;

    using ServiceStack.ServiceInterface;
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
                response.OnSuccess(data,"New drop down list item successfully added");
                return response;
            }
            catch(Exception e)
            {
                response.OnException("Request to add new Drop down item failed at server side");
                return response;
            }
        }
    }
}