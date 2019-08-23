namespace CTDS.CaseManagement.Application.Repository.Interfaces
{
    using System;
    using System.Collections.Generic;
    using System.Linq.Expressions;

    public interface IRepository<T>
    {
        List<T> List { get; }
        T Add(T entity);
        void Delete(T entity);
        T Update(T entity);
        T FindById(int Id);
        void AddRange(IEnumerable<T> entityList);
        void DeleteRange(IEnumerable<T> entityList);
        List<T> Find(Expression<Func<T, bool>> predicate);
    }
}
