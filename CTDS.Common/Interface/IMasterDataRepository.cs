namespace CTDS.Common.Interface
{
    using System;
    using System.Collections.Generic;

    using CTDS.Common.Dto;

    public interface IMasterDataRepository
    {
        IEnumerable<MasterDataDto> GetMasterData(String listType);
    }
}