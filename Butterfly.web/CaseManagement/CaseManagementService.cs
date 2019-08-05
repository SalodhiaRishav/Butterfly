namespace Butterfly.web.CaseManagement
{
    using Butterfly.CaseManagement.Contracts.Dto;
    using Butterfly.CaseManagement.Contracts.EndPoints;
    using Butterfly.CaseManagement.Contracts.Utils;
    using ServiceStack.ServiceInterface;
    using Butterfly.CaseManagement.Contracts.Validators;
    using FluentValidation.Results;
    using System.Collections.Generic;

    public class CaseManagementService : Service
    {
        public OperationResult<CaseDto> Post(CreateCase request)
        {
            ClientValidator clientValidator = new ClientValidator();
            CaseInformationValidator caseInformationValidator = new CaseInformationValidator();
            NotesValidator notesValidator = new NotesValidator();

            CaseInformationDto caseInformation = request.CaseDto.CaseInformation;
            ClientDto client = request.CaseDto.Client;
            NotesDto notes = request.CaseDto.Notes;
            CaseStatusDto caseStatus = request.CaseDto.CaseStatus;
            List<CaseReferenceDto> references = new List<CaseReferenceDto>(); 

            ValidationResult validationResult = clientValidator.Validate(client);
            if (!validationResult.IsValid)
            {

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