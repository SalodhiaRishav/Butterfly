namespace CTDS.Web.Declaration
{
    using System;
    using System.Collections.Generic;

    using CTDS.Declarations.Application.Services;
    using CTDS.Declarations.Contracts.DeclarationDTO;
    using CTDS.Declarations.Contracts.EndPoints;
    using CTDS.Declarations.Contracts.Validation;
    using CTDS.Web.CommonResponse;
    using CTDS.Web.Authentication.Filters;
    using CTDS.Declarations.Contracts.Interface;

    using FluentValidation.Results;
    using Serilog;   
    using ServiceStack.ServiceInterface;

    [AuthFilter(RoleName = "User")]
    public class EditDeclarationService : Service
    {
        private readonly IDeclarationBll DeclarationBll;
        public EditDeclarationService(IDeclarationBll declarationBll)
        {
            DeclarationBll = declarationBll;
        }
        public OperationResponse<bool> Post(EditDeclaration editDeclaration)
        {
            OperationResponse<bool> response = new OperationResponse<bool>();
            try
            {               
                var newDeclaration = editDeclaration.Declaration;
                DeclarationValidator obj = new DeclarationValidator();
                ValidationResult result = obj.Validate(newDeclaration);
                if (result.IsValid)
                {
                    var data = DeclarationBll.EditDeclaration(newDeclaration);
                    
                    ReferenceDto reference = new ReferenceDto();
                    for (int i = 0; i < editDeclaration.ReferenceData.Length; i++)
                    {
                        reference.DeclarationId = newDeclaration.DeclarationId;
                        reference.ReferenceId = editDeclaration.ReferenceData[i].ReferenceId;
                        reference.InvoiceDate = editDeclaration.ReferenceData[i].InvoiceDate;
                        reference.Reference = editDeclaration.ReferenceData[i].Reference;
                        reference.Type = editDeclaration.ReferenceData[i].Type;
                        DeclarationBll.AddReference(reference);
                    }
                    response.OnSuccess(data, "Record Successfully Updated");
                    return response;
                }
                else
                {
                    List<string> errors = new List<string>();
                    foreach(var err in result.Errors)
                    {
                        errors.Add(err.ErrorMessage);
                    }
                    response.OnError("one or more validations failed", errors);
                    return response;
                }

            }
            catch(Exception e)
            {
                Log.Error(e.Message+" "+e.StackTrace);
                response.OnException("Error in updating record");
                return response;
            }
        }
    }
}