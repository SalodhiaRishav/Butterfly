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

        public void Add(T entity)
        {
            entity.ModifiedOn = DateTime.Now;
            entity.CreatedOn = DateTime.Now;
            DbSet.Add(entity);
            ButterflyContext.SaveChanges();
        }

        public void AddRange(IEnumerable<T> entityList)
        {
            foreach (var item in entityList)
            {
                item.CreatedOn = DateTime.Now;
                item.ModifiedOn = DateTime.Now;
            }
            DbSet.AddRange(entityList);
            ButterflyContext.SaveChanges();
        }

        public void Delete(T entity)
        {
            DbSet.Remove(entity);
            ButterflyContext.SaveChanges();
        }

        public void DeleteRange(IEnumerable<T> entityList)
        {
            DbSet.RemoveRange(entityList);
            ButterflyContext.SaveChanges();
        }

        public List<T> Find(Expression<Func<T, bool>> predicate)
        {
            return DbSet.Where(predicate).ToList();
        }

        public T FindById(int Id)
        {
            return DbSet.Find(Id);
        }

        public void Update(T entity)
        {
            entity.ModifiedOn = DateTime.Now;
            DbSet.AddOrUpdate(entity);
            ButterflyContext.SaveChanges();
        }
    }
}
