﻿namespace Butterfly.CaseManagement.Application.Mapper
{
    using Butterfly.CaseManagement.Contracts.Dto;
    using Butterfly.Database.Models.CaseManagement;
    using Butterfly.CaseManagement.Application.Mapper.MapperInterface;

    public class CaseReferenceMapper : BaseMapper<CaseReference,CaseReferenceDto>,ICaseReferenceMapper
    {
    }
}