namespace CTDS.Common.Repository
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    using CTDS.Common.Dto;
    using CTDS.Common.Interface;
    using CTDS.Database.Context;

    public class MasterDataRepository : IMasterDataRepository
    {
        private readonly IMasterDataMapper Mapper;
        public MasterDataRepository(IMasterDataMapper mapper)
        {
            Mapper = mapper;
        }

        public IEnumerable<MasterDataDto> GetMasterData(String listType)
        {
            IEnumerable<MasterDataDto> masterDataList;
            try
            {
                using (var context = new CTDSContext())
                {
                    var items = context.MasterData.Where(d => d.Type.Equals(listType)).ToList();
                    masterDataList = Mapper.ModelListToDtoList(items);
                }
                return masterDataList;
            }
            catch(Exception)
            {
                throw;
            }
            
        }
    }
}
