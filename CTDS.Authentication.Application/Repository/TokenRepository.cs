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

    public class TokenRepository : ITokenRepository
    {
        private readonly CTDSContext CTDSContext;

        private readonly DbSet<Token> DbSet;

        public TokenRepository()
        {
            CTDSContext = new CTDSContext();
            DbSet = CTDSContext.Set<Token>();
        }
        public List<Token> List { get => DbSet.ToList(); }

        public Token Add(Token entity)
        {
            try
            {
                using (var context = new CTDSContext())
                {
                    context.UserToken.Add(entity);
                    context.SaveChanges();
                }
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
                using (var context = new CTDSContext())
                {
                    context.UserToken.AddRange(entityList);
                    context.SaveChanges();
                }

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
                using (var context = new CTDSContext())
                {
                    context.UserToken.Attach(entity);
                    context.UserToken.Remove(entity);
                    context.SaveChanges();
                }
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
                using (var context = new CTDSContext())
                {
                    context.UserToken.RemoveRange(entityList);
                    context.SaveChanges();
                }
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
                using (var context = new CTDSContext())
                {
                    return context.UserToken.Where(predicate).ToList();
                }
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
                using (var context = new CTDSContext())
                {
                    return context.UserToken.Find(Id);
                }
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
                using (var context = new CTDSContext())
                {
                    context.UserToken.AddOrUpdate(entity);
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
