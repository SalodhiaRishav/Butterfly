namespace CTDS.Declarations.Application.Services
{
    using System;
    using System.Collections.Generic;

    using CTDS.Declarations.Contracts.DeclarationDTO;
    using CTDS.Declarations.Contracts.Interface;
    using CTDS.Declarations.Application.Repository.Interface;

    public class DeclarationBll : IDeclarationBll
    {
        private readonly IDeclarationDal DeclarationDal;
        public DeclarationBll(IDeclarationDal declarationDal)
        {
            DeclarationDal = declarationDal;
        }

        public Guid AddDeclaration(DeclarationDto declarationDto)
        {
            try
            {
                return DeclarationDal.AddDeclaration(declarationDto);
            }
            catch (Exception)
            {
                throw;
            }
        }

        public DeclarationDto GetDeclarationById(Guid id)
        {
            try
            {
                return DeclarationDal.GetDeclarationById(id);
            }
            catch (Exception)
            {
                throw;
            }
        }

        public IEnumerable<DeclarationDto> GetAllDeclaration()
        {
            try
            {
                return DeclarationDal.GetAllDeclarations();
            }
            catch (Exception)
            {
                throw;
            }
        }

        public bool EditDeclaration(DeclarationDto declarationDto)
        {
            try
            {
                return DeclarationDal.EditDeclaration(declarationDto);
            }
            catch(Exception)
            {
                throw;
            }
        }

        public void AddReference(ReferenceDto reference)
        {
            try
            {
                DeclarationDal.AddReference(reference);
            }
            catch (Exception)
            {
                throw;
            }
        }

        public IEnumerable<ReferenceDto> GetReferenceData(Guid id)
        {
            try
            {
                return DeclarationDal.GetReferenceData(id);
            }
            catch(Exception)
            {
                throw;
            }
        }
        public int GetCount()
        {
            try
            {
                return DeclarationDal.GetCount();
            }
            catch (Exception)
            {
                throw;
            }
        }

        public int GetCountForLastSevenDays()
        {
            try
            {
                return DeclarationDal.GetCountForLastSevenDays();
            }
            catch
            {
                throw;
            }
        }
        public bool SendToCustom(DeclarationDto declaration)
        {
            try
            {
                if(declaration.MessageName == "FU" && declaration.Amount != "")
                {
                    declaration.Status = "Cleared";
                }
                else if(declaration.Amount == "")
                {
                    declaration.Status = "Rejected";
                }
                else
                {
                    declaration.Status = "Processing";
                }
                return DeclarationDal.SendToCustom(declaration);
            }
            catch (Exception)
            {
                throw;
            }
        }

        public StatusDto GetStatusCount()
        {
            try
            {
                var declarations = DeclarationDal.GetAllDeclarations();
                var statusDto = new StatusDto();
                foreach(var declaration in declarations)
                {
                    if(declaration.Status == "Rejected")
                    {
                        statusDto.Rejected++;
                    }
                    else if(declaration.Status == "Cleared")
                    {
                        statusDto.Cleared++;
                    }
                    else
                    {
                        statusDto.Processing++;
                    }
                }
                return statusDto;
            }
            catch
            {
                throw;
            }
        }
    }
}
