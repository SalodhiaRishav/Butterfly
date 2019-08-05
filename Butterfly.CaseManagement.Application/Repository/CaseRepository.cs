namespace Butterfly.CaseManagement.Application.Repository
{
    using Butterfly.CaseManagement.Application.Repository.Interfaces;
    using Butterfly.Database.Models.CaseManagement;

    public class CaseRepository : BaseRepository<Case>, ICaseRepository
    {
    }
}