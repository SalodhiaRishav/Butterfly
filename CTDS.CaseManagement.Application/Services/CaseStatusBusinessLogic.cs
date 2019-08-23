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
    public class CaseStatusBusinessLogic : ICaseStatusBusinessLogic
    {
        private readonly ICaseStatusRepository CaseStatusRepository;
        private readonly ICaseStatusMapper CaseStatusMapper;
        public CaseStatusBusinessLogic(ICaseStatusRepository caseStatusRepository, ICaseStatusMapper caseStatusMapper)
        {
            CaseStatusRepository = caseStatusRepository;
            CaseStatusMapper = caseStatusMapper;
        }
        public CaseStatusDto AddNewCaseStatus(CaseStatusDto caseStatusDto, Guid caseId)
        {
            try
            {
                if (caseStatusDto == null)
                {
                    return null;
                }
                CaseStatus caseStatus = CaseStatusMapper.DtoToModel(caseStatusDto);
                caseStatus.CaseId = caseId;
                caseStatus = this.CaseStatusRepository.Add(caseStatus);
                return this.CaseStatusMapper.ModelToDto(caseStatus);
            }
            catch (Exception exception)
            {
                throw exception;
            }
        }

        public CaseStatusDto GetCaseStatusByCaseId(Guid caseId)
        {
            try
            {
                List<CaseStatus> caseStatusList = this.CaseStatusRepository.Find(c => c.CaseId == caseId);
                if (caseStatusList.Count != 0)
                {
                    CaseStatus caseStatus = caseStatusList.First();
                    return this.CaseStatusMapper.ModelToDto(caseStatus);
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

        public void DeleteCaseStatusByCaseId(Guid caseId)
        {
            try
            {
                List<CaseStatus> caseStatusList = this.CaseStatusRepository.Find(c => c.CaseId == caseId);
                if (caseStatusList.Count != 0)
                {
                    CaseStatus caseStatus = caseStatusList.First();
                    this.CaseStatusRepository.Delete(caseStatus);
                }
            }
            catch (Exception exception)
            {
                throw exception;
            }
        }

        public CaseStatusDto EditCaseStatus(CaseStatusDto caseStatusDto)
        {
            try
            {
                if (caseStatusDto == null)
                {
                    return null;
                }
                CaseStatus caseStatus = this.CaseStatusMapper.DtoToModel(caseStatusDto);
                caseStatus = this.CaseStatusRepository.Update(caseStatus);
                return this.CaseStatusMapper.ModelToDto(caseStatus);
            }
            catch (Exception exception)
            {
                throw exception;
            }
        }
    }
}
