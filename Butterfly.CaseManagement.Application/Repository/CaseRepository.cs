namespace Butterfly.CaseManagement.Application.Repository
{
    using Butterfly.CaseManagement.Contracts.Interfaces;
    using Butterfly.Database.Models.CaseManagement;

    class CaseRepository : BaseRepository<Case>, ICaseRepository
    {
    }
}