namespace CTDS.Declarations.Application.Mapper.Interface
{
    using System.Collections.Generic;

    using CTDS.Database.Models.Declarations;
    using CTDS.Declarations.Contracts.DeclarationDTO;
    public interface IDatabaseMapper
    {
        DeclarationDto DeclarationToDto(Declaration declaration);
        Declaration DtoToDeclaration(DeclarationDto declarationDto);
        IEnumerable<DeclarationDto> DeclarationListToDtoList(IEnumerable<Declaration> declaration);
        IEnumerable<ReferenceDto> ReferenceListToDtoList(IEnumerable<ReferenceTable> reference);
        ReferenceTable DtoToReferenceModel(ReferenceDto reference);
    }
}