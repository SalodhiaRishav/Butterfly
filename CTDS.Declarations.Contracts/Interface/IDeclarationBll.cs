namespace CTDS.Declarations.Contracts.Interface
{
    using System;
    using System.Collections.Generic;

    using CTDS.Declarations.Contracts.DeclarationDTO;

    public interface IDeclarationBll
    {
        Guid AddDeclaration(DeclarationDto declarationDto);
        DeclarationDto GetDeclarationById(Guid id);
        IEnumerable<DeclarationDto> GetAllDeclaration();
        bool EditDeclaration(DeclarationDto declarationDto);
        void AddReference(ReferenceDto reference);
        IEnumerable<ReferenceDto> GetReferenceData(Guid id);
        int GetCount();
        int GetCountForLastSevenDays();
        bool SendToCustom(DeclarationDto declarationDTO);
        StatusDto GetStatusCount();
    }
}