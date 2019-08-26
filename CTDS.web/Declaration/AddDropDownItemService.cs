namespace CTDS.web.Declaration
{
    using System;

    using CTDS.Declarations.Application.Services;
    using CTDS.Declarations.Contracts.EndPoints;
    using CTDS.web.CommonResponse;
    using CTDS.Declarations.Contracts.Interface;

    using ServiceStack.ServiceInterface;
    public class AddDropDownItemService : Service
    {
        private readonly IDropDownBll DropDownBll;
        public AddDropDownItemService(IDropDownBll dropDownBll)
        {
            DropDownBll = dropDownBll;
        }
        public OperationResponse<bool> Post(AddDropDownItem newItem)
        {
            OperationResponse<bool> response = new OperationResponse<bool>();
            var newitem = newItem.AddItem;
            try
            {
                bool data = DropDownBll.AddNewItem(newitem);
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