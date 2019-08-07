using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Butterfly.Declarations.Application.Repository
{
    using Butterfly.Declarations.Contracts.DeclarationDTO;
    using Butterfly.Database.Context;
    using Butterfly.Database.Models.Declarations;
    using Butterfly.Declarations.Application.Mapper;
    public class DropDownDal
    {
        private readonly DatabaseMapper mapper;
        public DropDownDal()
        {

            mapper = new DatabaseMapper();
        }

        public bool AddNewItem (DropDownDto newItem)
        {
            try
            {
                using (var context = new ButterflyContext())
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
                using (var context = new ButterflyContext())
                {
                    var items = context.DropDown.Where(d => d.Type.Equals(listType)).ToList();
                    dropDownList = mapper.DropDownListToDtoList(items);
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
