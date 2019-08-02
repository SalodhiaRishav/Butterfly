namespace Butterfly.CaseManagement.Application.Repository
{
    using System;
    using System.Collections.Generic;
    using System.Data.Entity;
    using System.Linq;
    using Butterfly.Database.Models;
    using Butterfly.Database.Context;
    using System.Linq.Expressions;
    using System.Data.Entity.Migrations;
    using Butterfly.CaseManagement.Contracts.Interfaces;

    public class BaseRepository<T> : IRepository<T> where T : BaseModel
    {
        private readonly ButterflyContext ButterflyContext;

        private readonly DbSet<T> DbSet;

        public BaseRepository()
        {
            ButterflyContext = new ButterflyContext();
            DbSet = ButterflyContext.Set<T>();
        }
        public List<T> List { get => DbSet.ToList(); }

        public T Add(T entity)
        {
            entity.ModifiedOn = DateTime.Now;
            entity.CreatedOn = DateTime.Now;
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

        public void AddRange(IEnumerable<T> entityList)
        {
            foreach (var item in entityList)
            {
                item.CreatedOn = DateTime.Now;
                item.ModifiedOn = DateTime.Now;
            }
            try
            {
                DbSet.AddRange(entityList);
                ButterflyContext.SaveChanges();
            }
            catch(Exception exception)
            {
                throw exception;
            }
        }

        public void Delete(T entity)
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

        public void DeleteRange(IEnumerable<T> entityList)
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

        public List<T> Find(Expression<Func<T, bool>> predicate)
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

        public T FindById(int Id)
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

        public T Update(T entity)
        {
            try
            {
                entity.ModifiedOn = DateTime.Now;
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
