namespace Butterfly.web.CaseManagement
{
    using Butterfly.CaseManagement.Contracts.Dto;
    using Butterfly.CaseManagement.Contracts.EndPoints;
    using Butterfly.CaseManagement.Contracts.Interfaces;
    using Butterfly.CaseManagement.Contracts.Validators;
    using Butterfly.web.CommonResponse;
    using FluentValidation.Results;
    using ServiceStack.ServiceInterface;
    using System;
    using System.Collections.Generic;

    public class CaseManagementService : Service
    {
        private readonly ICaseBusinessLogic CaseBusinessLogic;
        public CaseManagementService(ICaseBusinessLogic caseBusinessLogic)
        {
            CaseBusinessLogic = caseBusinessLogic;
        }
        public OperationResponse<CaseDto> Post(CreateCase request)
        {
            OperationResponse<CaseDto> operationResponse = new OperationResponse<CaseDto>();

            ClientValidator clientValidator = new ClientValidator();
            CaseInformationValidator caseInformationValidator = new CaseInformationValidator();
            NotesValidator notesValidator = new NotesValidator();

            CaseInformationDto caseInformation = request.CaseDto.CaseInformation;
            ClientDto client = request.CaseDto.Client;
            NotesDto notes = request.CaseDto.Notes;
            CaseStatusDto caseStatus = request.CaseDto.CaseStatus;
            List<CaseReferenceDto> references = request.CaseDto.References;

            ValidationResult validationResult = clientValidator.Validate(client);
            if (!validationResult.IsValid)
            {
                List<string> errors = new List<string>();
                foreach(var error in validationResult.Errors)
                {
                    errors.Add(error.ErrorMessage);
                }
                operationResponse.OnError("Invalid client data",errors);
                return operationResponse;
            }

            validationResult = caseInformationValidator.Validate(caseInformation);
            if (!validationResult.IsValid)
            {
                List<string> errors = new List<string>();
                foreach (var error in validationResult.Errors)
                {
                    errors.Add(error.ErrorMessage);
                }
                operationResponse.OnError("Invalid case-information data", errors);
                return operationResponse;
            }

            validationResult = notesValidator.Validate(notes);
            if (!validationResult.IsValid)
            {
                List<string> errors = new List<string>();
                foreach (var error in validationResult.Errors)
                {
                    errors.Add(error.ErrorMessage);
                }
                operationResponse.OnError("Invalid case-information data", errors);
                return operationResponse;
            }

            try
            {
                CaseDto caseDto=this.CaseBusinessLogic.AddNewCase(client, caseInformation, notes, caseStatus, references);
                operationResponse.OnSuccess(caseDto, "Added successfully");
                return operationResponse;
            }
            catch(Exception e)
            {
                operationResponse.OnException(e.Message);
                return operationResponse;
            }
        }

    }
}