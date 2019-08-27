namespace CTDS.Declarations.Application.Mapper
{
    using System.Collections.Generic;
   
    using CTDS.Database.Models.Declarations;
    using CTDS.Declarations.Contracts.DeclarationDTO;
    using CTDS.Declarations.Application.Mapper.Interface;

    using AutoMapper;

    public class DatabaseMapper : IDatabaseMapper
    {
        readonly private IMapper Mapper;
        public DatabaseMapper()
        {
            MapperConfiguration config = new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<Declaration, DeclarationDto>().ReverseMap();

            });
            Mapper = config.CreateMapper();
        }

        public DeclarationDto DeclarationToDto(Declaration declaration)
        {
            return Mapper.Map<DeclarationDto>(declaration);
        }

        public Declaration DtoToDeclaration(DeclarationDto declarationDto)
        {
            return Mapper.Map<Declaration>(declarationDto);
        }

        public IEnumerable<DeclarationDto> DeclarationListToDtoList(IEnumerable<Declaration> declaration)
        {
            return Mapper.Map<IEnumerable<DeclarationDto>>(declaration);
        }

        public IEnumerable<ReferenceDto> ReferenceListToDtoList(IEnumerable<ReferenceTable> reference)
        {
            return Mapper.Map<IEnumerable<ReferenceDto>>(reference);
        }
        public ReferenceTable DtoToReferenceModel(ReferenceDto reference)
        {
            return Mapper.Map<ReferenceTable>(reference);
        }
    }
}
