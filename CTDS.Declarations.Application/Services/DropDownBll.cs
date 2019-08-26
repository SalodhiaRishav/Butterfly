namespace CTDS.Declarations.Application.Services
{
    using System;
    using System.Collections.Generic;

    using CTDS.Declarations.Application.Repository;
    using CTDS.Declarations.Contracts.DeclarationDTO;
    using CTDS.Declarations.Contracts.Interface;
    using CTDS.Declarations.Application.Repository.Interface;

    public class DropDownBll : IDropDownBll
    {
        private readonly IDropDownDal DropDownDal;
        public DropDownBll(IDropDownDal dropDownDal)
        {
            DropDownDal = dropDownDal;
        }

        public bool AddNewItem(DropDownDto newitem)
        {
            try
            {
                return DropDownDal.AddNewItem(newitem);
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
                return DropDownDal.GetAllDropDownItems(listType);
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}
