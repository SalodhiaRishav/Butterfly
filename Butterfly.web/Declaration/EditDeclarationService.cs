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
                var newDeclaration = editDeclaration.declaration;
                DeclarationValidator obj = new DeclarationValidator();
                ValidationResult result = obj.Validate(newDeclaration);
                if (result.IsValid)
                {
                    var data = declarationBll.EditDeclaration(newDeclaration);
                    
                    ReferenceDto reference = new ReferenceDto();
                    for (int i = 0; i < editDeclaration.referenceData.Length; i++)
                    {
                        reference.DeclarationId = newDeclaration.DeclarationId;
                        reference.ReferenceId = editDeclaration.referenceData[i].ReferenceId;
                        reference.InvoiceDate = editDeclaration.referenceData[i].InvoiceDate;
                        reference.Reference = editDeclaration.referenceData[i].Reference;
                        reference.Type = editDeclaration.referenceData[i].Type;
                        declarationBll.AddReference(reference);
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