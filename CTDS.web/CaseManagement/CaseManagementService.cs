namespace CTDS.web.CaseManagement
{
    using System;
    using System.Collections.Generic;

    using CTDS.CaseManagement.Contracts.Dto;
    using CTDS.CaseManagement.Contracts.EndPoints;
    using CTDS.CaseManagement.Contracts.Interfaces;
    using CTDS.CaseManagement.Contracts.Validators;
    using CTDS.web.CommonResponse;     
    using CTDS.web.Authentication.Filters;

    using FluentValidation.Results;
    using ServiceStack.ServiceInterface;
    using Serilog;

    [AuthFilter(RoleName = "User")]
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
                foreach (var error in validationResult.Errors)
                {
                    errors.Add(error.ErrorMessage);
                }
                operationResponse.OnError("Invalid client data", errors);
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
                CaseDto caseDto = this.CaseBusinessLogic.AddNewCase(client, caseInformation, notes, caseStatus, references);
                operationResponse.OnSuccess(caseDto, "Added successfully");
                return operationResponse;
            }
            catch (Exception e)
            {
                Log.Error(e.Message);
                operationResponse.OnException(e.Message);
                return operationResponse;
            }
        }

        public OperationResponse<CaseDto> Get(GetCaseById request)
        {
            OperationResponse<CaseDto> operationResponse = new OperationResponse<CaseDto>();
            try
            {
                CaseDto caseDto = this.CaseBusinessLogic.GetCaseById(request.caseId);
                if (caseDto != null)
                {
                    operationResponse.OnSuccess(caseDto, "Fetched successfully");
                    return operationResponse;
                }
                else
                {
                    operationResponse.OnError("No case found!!!", null);
                    return operationResponse;
                }

            }
            catch (Exception e)
            {
                Log.Error(e.Message);
                operationResponse.OnException(e.Message);
                return operationResponse;
            }
        }

        public OperationResponse<CaseDto> Delete(DeleteCaseById request)
        {
            OperationResponse<CaseDto> operationResponse = new OperationResponse<CaseDto>();
            try
            {
                this.CaseBusinessLogic.DeleteCaseById(request.caseId);
                operationResponse.OnSuccess(null, "Deleted successfully");
                return operationResponse;
            }
            catch (Exception e)
            {
                Log.Error(e.Message);
                operationResponse.OnException(e.Message);
                return operationResponse;
            }
        }

        public OperationResponse<List<CaseDto>> Get(GetAllCases request)
        {
            OperationResponse<List<CaseDto>> operationResponse = new OperationResponse<List<CaseDto>>();
            try
            {
                List<CaseDto> caseDtos=this.CaseBusinessLogic.GetAllCases();
                if(caseDtos==null)
                {
                    operationResponse.OnError("No Case found", null);
                    return operationResponse;
                }
                operationResponse.OnSuccess(caseDtos, "Fetched successfully");
                return operationResponse;
            }
            catch (Exception e)
            {
                Log.Error(e.Message+" "+e.StackTrace);
                operationResponse.OnException(e.Message);
                return operationResponse;
            }
        }
        public OperationResponse<CaseDto> Put(EditCase request)
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
                foreach (var error in validationResult.Errors)
                {
                    errors.Add(error.ErrorMessage);
                }
                operationResponse.OnError("Invalid client data", errors);
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
                CaseDto caseDto = this.CaseBusinessLogic.EditCase(client.CaseId,client, caseInformation, notes, caseStatus, references);
                operationResponse.OnSuccess(caseDto, "Added successfully");
                return operationResponse;
            }
            catch (Exception e)
            {
                Log.Error(e.Message+" "+e.StackTrace);
                operationResponse.OnException(e.Message);
                return operationResponse;
            }
        }

    }
}