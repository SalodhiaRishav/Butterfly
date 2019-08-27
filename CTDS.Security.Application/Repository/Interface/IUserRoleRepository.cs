namespace CTDS.Security.Application.Repository.Interfaces
{
    using System;
    using System.Collections.Generic;
    using System.Linq.Expressions;

    using CTDS.Database.Models.Authentication;
    
    public interface IUserRoleRepository
    {
        List<UserRole> List { get; }
        UserRole Add(UserRole entity);
        void Delete(UserRole entity);
        UserRole Update(UserRole entity);
        UserRole FindById(int id);
        void AddRange(IEnumerable<UserRole> entityList);
        void DeleteRange(IEnumerable<UserRole> entityList);
        List<UserRole> Find(Expression<Func<UserRole, bool>> predicate);
    }
}