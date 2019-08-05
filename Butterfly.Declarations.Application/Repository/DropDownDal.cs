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
    public class DropDownDal
    {
        public DropDownDal()
        {

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
            catch(Exception e)
            {
                throw;
            }

           
        }

        public bool GetAllDropDownItems()
        {
            using(var context = new ButterflyContext())
            {
                var items = context.DropDown.ToList();

            }
            return true;
        }
    }
}
