namespace CTDS.Security.Contracts.Interfaces
{
    using CTDS.Security.Contracts.Dto;

    public interface IUserBusinessLogic
    {
        LoginResultDto LoginUser(string email, string password);
    }
}
