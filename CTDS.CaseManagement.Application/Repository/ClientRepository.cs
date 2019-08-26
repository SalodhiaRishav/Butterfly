namespace CTDS.CaseManagement.Application.Repository
{
    using CTDS.CaseManagement.Application.Repository.Interfaces;
    using CTDS.Database.Models.CaseManagement;

    public class ClientRepository : BaseRepository<Client>, IClientRepository
    {
    }
}