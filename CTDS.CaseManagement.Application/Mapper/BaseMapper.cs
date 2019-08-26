namespace CTDS.CaseManagement.Application.Mapper
{
    using System.Collections.Generic;
    using AutoMapper;
    using CTDS.CaseManagement.Application.Mapper.MapperInterface;

    public class BaseMapper<TEntity,TEntityDto>:IBaseMapper<TEntity,TEntityDto>
    {
        private readonly IMapper Mapper;

        public BaseMapper()
        {
            MapperConfiguration config = new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<TEntity, TEntityDto>().ReverseMap();
            });
            Mapper = config.CreateMapper();
        }

        public TEntityDto ModelToDto(TEntity entity)
        {
            return Mapper.Map<TEntityDto>(entity);
        }

        public TEntity DtoToModel(TEntityDto entityDto)
        {
            return Mapper.Map<TEntity>(entityDto);
        }

        public List<TEntityDto> ModelListToDtoList(List<TEntity> entities)
        {
            return Mapper.Map<List<TEntityDto>>(entities);
        }

        public List<TEntity> DtoListToModelList(List<TEntityDto> entityDtos)
        {
            return Mapper.Map<List<TEntity>>(entityDtos);
        }
    }
}
