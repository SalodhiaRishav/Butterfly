namespace CTDS.Declarations.Application.Repository
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    using CTDS.Database.Context;
    using CTDS.Database.Models.Declarations;
    using CTDS.Declarations.Application.Mapper;
    using CTDS.Declarations.Contracts.DeclarationDTO;
    public class DropDownDal
    {
        private readonly DatabaseMapper Mapper;
        public DropDownDal()
        {

            Mapper = new DatabaseMapper();
        }        

        public IEnumerable<DropDownDto> GetAllDropDownItems(String listType)
        {
            IEnumerable<DropDownDto> dropDownList;
            try
            {
                using (var context = new CTDSContext())
                {
                    var items = context.DropDown.Where(d => d.Type.Equals(listType)).ToList();
                    dropDownList = Mapper.DropDownListToDtoList(items);
                }
                return dropDownList;
            }
            catch(Exception)
            {
                throw;
            }
            
        }
    }
}
