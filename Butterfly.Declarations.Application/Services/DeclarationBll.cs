using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Butterfly.Declarations.Application.Services
{
    using Butterfly.Declarations.Contracts.DeclarationDTO;
    using Butterfly.Declarations.Application.Repository;
    public class DeclarationBll
    {
        private readonly DeclarationDal declarationDal;
        public DeclarationBll()
        {
            declarationDal = new DeclarationDal();
        }

        public bool AddDeclaration(DeclarationDto declarationDto)
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
    }
}
