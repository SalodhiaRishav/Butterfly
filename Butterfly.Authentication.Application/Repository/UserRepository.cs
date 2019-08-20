namespace Butterfly.Authentication.Application.Repository
{
    using System;
    using System.Collections.Generic;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;
    using System.Linq.Expressions;
    using Butterfly.Authentication.Application.Repository.Interfaces;
    using Butterfly.Database.Context;
    using Butterfly.Database.Models.Authentication;

    public class UserRepository : IUserRepository
    {
        private readonly ButterflyContext ButterflyContext;

        private readonly DbSet<User> DbSet;

        public UserRepository()
        {
            ButterflyContext = new ButterflyContext();
            DbSet = ButterflyContext.Set<User>();
        }
        public List<User> List { get => DbSet.ToList(); }

        public User Add(User entity)
        {
            try
            {
                using (var context = new ButterflyContext())
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
                using (var context = new ButterflyContext())
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
                using (var context = new ButterflyContext())
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
                using (var context = new ButterflyContext())
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
                using (var context = new ButterflyContext())
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
                using (var context = new ButterflyContext())
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
