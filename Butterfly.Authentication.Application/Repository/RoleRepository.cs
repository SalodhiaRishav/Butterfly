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

    public class RoleRepository : IRoleRepository
    {
        private readonly ButterflyContext ButterflyContext;

        private readonly DbSet<Role> DbSet;

        public RoleRepository()
        {
            ButterflyContext = new ButterflyContext();
            DbSet = ButterflyContext.Set<Role>();
        }
        public List<Role> List { get => DbSet.ToList(); }

        public Role Add(Role entity)
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

        public void AddRange(IEnumerable<Role> entityList)
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

        public void Delete(Role entity)
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

        public void DeleteRange(IEnumerable<Role> entityList)
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

        public Role FindById(int Id)
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

        public Role Update(Role entity)
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
