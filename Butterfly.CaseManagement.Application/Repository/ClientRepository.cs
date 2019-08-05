namespace Butterfly.CaseManagement.Application.Repository
{
    using Butterfly.CaseManagement.Application.Interfaces;
    using Butterfly.Database.Models.CaseManagement;

    class ClientRepository : BaseRepository<Client>, IClientRepository
    {
    }
}