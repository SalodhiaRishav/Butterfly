namespace CTDS.Security.Application.Services
{
    using System.Collections.Generic;

    using CTDS.Security.Application.Repository.Interfaces;
    using CTDS.Security.Contracts.Dto;
    using CTDS.Security.Contracts.Interfaces;
    using CTDS.Database.Models.Authentication;
   
    using AutoMapper;

    public class RoleBusinessLogic : IRoleBusinessLogic
    {
        private readonly IUserRoleRepository UserRoleRepository;
        private readonly IRoleRepository RoleRepository;
        private readonly IMapper Mapper;

        public RoleBusinessLogic(IUserRoleRepository userRoleRepository,IRoleRepository roleRepository)
        {
            UserRoleRepository = userRoleRepository;
            RoleRepository = roleRepository;
            MapperConfiguration config = new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<Role, RoleDto>().ReverseMap();
            });
            Mapper = config.CreateMapper();
        }
        public List<RoleDto> GetUserRoles(int userId)
        {
            List<Role> roles = new List<Role>();
            List<UserRole> userRoles = UserRoleRepository.Find(ur => ur.UserId == userId);
            if (userRoles.Count != 0)
            {
                foreach (UserRole userRole in userRoles)
                {
                    var role = RoleRepository.FindById(userRole.RoleId);
                    if (role != null)
                    {
                        roles.Add(role);
                    }
                }
            }
            var roleDtoList = Mapper.Map<List<RoleDto>>(roles);
            return roleDtoList;
        }
    }
}
