using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Butterfly.web.Declaration
{
    
    using ServiceStack.ServiceInterface;
    using Butterfly.web.CommonResponse;
    using Butterfly.Declarations.Contracts.EndPoints;
    using Butterfly.Declarations.Application.Services;
    using FluentValidation.Results;
    using Butterfly.Declarations.Contracts.Validation;
    using Butterfly.Declarations.Contracts.DeclarationDTO;
    using Serilog;
    using Butterfly.web.Authentication.Filters;

    [AuthFilter(RoleName = "User")]
    public class EditDeclarationService : Service
    {
        private readonly DeclarationBll declarationBll;
        public EditDeclarationService()
        {
            declarationBll = new DeclarationBll();
        }
        public OperationResponse<bool> POST(EditDeclaration editDeclaration)
        {
            OperationResponse<bool> response = new OperationResponse<bool>();
            try
            {
                //todo add reference data
                var newDeclaration = editDeclaration.declaration;
                var reference = editDeclaration.referenceData;
                DeclarationValidator obj = new DeclarationValidator();
                ValidationResult result = obj.Validate(newDeclaration);
                if (result.IsValid)
                {
                    var data = declarationBll.EditDeclaration(newDeclaration);
                    
                    ReferenceDto temp = new ReferenceDto();
                    for (int i = 0; i < editDeclaration.referenceData.Length; i++)
                    {
                        temp.DeclarationId = newDeclaration.DeclarationId;
                        temp.ReferenceId = editDeclaration.referenceData[i].ReferenceId;
                        temp.InvoiceDate = editDeclaration.referenceData[i].InvoiceDate;
                        temp.Reference = editDeclaration.referenceData[i].Reference;
                        temp.Type = editDeclaration.referenceData[i].Type;
                        declarationBll.AddReference(temp);
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
                Log.Error(e.Message);
                response.OnException("Error in updating record");
                return response;
            }
        }
    }
}