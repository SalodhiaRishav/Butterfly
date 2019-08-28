namespace CTDS.Declarations.Application.Services
{
    using System;
    using System.Collections.Generic;

    using CTDS.Common.Interface;
    using CTDS.Common.Dto;



    public class MasterDataBll : IMasterDataBll
    {
        private readonly IMasterDataRepository MasterDataRepository;
        public MasterDataBll(IMasterDataRepository masterDataRepository)
        {
            MasterDataRepository = masterDataRepository;
        }

        

        public IEnumerable<MasterDataDto> GetMasterData(String listType)
        {
            try
            {
                return MasterDataRepository.GetMasterData(listType);
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}
