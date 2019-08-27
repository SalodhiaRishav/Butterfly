namespace CTDS.Web.CaseManagement
{
    using System;

    using CTDS.CaseManagement.Contracts.EndPoints;
    using CTDS.CaseManagement.Contracts.Enums;
    using CTDS.Web.CommonResponse;

    using ServiceStack.ServiceInterface;
    

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