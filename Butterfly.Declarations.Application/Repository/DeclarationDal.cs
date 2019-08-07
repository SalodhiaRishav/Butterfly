using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Butterfly.Declarations.Application.Repository
{
    using Butterfly.Database.Models.Declarations;
    using Butterfly.Declarations.Application.Mapper;
    using Butterfly.Declarations.Contracts.DeclarationDTO;
    using Butterfly.Database.Context;
    using System.Data.Entity.Migrations;

    public class DeclarationDal
    {
        private readonly DatabaseMapper mapper;
        public DeclarationDal()
        {
            mapper = new DatabaseMapper();
        }

        public bool AddDeclaration(DeclarationDto declarationDto)
        {
            bool success;
            
            try
            {
                using(var context = new ButterflyContext())
                {
                    var declaration = mapper.DtoToDeclaration(declarationDto);
                    context.Declaration.Add(declaration);
                    context.SaveChanges();
                    success = true;
                }
                return success;
            }
            catch (Exception)
            {
                throw;
            }

        }

        public DeclarationDto GetDeclarationById(Guid id)
        {
            DeclarationDto declarationDto = new DeclarationDto();
            try
            {
                using(var context = new ButterflyContext())
                {
                    var declaration = context.Declaration.Find(id);
                    declarationDto = mapper.DeclarationToDto(declaration);
                }
                return declarationDto;
            }
            catch (Exception)
            {
                throw;
            }
        }
        public IEnumerable<DeclarationDto> GetAllDeclarations()
        {
            IEnumerable<DeclarationDto> declarationDtoList;
            try
            {
                using(var context = new ButterflyContext())
                {
                    var declarationList = context.Declaration.ToList();
                    declarationDtoList = mapper.DeclarationListToDtoList(declarationList);
                }
                return declarationDtoList;
            }
            catch (Exception)
            {
                throw;
            }
        }

        public bool EditDeclaration(DeclarationDto declarationDto)
        {
            bool response;
            try
            {
                using (var _context = new ButterflyContext())
                {
                    //_context.Declaration.Log = s => { System.Diagnostics.Debug.WriteLine(s); };
                    var declaration = mapper.DtoToDeclaration(declarationDto);
                    _context.Declaration.AddOrUpdate(declaration);
                    _context.SaveChanges();
                    response = true;
                }
                return response;
            }
            catch (Exception)
            {

                throw;
            }
        }
    }
}
