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
    public class AddDeclarationService : Service
    {
        private readonly IDeclarationBll DeclarationBll;
       
        public AddDeclarationService(IDeclarationBll declarationBll)
        {
            DeclarationBll = declarationBll;
        }
        public OperationResponse<bool> Post(AddDeclaration newDeclaration)
        {
            OperationResponse<bool> response = new OperationResponse<bool>();
            try
            {
                var declaration = newDeclaration.Declaration;
                DeclarationValidator obj = new DeclarationValidator();
                ValidationResult result = obj.Validate(declaration);
                if (result.IsValid)
                {
                    var data = DeclarationBll.AddDeclaration(declaration);
                    var id = data;
                    ReferenceDto reference = new ReferenceDto();
                    for (int i = 0; i < newDeclaration.ReferenceData.Length; i++)
                    {
                        reference.DeclarationId = data;
                        reference.InvoiceDate = newDeclaration.ReferenceData[i].InvoiceDate;
                        reference.Reference = newDeclaration.ReferenceData[i].Reference;
                        reference.Type = newDeclaration.ReferenceData[i].Type;
                        DeclarationBll.AddReference(reference);
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