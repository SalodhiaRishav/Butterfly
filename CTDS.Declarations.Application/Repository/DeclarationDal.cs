namespace CTDS.Declarations.Application.Repository
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Data.Entity.Migrations;

    using CTDS.Database.Context;
    using CTDS.Declarations.Application.Mapper;
    using CTDS.Declarations.Contracts.DeclarationDTO;
    using CTDS.Declarations.Application.Repository.Interface;
    using CTDS.Declarations.Application.Mapper.Interface;

    public class DeclarationDal : IDeclarationDal
    {
        private readonly IDatabaseMapper Mapper;
        public DeclarationDal(IDatabaseMapper mapper)
        {
            Mapper = mapper;
        }

        public Guid AddDeclaration(DeclarationDto declarationDto)
        {
            Guid success;
            
            try
            {
                using(var context = new CTDSContext())
                {
                    var declaration = Mapper.DtoToDeclaration(declarationDto);
                    var newDeclaration = context.Declaration.Add(declaration);
                    context.SaveChanges();

                    success = newDeclaration.DeclarationId;
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
                using(var context = new CTDSContext())
                {
                    var declaration = context.Declaration.Find(id);
                    declarationDto = Mapper.DeclarationToDto(declaration);
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
                using(var context = new CTDSContext())
                {
                    var declarationList = context.Declaration.ToList();
                    declarationDtoList = Mapper.DeclarationListToDtoList(declarationList);
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
                using (var context = new CTDSContext())
                {
                    //_context.Declaration.Log = s => { System.Diagnostics.Debug.WriteLine(s); };
                    var declaration = Mapper.DtoToDeclaration(declarationDto);
                    context.Declaration.AddOrUpdate(declaration);
                    context.SaveChanges();
                    response = true;
                }
                return response;
            }
            catch (Exception)
            {

                throw;
            }
        }

        public void AddReference(ReferenceDto reference)
        {
            try
            {
                using(var context = new CTDSContext())
                {
                    var data = Mapper.DtoToReferenceModel(reference);
                    context.Reference.AddOrUpdate(d => d.ReferenceId,data);
                    context.SaveChanges();
                }
            }
            catch (Exception)
            {
                throw;
            }
        }

        public IEnumerable<ReferenceDto> GetReferenceData(Guid id)
        {
            IEnumerable<ReferenceDto> refData;
            try
            {
                using(var context = new CTDSContext())
                {
                    var data = context.Reference.Where(x => x.DeclarationId == id).ToList();
                    refData = Mapper.ReferenceListToDtoList(data);
                }
                return refData;
            }
            catch (Exception)
            {
                throw;
            }
        }
        public int GetCount()
        {
            int count = 0;
            try
            {
                using(var context = new CTDSContext())
               {
                    count = context.Declaration.Count(); 
               }
                return count;
            }
            catch (Exception)
            {
                throw;
            }
        }
        public int GetCountForLastSevenDays()
        {
            int count = 0;
            DateTime date = DateTime.Now.AddDays(-7);
            try
            {
                using(var context = new CTDSContext())
                {
                    count = context.Declaration.Where(x => x.CreatedOn >= date).Count();
                }
                return count;
            }
            catch (Exception)
            {
                throw;
            }

        }
        public bool SendToCustom(DeclarationDto declarationDto)
        {
            bool result = false;
            try
            {
                using (var context = new CTDSContext())
                {
                    var declaration = Mapper.DtoToDeclaration(declarationDto);
                    context.Declaration.AddOrUpdate(declaration);
                    context.SaveChanges();
                    result = true;
                }
                return result;
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}
