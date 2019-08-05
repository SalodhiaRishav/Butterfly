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
            try
            {
                return dropDownDal.AddNewItem(newitem);
            }
            catch(Exception e)
            {
                throw;
            }
        }

        public bool GetDropDownItems()
        {
            return dropDownDal.GetAllDropDownItems();
        }
    }
}
