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

        public List<DeclarationTableDto> GetDeclarationByStatus(String status, DateTime startDate, DateTime endDate)
        {
            try
            {
                List<DeclarationTableDto> declarations = DeclarationDal.GetAllDeclarationByStatus(status, startDate, endDate);
                if (declarations.Count == 0)
                {
                    return null;
                }

                return declarations;
            }
            catch (Exception exception)
            {
                throw exception;
            }
        }

        public List<DeclarationChartDataDto> GetDeclarationChartData(string status, DateTime startDate, DateTime endDate)
        {
            return DeclarationDal.GetDeclarationChartData(status, startDate, endDate);
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

        public IEnumerable<DeclarationDto> GetAllDeclaration(int index, string sort)
        {
            try
            {
                return DeclarationDal.GetAllDeclarations(index, sort);
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

        public List<int> GetPerDayDeclarationCount()
        {
            try
            {
                return DeclarationDal.FindPerDayDeclarationCount();
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

        public FilterDeclarationsDto GetAllDeclarationsWithQuery(List<QueryDto> queries, int pageNumber, int maxRowsPerPage,string sortBy,bool sortDesc)
        {
            try
            {
                return DeclarationDal.GetAllDeclarationsWithQuery(queries,pageNumber,maxRowsPerPage,sortBy,sortDesc);
            }
            catch
            {
                throw;
            }
        }
    }
}
