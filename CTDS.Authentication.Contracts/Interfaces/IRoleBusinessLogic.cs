namespace CTDS.Authentication.Contracts.Interfaces
{
    using CTDS.Authentication.Contracts.Dto;
    using System.Collections.Generic;

    public interface IRoleBusinessLogic
    {
        List<RoleDto> GetUserRoles(int userId);
    }
}
