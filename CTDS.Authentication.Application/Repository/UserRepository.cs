namespace CTDS.Authentication.Application.Repository
{
    using System;
    using System.Collections.Generic;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;
    using System.Linq.Expressions;
    using CTDS.Authentication.Application.Repository.Interfaces;
    using CTDS.Database.Context;
    using CTDS.Database.Models.Authentication;

    public class UserRepository : IUserRepository
    {
        private readonly CTDSContext CTDSContext;

        private readonly DbSet<User> DbSet;

        public UserRepository()
        {
            CTDSContext = new CTDSContext();
            DbSet = CTDSContext.Set<User>();
        }
        public List<User> List { get => DbSet.ToList(); }

        public User Add(User entity)
        {
            try
            {
                using (var context = new CTDSContext())
                {
                    context.User.Add(entity);
                    context.SaveChanges();
                }
                return entity;
            }
            catch (Exception exception)
            {
                throw exception;
            }
        }

        public void AddRange(IEnumerable<User> entityList)
        {
            try
            {
                using (var context = new CTDSContext())
                {
                    context.User.AddRange(entityList);
                    context.SaveChanges();
                }
            }
            catch (Exception exception)
            {
                throw exception;
            }
        }

        public void Delete(User entity)
        {
            try
            {
                using (var context = new CTDSContext())
                {
                    context.User.Remove(entity);
                    context.SaveChanges();
                }
            }
            catch (Exception exception)
            {
                throw exception;
            }
        }

        public void DeleteRange(IEnumerable<User> entityList)
        {
            try
            {
                using (var context = new CTDSContext())
                {
                    context.User.RemoveRange(entityList);
                    context.SaveChanges();
                }
            }
            catch (Exception exception)
            {
                throw exception;
            }
        }

        public List<User> Find(Expression<Func<User, bool>> predicate)
        {
            try
            {
                using (var context = new CTDSContext())
                {
                    return context.User.Where(predicate).ToList();
                }
                
            }
            catch (Exception exception)
            {
                throw exception;
            }
        }

        public User FindById(int Id)
        {
            try
            {
                return DbSet.Find(Id);
            }
            catch (Exception exception)
            {
                throw exception;
            }
        }

        public User Update(User entity)
        {
            try
            {
                using (var context = new CTDSContext())
                {
                    context.User.AddOrUpdate(entity);
                    context.SaveChanges();
                }
                return entity;
            }
            catch (Exception exception)
            {
                throw exception;
            }
        }
    }
}
