namespace CTDS.Declarations.Application.Services
{
    using System;
    using System.Collections.Generic;

    using CTDS.Declarations.Application.Repository;
    using CTDS.Declarations.Contracts.DeclarationDTO;
    public class DropDownBll
    {
        DropDownDal DropDownDal;
        public DropDownBll()
        {
           DropDownDal= new DropDownDal();
        }

        

        public IEnumerable<DropDownDto> GetDropDownItems(String listType)
        {
            try
            {
                return DropDownDal.GetAllDropDownItems(listType);
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}
