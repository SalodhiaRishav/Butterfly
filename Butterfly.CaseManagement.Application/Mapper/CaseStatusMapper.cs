namespace Butterfly.CaseManagement.Application.Mapper
{
    using Butterfly.CaseManagement.Contracts.Dto;
    using Butterfly.Database.Models.CaseManagement;
    using Butterfly.CaseManagement.Application.Mapper.MapperInterface;

    public class CaseStatusMapper : BaseMapper<CaseStatus,CaseStatusDto>,ICaseStatusMapper
    {
    }
}
