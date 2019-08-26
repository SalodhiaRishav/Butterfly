namespace CTDS.Authentication.Application.Repository.Interfaces
{
    using System;
    using System.Collections.Generic;
    using System.Linq.Expressions;

    using CTDS.Database.Models.Authentication;
   
    public interface IUserRepository
    {
        List<User> List { get; }
        User Add(User entity);
        void Delete(User entity);
        User Update(User entity);
        User FindById(int Id);
        void AddRange(IEnumerable<User> entityList);
        void DeleteRange(IEnumerable<User> entityList);
        List<User> Find(Expression<Func<User, bool>> predicate);
    }
}