﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CTDS.Declarations.Application.Services
{
    using CTDS.Declarations.Contracts.DeclarationDTO;
    using CTDS.Declarations.Application.Repository;
    public class DeclarationBll
    {
        private readonly DeclarationDal DeclarationDal;
        public DeclarationBll()
        {
            DeclarationDal = new DeclarationDal();
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
