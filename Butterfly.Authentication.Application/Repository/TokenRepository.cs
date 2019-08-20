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
                using (var context = new ButterflyContext())
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
                using (var context = new ButterflyContext())
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
                using (var context = new ButterflyContext())
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
                using (var context = new ButterflyContext())
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
                using (var context = new ButterflyContext())
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
                using (var context = new ButterflyContext())
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
                using (var context = new ButterflyContext())
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
