namespace Butterfly.Authentication.Contracts.Interfaces
{
    using Butterfly.Authentication.Contracts.Dto;

    public interface IUserBusinessLogic
    {
        LoginResultDto LoginUser(string email, string password);
    }
}
