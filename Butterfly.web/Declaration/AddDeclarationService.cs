namespace Butterfly.web.Declaration
{
    using System;
    using System.Collections.Generic;
   

    using Butterfly.Declarations.Application.Services;
    using Butterfly.Declarations.Contracts.DeclarationDTO;
    using Butterfly.Declarations.Contracts.EndPoints;
    using Butterfly.Declarations.Contracts.Validation;
    using Butterfly.web.CommonResponse;

    using FluentValidation.Results;
    using Serilog;
    using ServiceStack.ServiceInterface;
    using System.Configuration;
    using Butterfly.web.Authentication.Filters;

    [AuthFilter(RoleName = "User")]
    public class AddDeclarationService : Service
    {
        private readonly DeclarationBll declarationBll;
       
        public AddDeclarationService()
        {
            declarationBll = new DeclarationBll();
        }
        public OperationResponse<bool> POST(AddDeclaration NewDeclaration)
        {
            OperationResponse<bool> response = new OperationResponse<bool>();
            try
            {
                var declaration = NewDeclaration.declaration;
                DeclarationValidator obj = new DeclarationValidator();
                ValidationResult result = obj.Validate(declaration);
                if (result.IsValid)
                {
                    var data = declarationBll.AddDeclaration(declaration);
                    var id = data;
                    ReferenceDto reference = new ReferenceDto();
                    for (int i = 0; i < NewDeclaration.referenceData.Length; i++)
                    {
                        reference.DeclarationId = data;
                        reference.InvoiceDate = NewDeclaration.referenceData[i].InvoiceDate;
                        reference.Reference = NewDeclaration.referenceData[i].Reference;
                        reference.Type = NewDeclaration.referenceData[i].Type;
                        declarationBll.AddReference(reference);
                    }
                    response.OnSuccess(true, "Declaration Successfully added!");
                    return response;
                }
                else
                {
                    List<string> error = new List<string>();
                    foreach(var err in result.Errors)
                    {
                        error.Add(err.ErrorMessage);
                    }
                    response.OnError("One or more validations failed", error);
                    return response;
                }
            }
            catch(Exception e)
            {
                Log.Error(e.Message+" "+e.StackTrace);
                response.OnException("Request to Add new declaration failed at server side.");
                return response;
            }
           
        }
    }
}