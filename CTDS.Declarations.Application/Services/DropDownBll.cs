namespace CTDS.Declarations.Application.Services
{
    using System;
    using System.Collections.Generic;

    using CTDS.Declarations.Application.Repository;
    using CTDS.Declarations.Contracts.DeclarationDTO;
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
                throw e;
            }
        }

        public IEnumerable<DropDownDto> GetDropDownItems(String listType)
        {
            try
            {
                return dropDownDal.GetAllDropDownItems(listType);
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}
