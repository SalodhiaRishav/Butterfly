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
        DropDownDal dropDownDal;
        public DropDownBll()
        {
           dropDownDal= new DropDownDal();
        }

        public bool AddNewItem(DropDownDto newitem)
        {
            
            return dropDownDal.AddNewItem(newitem);
        }

        public bool GetDropDownItems()
        {
            return dropDownDal.GetAllDropDownItems();
        }
    }
}
