namespace Butterfly.web.CaseManagement
{
    using Butterfly.CaseManagement.Contracts.Dto;
    using Butterfly.CaseManagement.Contracts.EndPoints;
    using Butterfly.CaseManagement.Contracts.Utils;
    using ServiceStack.ServiceInterface;

    public class CaseManagementService : Service
    {
        public OperationResult<CaseDto> Post(CreateCase request)
        {
            OperationResult<CaseDto> result = new OperationResult<CaseDto>();
            
            return result;
        }

        //public OperationResult<CaseDto> Get(GetCaseById request)
        //{
        //    OperationResult<CaseDto> result = new OperationResult<CaseDto>();
           
        //    result.Data = request;
        //    result.Success = true;
        //    result.Message = "retrieved successfully";
        //    return result;
        //}
    }
}