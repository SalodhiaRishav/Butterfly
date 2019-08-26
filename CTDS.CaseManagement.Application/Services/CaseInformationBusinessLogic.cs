namespace CTDS.CaseManagement.Application.Services
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    using CTDS.CaseManagement.Application.Repository.Interfaces;
    using CTDS.CaseManagement.Application.Mapper.MapperInterface;
    using CTDS.CaseManagement.Contracts.Dto;
    using CTDS.CaseManagement.Contracts.Interfaces;
    using CTDS.Database.Models.CaseManagement;
    
    public class CaseInformationBusinessLogic : ICaseInformationBusinessLogic
    {
        private readonly ICaseInformationRepository CaseInformationRepository;
        private readonly ICaseInformationMapper CaseInformationMapper;
        public CaseInformationBusinessLogic(ICaseInformationRepository caseInformationRepository, ICaseInformationMapper caseInformationMapper)
        {
            CaseInformationRepository = caseInformationRepository;
            CaseInformationMapper = caseInformationMapper;
        }
        public CaseInformationDto AddNewCaseInformation(CaseInformationDto caseInformationDto, Guid caseId)
        {
            try
            {
                if (caseInformationDto == null)
                {
                    return null;
                }
                CaseInformation caseInformation = CaseInformationMapper.DtoToModel(caseInformationDto);
                caseInformation.CaseId = caseId;
                caseInformation = this.CaseInformationRepository.Add(caseInformation);
                return this.CaseInformationMapper.ModelToDto(caseInformation);
            }
            catch (Exception exception)
            {
                throw exception;
            }
        }

        public CaseInformationDto GetCaseInformationByCaseId(Guid caseId)
        {
            try
            {
                List<CaseInformation> caseInformationList = this.CaseInformationRepository.Find(c => c.CaseId == caseId);
                if (caseInformationList.Count != 0)
                {
                    CaseInformation caseInformation = caseInformationList.First();
                    return this.CaseInformationMapper.ModelToDto(caseInformation);
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

        public void DeleteCaseInformationByCaseId(Guid caseId)
        {
            try
            {
                List<CaseInformation> caseInformationList = this.CaseInformationRepository.Find(c => c.CaseId == caseId);
                if (caseInformationList.Count != 0)
                {
                    CaseInformation caseInformation = caseInformationList.First();
                    this.CaseInformationRepository.Delete(caseInformation);
                }
            }
            catch (Exception exception)
            {
                throw exception;
            }
        }

        public CaseInformationDto EditCaseInformation(CaseInformationDto caseInformationDto)
        {
            try
            {
                if (caseInformationDto == null)
                {
                    return null;
                }
                CaseInformation caseInformation = this.CaseInformationMapper.DtoToModel(caseInformationDto);
                caseInformation = this.CaseInformationRepository.Update(caseInformation);
                return this.CaseInformationMapper.ModelToDto(caseInformation);
            }
            catch (Exception exception)
            {
                throw exception;
            }
        }
    }
}
