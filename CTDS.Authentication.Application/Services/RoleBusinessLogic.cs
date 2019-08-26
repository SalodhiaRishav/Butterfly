namespace CTDS.Authentication.Application.Services
{
    using AutoMapper;
    using CTDS.Authentication.Application.Repository.Interfaces;
    using CTDS.Authentication.Contracts.Dto;
    using CTDS.Authentication.Contracts.Interfaces;
    using CTDS.Database.Models.Authentication;
    using System.Collections.Generic;

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
