namespace Butterfly.CaseManagement.Application.Mapper
{
    using System.Collections.Generic;
    using AutoMapper;

    public class BaseMapper<Entity,EntityDto>
    {
        IMapper Mapper;

        public BaseMapper()
        {
            MapperConfiguration config = new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<Entity, EntityDto>().ReverseMap();
            });
            Mapper = config.CreateMapper();
        }

        public EntityDto ModelToDto(Entity entity)
        {
            return Mapper.Map<EntityDto>(entity);
        }

        public Entity DtoToModel(EntityDto entityDto)
        {
            return Mapper.Map<Entity>(entityDto);
        }

        public List<EntityDto> ModelListToDtoList(List<Entity> entities)
        {
            return Mapper.Map<List<EntityDto>>(entities);
        }

        public List<Entity> DtoListToModelList(List<EntityDto> entityDtos)
        {
            return Mapper.Map<List<Entity>>(entityDtos);
        }
    }
}
