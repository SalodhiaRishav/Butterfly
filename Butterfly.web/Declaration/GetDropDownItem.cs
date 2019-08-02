using ServiceStack.ServiceInterface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Butterfly.web.Declaration
{
    using Butterfly.Declarations.Application.Services;
    public class GetDropDownItem : Service
    {
        private readonly DropDownBll dropDownBll;
        public GetDropDownItem()
        {
            dropDownBll = new DropDownBll();
        }
        public void GET()
        {
            dropDownBll.GetDropDownItems();
        }
    }
}