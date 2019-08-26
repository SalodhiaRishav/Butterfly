namespace CTDS.CaseManagement.Contracts.Interfaces
{
    using System;

    using CTDS.CaseManagement.Contracts.Dto;
  
    public interface IClientBusinessLogic
    {
        ClientDto AddNewClient(ClientDto clientDto, Guid caseId);
        ClientDto GetClientByCaseId(Guid caseId);
        void DeleteClientByCaseId(Guid caseId);
        ClientDto EditClient(ClientDto clientDto);
    }
}
