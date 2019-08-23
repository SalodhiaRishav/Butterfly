namespace CTDS.CaseManagement.Application.Mapper
{
    using CTDS.CaseManagement.Contracts.Dto;
    using CTDS.Database.Models.CaseManagement;
    using CTDS.CaseManagement.Application.Mapper.MapperInterface;

    public class CaseStatusMapper : BaseMapper<CaseStatus,CaseStatusDto>,ICaseStatusMapper
    {
    }
}
