namespace CTDS.Security.Contracts.Interfaces
{
    using System.Collections.Generic;

    using CTDS.Security.Contracts.Dto;
    
    public interface IRoleBusinessLogic
    {
        List<RoleDto> GetUserRoles(int userId);
    }
}
