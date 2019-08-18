namespace Butterfly.Authentication.Contracts.Interfaces
{
    using Butterfly.Authentication.Contracts.Dto;
    using System.Collections.Generic;

    public interface IRoleBusinessLogic
    {
        List<RoleDto> GetUserRoles(int userId);
    }
}
