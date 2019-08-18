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

    public class UserRoleRepository : IUserRoleRepository
    {
        private readonly ButterflyContext ButterflyContext;

        private readonly DbSet<UserRole> DbSet;

        public UserRoleRepository()
        {
            ButterflyContext = new ButterflyContext();
            DbSet = ButterflyContext.Set<UserRole>();
        }
        public List<UserRole> List { get => DbSet.ToList(); }

        public UserRole Add(UserRole entity)
        {
            try
            {
                DbSet.Add(entity);
                ButterflyContext.SaveChanges();
                return entity;
            }
            catch (Exception exception)
            {
                throw exception;
            }
        }

        public void AddRange(IEnumerable<UserRole> entityList)
        {
            try
            {
                DbSet.AddRange(entityList);
                ButterflyContext.SaveChanges();
            }
            catch (Exception exception)
            {
                throw exception;
            }
        }

        public void Delete(UserRole entity)
        {
            try
            {
                DbSet.Remove(entity);
                ButterflyContext.SaveChanges();
            }
            catch (Exception exception)
            {
                throw exception;
            }
        }

        public void DeleteRange(IEnumerable<UserRole> entityList)
        {
            try
            {
                DbSet.RemoveRange(entityList);
                ButterflyContext.SaveChanges();
            }
            catch (Exception exception)
            {
                throw exception;
            }
        }

        public List<UserRole> Find(Expression<Func<UserRole, bool>> predicate)
        {
            try
            {
                return DbSet.Where(predicate).ToList();
            }
            catch (Exception exception)
            {
                throw exception;
            }
        }

        public UserRole FindById(int Id)
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

        public UserRole Update(UserRole entity)
        {
            try
            {
                DbSet.AddOrUpdate(entity);
                ButterflyContext.SaveChanges();
                return entity;
            }
            catch (Exception exception)
            {
                throw exception;
            }
        }
    }
}
