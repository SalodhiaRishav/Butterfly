using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
namespace Butterfly.web.Declaration
{
    using Butterfly.Declarations.Contracts.EndPoints;
    using Butterfly.Declarations.Contracts.DeclarationDTO;
    using ServiceStack.ServiceInterface;
    using Butterfly.web.CommonResponse;
    using Butterfly.Declarations.Application.Services;
    using Butterfly.Declarations.Contracts.Validation;
    using FluentValidation.Results;
    using System.Configuration;

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
                    ReferenceDto temp = new ReferenceDto();
                    for (int i = 0; i < NewDeclaration.referenceData.Length; i++)
                    {
                        temp.DeclarationId = data;
                        temp.InvoiceDate = NewDeclaration.referenceData[i].InvoiceDate;
                        temp.Reference = NewDeclaration.referenceData[i].Reference;
                        temp.Type = NewDeclaration.referenceData[i].Type;
                        declarationBll.AddReference(temp);
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
                response.OnException("Request to Add new declaration failed at server side.");
                return response;
            }
           
        }
    }
}