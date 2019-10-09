namespace CTDS.Web.CaseManagement
{
    using System;
    using System.Collections.Generic;

    using CTDS.CaseManagement.Contracts.Dto;
    using CTDS.CaseManagement.Contracts.EndPoints;
    using CTDS.CaseManagement.Contracts.Interfaces;
    using CTDS.CaseManagement.Contracts.Validators;
    using CTDS.Web.CommonResponse;     
    using CTDS.Web.Authentication.Filters;

    using FluentValidation.Results;
    using ServiceStack.ServiceInterface;
    using Serilog;

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
            List<string> errors = new List<string>();

            ValidationResult validationResult = clientValidator.Validate(client);
            if (!validationResult.IsValid)
            {
               ;
                foreach (var error in validationResult.Errors)
                {
                    errors.Add(error.ErrorMessage);
                }
               
            }

            validationResult = caseInformationValidator.Validate(caseInformation);
            if (!validationResult.IsValid)
            {
              
                foreach (var error in validationResult.Errors)
                {
                    errors.Add(error.ErrorMessage);
                }
            }

            validationResult = notesValidator.Validate(notes);
            if (!validationResult.IsValid)
            {
               
                foreach (var error in validationResult.Errors)
                {
                    errors.Add(error.ErrorMessage);
                }
            }

            if (errors.Count != 0)
            {
                operationResponse.OnError("Invalid input data", errors);
                return operationResponse;
            }
           
            try
            {
                CaseDto caseDto = CaseBusinessLogic.AddNewCase(client, caseInformation, notes, caseStatus, references);
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
                CaseDto caseDto = CaseBusinessLogic.GetCaseById(request.CaseId);
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
                CaseBusinessLogic.DeleteCaseById(request.CaseId);
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

        public OperationResponse<int> Get(GetCaseCount request)
        {
            OperationResponse<int> response = new OperationResponse<int>();
            try
            {
                int data = CaseBusinessLogic.GetCaseCount();
                if(data == 0)
                {
                    response.OnSuccess(data, " No Cases ");
                }
                else
                {
                    response.OnSuccess(data, "Fetched successfully");
                }
                return response;
            }
            catch(Exception e)
            {
                Log.Error(e.Message + " " + e.StackTrace);
                response.OnException("Server side failed");
                return response;
            }
        }

        public OperationResponse<GroupByCaseDTO> Get(GetFilteredCaseCount request)
        {
            OperationResponse<GroupByCaseDTO> response = new OperationResponse<GroupByCaseDTO>();
            try
            {
                var data = CaseBusinessLogic.GetFilteredCaseCount();
                if(data == null)
                {
                    response.OnSuccess(data, " No cases ");
                }
                else
                {
                    response.OnSuccess(data, "Fetched successfully");
                }

                return response;
            }
            catch(Exception e)
            {
                Log.Error(e.Message + " " + e.StackTrace);
                response.OnException("Server side failed");
                return response;
            }
           
        }

        public OperationResponse<List<CaseDto>> Get(GetAllCases request)
        {
            OperationResponse<List<CaseDto>> operationResponse = new OperationResponse<List<CaseDto>>();
            try
            {

                List<CaseDto> caseDtos = CaseBusinessLogic.GetAllCases(request.index, request.orderBy);
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
                operationResponse.OnSuccess(caseDto, "Saved successfully");
                return operationResponse;
            }
            catch (Exception e)
            {
                Log.Error(e.Message+" "+e.StackTrace);
                operationResponse.OnException(e.Message);
                return operationResponse;
            }
        }
        public OperationResponse<int> GET(GetCaseCountInLastSevenDays req)
        {
            OperationResponse<int> response = new OperationResponse<int>();
            try
            {
                var data = CaseBusinessLogic.GetCountOfSevenDays();
                response.OnSuccess(data, "Success");
                return response;
            }
            catch(Exception e)
            {
                Log.Error(e.Message + " " + e.StackTrace);
                response.OnException("Req Failed at server side");
                return response;
            }
        }

        public OperationResponse<List<int>> GET(GetLastWeekPerDayCaseCount req)
        {
            OperationResponse<List<int>> response = new OperationResponse<List<int>>();
            try
            {
                var data = CaseBusinessLogic.GetCasesPerDayLastWeek();
                response.OnSuccess(data, "Success");
                return response;
            }
            catch(Exception e)
            {
                Log.Error(e.Message + " " + e.StackTrace);
                response.OnException("Req failed at server side");
                return response;
            }
        }
        public OperationResponse<OpenCasesDto> Post(GetAllCasesWithQuery req)
        {
            OperationResponse<OpenCasesDto> response = new OperationResponse<OpenCasesDto>();
            try
            {
                OpenCasesDto openCaseDto =CaseBusinessLogic.GetAllCasesWithQuery(req.Queries,req.PageNumber,req.maxRowsPerPage);
                response.OnSuccess(openCaseDto, "Success");
                return response;
            }
            catch (Exception e)
            {
                Log.Error(e.Message + " " + e.StackTrace);
                response.OnException("Req failed at server side");
                return response;
            }
        }

        public OperationResponse<List<CaseTableDto>> Post(GetCaseByStatus request)
        {
            OperationResponse<List<CaseTableDto>> operationResponse = new OperationResponse<List<CaseTableDto>>();
            try
            {
                DateTime tempDate= request.StartDate.ToUniversalTime();
                List<CaseTableDto> caseDtos = CaseBusinessLogic.GetCaseByStatus(request.CaseStatus, request.StartDate, request.EndDate);
                if (caseDtos != null)
                {
                    operationResponse.OnSuccess(caseDtos, "Fetched successfully");
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

    }
}