namespace Butterfly.web.CaseManagement
{
    using Butterfly.CaseManagement.Contracts.EndPoints;
    using Butterfly.CaseManagement.Contracts.Enums;
    using Butterfly.web.CommonResponse;
    using ServiceStack.ServiceInterface;
    using System;

    public class DropDownService : Service
    {
        public OperationResponse<Array> Get(GetPriorityTypes request)
        {
            OperationResponse<Array> operationResponse = new OperationResponse<Array>();
            Array names = Enum.GetNames(typeof(PriorityType));
            operationResponse.OnSuccess(names, "fetched successfully");
            return operationResponse;
        }
        public OperationResponse<Array> Get(GetStatusTypes request)
        {
            OperationResponse<Array> operationResponse = new OperationResponse<Array>();
            Array names = Enum.GetNames(typeof(CaseStatusType));
            operationResponse.OnSuccess(names, "fetched successfully");
            return operationResponse;
        }
        public OperationResponse<Array> Get(GetCaseReferenceTypes request)
        {
            OperationResponse<Array> operationResponse = new OperationResponse<Array>();
            Array names = Enum.GetNames(typeof(CaseReferenceType));
            operationResponse.OnSuccess(names, "fetched successfully");
            return operationResponse;
        }
        public OperationResponse<Array> Get(GetIdentifierTypes request)
        {
            OperationResponse<Array> operationResponse = new OperationResponse<Array>();
            Array names = Enum.GetNames(typeof(IdentifierType));
            operationResponse.OnSuccess(names, "fetched successfully");
            return operationResponse;
        }
    }
}