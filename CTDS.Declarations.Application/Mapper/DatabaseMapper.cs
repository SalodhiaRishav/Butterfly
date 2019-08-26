namespace CTDS.Declarations.Application.Mapper
{
    using System.Collections.Generic;
   
    using CTDS.Database.Models.Declarations;
    using CTDS.Declarations.Contracts.DeclarationDTO;

    using AutoMapper;
    public class DatabaseMapper
    {
        readonly private IMapper mapper;
        public DatabaseMapper()
        {
            MapperConfiguration config = new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<DropDown, DropDownDto>().ReverseMap();
                cfg.CreateMap<Declaration, DeclarationDto>().ReverseMap();

            });
            mapper = config.CreateMapper();
        }

        public DeclarationDto DeclarationToDto(Declaration declaration)
        {
            return mapper.Map<DeclarationDto>(declaration);
        }

        public Declaration DtoToDeclaration(DeclarationDto declarationDto)
        {
            return mapper.Map<Declaration>(declarationDto);
        }

        public DropDownDto DropDownToDto(DropDown dropDown)
        {
            return mapper.Map<DropDownDto>(dropDown);
        }

        public IEnumerable<DropDownDto> DropDownListToDtoList(IEnumerable<DropDown> dropDown)
        {
            return mapper.Map<IEnumerable<DropDownDto>>(dropDown);
        }

        public IEnumerable<DropDown> DtoListToDropDownList(IEnumerable<DropDown> dropDownDto)
        {
            return mapper.Map<IEnumerable<DropDown>>(dropDownDto);
        }
        public IEnumerable<DeclarationDto> DeclarationListToDtoList(IEnumerable<Declaration> declaration)
        {
            return mapper.Map<IEnumerable<DeclarationDto>>(declaration);
        }

        public IEnumerable<ReferenceDto> ReferenceListToDtoList(IEnumerable<ReferenceTable> reference)
        {
            return mapper.Map<IEnumerable<ReferenceDto>>(reference);
        }
        public ReferenceTable DtoToReferenceModel(ReferenceDto reference)
        {
            return mapper.Map<ReferenceTable>(reference);
        }
    }
}
