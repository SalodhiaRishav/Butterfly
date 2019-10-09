namespace CTDS.CaseManagement.Application.Repository
{
    using System;
    using System.Collections.Generic;
    using System.Data.Entity;
    using System.Linq;
    using System.Linq.Expressions;
    using System.Data.Entity.Migrations;

    using CTDS.Database.Models;
    using CTDS.Database.Context;   
    using CTDS.CaseManagement.Application.Repository.Interfaces;

    public class BaseRepository<T> : IRepository<T> where T : BaseModel
    {

     
        public List<T> List
        {
            get
            {
                using (var context = new CTDSContext())
                {
                    var DbSet = context.Set<T>();
                    return DbSet.ToList();
                }
               
            }
        }

        public T Add(T entity)
        {
            entity.ModifiedOn = DateTime.Now;
            entity.CreatedOn = DateTime.Now;
            try
            {
                using (var context = new CTDSContext())
                {
                    var DbSet = context.Set<T>();
                    DbSet.Add(entity);
                    context.SaveChanges();
                    return entity;
                }
                   
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
                using (var context = new CTDSContext())
                {
                    var DbSet = context.Set<T>();
                    DbSet.AddRange(entityList);
                    context.SaveChanges();
                }
                   
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
                using (var context = new CTDSContext())
                {
                    var DbSet = context.Set<T>();
                    DbSet.Remove(entity);
                    context.SaveChanges();
                }
               
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
                using (var context = new CTDSContext())
                {
                    var DbSet = context.Set<T>();
                    DbSet.RemoveRange(entityList);
                    context.SaveChanges();
                }
                
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
                using (var context = new CTDSContext())
                {
                    var DbSet = context.Set<T>();
                    return DbSet.Where(predicate).ToList();
                }
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
                using (var context = new CTDSContext())
                {
                    var DbSet = context.Set<T>();
                    return DbSet.Find(id);
                }
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
                using (var context = new CTDSContext())
                {
                    var DbSet = context.Set<T>();
                    entity.ModifiedOn = DateTime.Now;
                    if (entity.CreatedOn == DateTime.MinValue)
                    {
                        entity.CreatedOn = DateTime.Now;
                    }
                    DbSet.AddOrUpdate(entity);
                    context.SaveChanges();
                    return entity;
                }
            }
            catch (Exception exception)
            {
                throw exception;
            }
        }
    }
}
