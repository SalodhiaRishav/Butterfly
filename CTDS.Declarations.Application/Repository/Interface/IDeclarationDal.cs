namespace CTDS.Declarations.Application.Repository.Interface
{
    using System;
    using System.Collections.Generic;

    using CTDS.Declarations.Contracts.DeclarationDTO;

    public interface IDeclarationDal
    {
        Guid AddDeclaration(DeclarationDto declarationDto);
        DeclarationDto GetDeclarationById(Guid id);
        IEnumerable<DeclarationDto> GetAllDeclarations(int index, string sort);
        IEnumerable<DeclarationDto> GetAllDeclarations();
        bool EditDeclaration(DeclarationDto declarationDto);
        void AddReference(ReferenceDto reference);
        IEnumerable<ReferenceDto> GetReferenceData(Guid id);
        int GetCount();
        int GetCountForLastSevenDays();
        bool SendToCustom(DeclarationDto declaration);
    }
}