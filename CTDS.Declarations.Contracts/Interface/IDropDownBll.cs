namespace CTDS.Declarations.Contracts.Interface
{
    using System;
    using System.Collections.Generic;

    using CTDS.Declarations.Contracts.DeclarationDTO;

    public interface IDropDownBll
    {
        bool AddNewItem(DropDownDto newitem);
        IEnumerable<DropDownDto> GetDropDownItems(String listType);
    }
}