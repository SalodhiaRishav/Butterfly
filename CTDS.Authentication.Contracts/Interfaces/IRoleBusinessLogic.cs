namespace CTDS.Authentication.Contracts.Interfaces
{
    using System.Collections.Generic;

    using CTDS.Authentication.Contracts.Dto;
    
    public interface IRoleBusinessLogic
    {
        List<RoleDto> GetUserRoles(int userId);
    }
}
