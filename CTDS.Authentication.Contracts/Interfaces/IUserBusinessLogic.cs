namespace CTDS.Authentication.Contracts.Interfaces
{
    using CTDS.Authentication.Contracts.Dto;

    public interface IUserBusinessLogic
    {
        LoginResultDto LoginUser(string email, string password);
    }
}
