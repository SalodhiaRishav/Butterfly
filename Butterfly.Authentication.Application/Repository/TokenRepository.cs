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

    public class TokenRepository : ITokenRepository
    {
        private readonly ButterflyContext ButterflyContext;

        private readonly DbSet<Token> DbSet;

        public TokenRepository()
        {
            ButterflyContext = new ButterflyContext();
            DbSet = ButterflyContext.Set<Token>();
        }
        public List<Token> List { get => DbSet.ToList(); }

        public Token Add(Token entity)
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

        public void AddRange(IEnumerable<Token> entityList)
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

        public void Delete(Token entity)
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

        public void DeleteRange(IEnumerable<Token> entityList)
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

        public List<Token> Find(Expression<Func<Token, bool>> predicate)
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

        public Token FindById(int Id)
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

        public Token Update(Token entity)
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
