namespace CTDS.Declarations.Application.Repository.Interface
{
    using System;
    using System.Collections.Generic;

    using CTDS.Declarations.Contracts.DeclarationDTO;

    public interface IDropDownDal
    {
        IEnumerable<DropDownDto> GetAllDropDownItems(String listType);
    }
}