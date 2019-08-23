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
    public class ClientBusinessLogic : IClientBusinessLogic
    {
        private readonly IClientRepository ClientRepository;
        private readonly IClientMapper ClientMapper;
        public ClientBusinessLogic(IClientRepository clientRepository, IClientMapper clientMapper)
        {
            ClientRepository = clientRepository;
            ClientMapper = clientMapper;
        }
        public ClientDto AddNewClient(ClientDto clientDto, Guid caseId)
        {
            try
            {
                if (clientDto == null)
                {
                    return null;
                }
                Client client = ClientMapper.DtoToModel(clientDto);
                client.CaseId = caseId;
                client = this.ClientRepository.Add(client);
                return this.ClientMapper.ModelToDto(client);
            }
            catch (Exception exception)
            {
                throw exception;
            }
        }

        public ClientDto GetClientByCaseId(Guid caseId)
        {
            try
            {
                List<Client> clientList = this.ClientRepository.Find(c => c.CaseId == caseId);
                if (clientList.Count != 0)
                {
                    Client client = clientList.First();
                    return this.ClientMapper.ModelToDto(client);
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

        public void DeleteClientByCaseId(Guid caseId)
        {
            try
            {
                List<Client> clientList = this.ClientRepository.Find(c => c.CaseId == caseId);
                if (clientList.Count != 0)
                {
                    Client client = clientList.First();
                    this.ClientRepository.Delete(client);
                }
            }
            catch (Exception exception)
            {
                throw exception;
            }
        }

        public ClientDto EditClient(ClientDto clientDto)
        {
            try
            {
                if (clientDto == null)
                {
                    return null;
                }
                Client client = this.ClientMapper.DtoToModel(clientDto);
                client = this.ClientRepository.Update(client);
                return this.ClientMapper.ModelToDto(client);
            }
            catch (Exception exception)
            {
                throw exception;
            }
        }
    }
}
