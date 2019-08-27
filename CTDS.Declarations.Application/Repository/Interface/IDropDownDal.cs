namespace CTDS.Declarations.Application.Repository.Interface
{
    using System;
    using System.Collections.Generic;

    using CTDS.Declarations.Contracts.DeclarationDTO;

    public interface IDropDownDal
    {
        bool AddNewItem (DropDownDto newItem);
        IEnumerable<DropDownDto> GetAllDropDownItems(String listType);
    }
}