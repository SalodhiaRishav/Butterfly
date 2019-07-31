using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Butterfly.Declarations.Application.Services
{
    using Butterfly.Declarations.Contracts.DeclarationDTO;
    using Butterfly.Declarations.Application.Repository;
    public class DropDownBll
    {
        public DropDownBll()
        {

        }

        public bool AddNewItem(DropDownDto newitem)
        {
            DropDownDal dropDownDal = new DropDownDal();
            return dropDownDal.AddNewItem(newitem);
        }
    }
}
