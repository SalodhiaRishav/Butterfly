namespace CTDS.Security.Application.Repository
{
    using System;
    using System.Collections.Generic;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;
    using System.Linq.Expressions;

    using CTDS.Security.Application.Repository.Interfaces;
    using CTDS.Database.Context;
    using CTDS.Database.Models.Authentication;

    public class RoleRepository : IRoleRepository
    {
        private readonly CTDSContext CTDSContext;
        private readonly DbSet<Role> DbSet;

        public RoleRepository()
        {
            CTDSContext = new CTDSContext();
            DbSet = CTDSContext.Set<Role>();
        }
        public List<Role> List { get => DbSet.ToList(); }

        public Role Add(Role entity)
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

        public void AddRange(IEnumerable<Role> entityList)
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

        public void Delete(Role entity)
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

        public void DeleteRange(IEnumerable<Role> entityList)
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

        public List<Role> Find(Expression<Func<Role, bool>> predicate)
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

        public Role FindById(int id)
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

        public Role Update(Role entity)
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
