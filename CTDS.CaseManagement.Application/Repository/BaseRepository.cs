namespace CTDS.CaseManagement.Application.Repository
{
    using System;
    using System.Collections.Generic;
    using System.Data.Entity;
    using System.Linq;
    using CTDS.Database.Models;
    using CTDS.Database.Context;
    using System.Linq.Expressions;
    using System.Data.Entity.Migrations;
    using CTDS.CaseManagement.Application.Repository.Interfaces;

    public class BaseRepository<T> : IRepository<T> where T : BaseModel
    {
        private readonly CTDSContext CTDSContext;

        private readonly DbSet<T> DbSet;

        public BaseRepository()
        {
            CTDSContext = new CTDSContext();
            DbSet = CTDSContext.Set<T>();
        }
        public List<T> List { get => DbSet.ToList(); }

        public T Add(T entity)
        {
            entity.ModifiedOn = DateTime.Now;
            entity.CreatedOn = DateTime.Now;
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
                CTDSContext.SaveChanges();
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
                CTDSContext.SaveChanges();
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
                CTDSContext.SaveChanges();
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

        public T FindById(int id)
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

        public T Update(T entity)
        {
            try
            {
                entity.ModifiedOn = DateTime.Now;
                if(entity.CreatedOn ==  DateTime.MinValue)
                {
                    entity.CreatedOn = DateTime.Now;
                }
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
