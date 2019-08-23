namespace CTDS.CaseManagement.Application.Services
{
    using CTDS.CaseManagement.Application.Repository.Interfaces;
    using CTDS.CaseManagement.Application.Mapper.MapperInterface;
    using CTDS.CaseManagement.Contracts.Dto;
    using CTDS.CaseManagement.Contracts.Interfaces;
    using CTDS.Database.Models.CaseManagement;
    using System;
    using System.Collections.Generic;
    using System.Linq;
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
                CaseInformation CaseInformation = CaseInformationMapper.DtoToModel(caseInformationDto);
                CaseInformation.CaseId = caseId;
                CaseInformation = this.CaseInformationRepository.Add(CaseInformation);
                return this.CaseInformationMapper.ModelToDto(CaseInformation);
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
                    CaseInformation CaseInformation = caseInformationList.First();
                    return this.CaseInformationMapper.ModelToDto(CaseInformation);
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
                    CaseInformation CaseInformation = caseInformationList.First();
                    this.CaseInformationRepository.Delete(CaseInformation);
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
                CaseInformation CaseInformation = this.CaseInformationMapper.DtoToModel(caseInformationDto);
                CaseInformation = this.CaseInformationRepository.Update(CaseInformation);
                return this.CaseInformationMapper.ModelToDto(CaseInformation);
            }
            catch (Exception exception)
            {
                throw exception;
            }
        }
    }
}
