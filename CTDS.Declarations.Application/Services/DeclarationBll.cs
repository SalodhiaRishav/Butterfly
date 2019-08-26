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
        private readonly DeclarationDal declarationDal;
        public DeclarationBll()
        {
            declarationDal = new DeclarationDal();
        }

        public Guid AddDeclaration(DeclarationDto declarationDto)
        {
            try
            {
                return declarationDal.AddDeclaration(declarationDto);
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
                return declarationDal.GetDeclarationById(id);
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
                return declarationDal.GetAllDeclarations();
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
                return declarationDal.EditDeclaration(declarationDto);
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
                declarationDal.AddReference(reference);
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
                return declarationDal.GetReferenceData(id);
            }
            catch(Exception)
            {
                throw;
            }
        }
    }
}