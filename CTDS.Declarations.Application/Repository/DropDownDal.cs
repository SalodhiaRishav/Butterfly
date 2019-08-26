namespace CTDS.Declarations.Application.Repository
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    using CTDS.Database.Context;
    using CTDS.Database.Models.Declarations;
    using CTDS.Declarations.Application.Mapper;
    using CTDS.Declarations.Application.Mapper.Interface;
    using CTDS.Declarations.Application.Repository.Interface;
    using CTDS.Declarations.Contracts.DeclarationDTO;
    public class DropDownDal : IDropDownDal
    {
        private readonly IDatabaseMapper Mapper;
        public DropDownDal(IDatabaseMapper mapper)
        {
            Mapper = mapper;
        }

        public bool AddNewItem (DropDownDto newItem)
        {
            try
            {
                using (var context = new CTDSContext())
                {
                    var item = new DropDown();
                    item.Id = newItem.Id;
                    item.Key = newItem.Key;
                    item.Type = newItem.Type;
                    item.Value = newItem.Value;
                    context.DropDown.Add(item);
                    context.SaveChanges();
                }
                return true;
            }
            catch(Exception)
            {
                throw;
            }

           
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
