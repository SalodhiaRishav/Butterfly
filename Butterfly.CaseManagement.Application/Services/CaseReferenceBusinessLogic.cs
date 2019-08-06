namespace Butterfly.CaseManagement.Application.Services
{
    using Butterfly.CaseManagement.Application.Repository.Interfaces;
    using Butterfly.CaseManagement.Application.Mapper.MapperInterface;
    using Butterfly.CaseManagement.Contracts.Dto;
    using Butterfly.CaseManagement.Contracts.Interfaces;
    using Butterfly.Database.Models.CaseManagement;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    public class CaseReferenceBusinessLogic : ICaseReferenceBusinessLogic
    {
        private readonly ICaseReferenceRepository CaseReferenceRepository;
        private readonly ICaseReferenceMapper CaseReferenceMapper;
        public CaseReferenceBusinessLogic(ICaseReferenceRepository caseReferenceRepository, ICaseReferenceMapper caseReferenceMapper)
        {
            CaseReferenceRepository = caseReferenceRepository;
            CaseReferenceMapper = caseReferenceMapper;
        }
        public List<CaseReferenceDto> AddNewCaseReferences(List<CaseReferenceDto> caseReferenceDtos, Guid caseId)
        {
            try
            {
                List<CaseReferenceDto> addedCaseReferenceDtos = new List<CaseReferenceDto>();
                if (caseReferenceDtos == null||caseReferenceDtos.Count==0)
                {
                    return null;
                }
                List<CaseReference> caseReferences = CaseReferenceMapper.DtoListToModelList(caseReferenceDtos);
                foreach (var caseReference in caseReferences)
                {
                    caseReference.CaseId = caseId;
                    CaseReference addedCaseReference = CaseReferenceRepository.Add(caseReference);
                    addedCaseReferenceDtos.Add(this.CaseReferenceMapper.ModelToDto(addedCaseReference));
                }

                return addedCaseReferenceDtos;
            }
            catch (Exception exception)
            {
                throw exception;
            }
        }

        public List<CaseReferenceDto> GetCaseReferencesByCaseId(Guid caseId)
        {
            try
            {
                List<CaseReference> caseReferenceList = this.CaseReferenceRepository.Find(c => c.CaseId == caseId);
                if (caseReferenceList.Count != 0)
                {
                    return this.CaseReferenceMapper.ModelListToDtoList(caseReferenceList);
                }
                else
                {
                    return null;
                }
            }
            catch (Exception exception)
            {
                throw exception;
            }
        }

        public void DeleteCaseReferenceByCaseId(Guid caseId)
        {
            try
            {
                List<CaseReference> caseReferences = this.CaseReferenceRepository.Find(c => c.CaseId == caseId);
                if(caseReferences == null)
                {
                    return;
                }

                this.CaseReferenceRepository.DeleteRange(caseReferences);
                return;
            }
            catch (Exception exception)
            {
                throw exception;
            }
        }

        public List<CaseReferenceDto> EditCaseReferences(List<CaseReferenceDto> caseReferenceDtos)
        {
            try
            {
                if (caseReferenceDtos != null && caseReferenceDtos.Count != 0)
                {
                    List<CaseReferenceDto> updatedCaseReferenceList = new List<CaseReferenceDto>();
                    foreach (CaseReferenceDto caseReferenceDto in caseReferenceDtos)
                    {
                        CaseReference caseReference = this.CaseReferenceMapper.DtoToModel(caseReferenceDto);
                        caseReference = this.CaseReferenceRepository.Update(caseReference);
                        updatedCaseReferenceList.Add(this.CaseReferenceMapper.ModelToDto(caseReference));
                    }
                   return updatedCaseReferenceList;
                }
                else
                {
                    return null;
                }
            }
            catch (Exception exception)
            {
                throw exception;
            }
        }
    }
}
