namespace CTDS.CaseManagement.Application.Mapper.MapperInterface
{
    using System.Collections.Generic;

    public interface IBaseMapper<TEntity, TEntityDto>
    {
        TEntityDto ModelToDto(TEntity entity);
        TEntity DtoToModel(TEntityDto entityDto);
        List<TEntityDto> ModelListToDtoList(List<TEntity> entities);
        List<TEntity> DtoListToModelList(List<TEntityDto> entityDtos);
    }
}
