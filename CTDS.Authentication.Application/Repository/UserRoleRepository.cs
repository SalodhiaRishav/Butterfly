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

    public class UserRoleRepository : IUserRoleRepository
    {
        private readonly CTDSContext CTDSContext;
        private readonly DbSet<UserRole> DbSet;

        public UserRoleRepository()
        {
            CTDSContext = new CTDSContext();
            DbSet = CTDSContext.Set<UserRole>();
        }
        public List<UserRole> List { get => DbSet.ToList(); }

        public UserRole Add(UserRole entity)
        {
            try
            {
                DbSet.Add(entity);
                CTDSContext.SaveChanges();
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
                CTDSContext.SaveChanges();
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
                CTDSContext.SaveChanges();
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
                CTDSContext.SaveChanges();
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

        public UserRole FindById(int id)
        {
            try
            {
                return DbSet.Find(id);
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
                CTDSContext.SaveChanges();
                return entity;
            }
            catch (Exception exception)
            {
                throw exception;
            }
        }
    }
}
