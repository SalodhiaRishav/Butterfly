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
    public class AddDropDownItemService : Service
    {
    
        public bool POST(AddDropDownItem NewItem)
        {
            DropDownBll dropDownBll = new DropDownBll(); 
            var newitem = NewItem.AddItem;
            return dropDownBll.AddNewItem(newitem);


        }
    }
}