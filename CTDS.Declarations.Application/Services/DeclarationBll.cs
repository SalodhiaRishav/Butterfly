namespace CTDS.Declarations.Application.Services
{
    using System;
    using System.Collections.Generic;

    using CTDS.Declarations.Application.Repository;
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
    }
}
