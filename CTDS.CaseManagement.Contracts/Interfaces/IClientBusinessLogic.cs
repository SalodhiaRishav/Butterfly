namespace CTDS.CaseManagement.Contracts.Interfaces
{
    using CTDS.CaseManagement.Contracts.Dto;
    using System;

    public interface IClientBusinessLogic
    {
        ClientDto AddNewClient(ClientDto clientDto, Guid caseId);
        ClientDto GetClientByCaseId(Guid caseId);
        void DeleteClientByCaseId(Guid caseId);
        ClientDto EditClient(ClientDto clientDto);
    }
}
