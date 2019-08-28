namespace CTDS.Common.Interface
{
    using System;
    using System.Collections.Generic;

    using CTDS.Common.Dto;

    public interface IMasterDataBll
    {
        IEnumerable<MasterDataDto> GetMasterData(String listType);
    }
}