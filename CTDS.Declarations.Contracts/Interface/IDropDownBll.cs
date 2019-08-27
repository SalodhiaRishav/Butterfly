namespace CTDS.Declarations.Contracts.Interface
{
    using System;
    using System.Collections.Generic;

    using CTDS.Declarations.Contracts.DeclarationDTO;

    public interface IDropDownBll
    {
        IEnumerable<DropDownDto> GetDropDownItems(String listType);
    }
}