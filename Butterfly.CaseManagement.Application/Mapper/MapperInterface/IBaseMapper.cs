namespace Butterfly.CaseManagement.Application.Mapper.MapperInterface
{
    using System.Collections.Generic;

    public interface IBaseMapper<Entity, EntityDto>
    {
        EntityDto ModelToDto(Entity entity);
        Entity DtoToModel(EntityDto entityDto);
        List<EntityDto> ModelListToDtoList(List<Entity> entities);
        List<Entity> DtoListToModelList(List<EntityDto> entityDtos);
    }
}
