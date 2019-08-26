﻿namespace CTDS.Authentication.Application.Repository.Interfaces
{
    using CTDS.Database.Models.Authentication;
    using System;
    using System.Collections.Generic;
    using System.Linq.Expressions;

    public interface ITokenRepository
    {
        List<Token> List { get; }
        Token Add(Token entity);
        void Delete(Token entity);
        Token Update(Token entity);
        Token FindById(int id);
        void AddRange(IEnumerable<Token> entityList);
        void DeleteRange(IEnumerable<Token> entityList);
       
        List<Token> Find(Expression<Func<Token, bool>> predicate);
    }
}