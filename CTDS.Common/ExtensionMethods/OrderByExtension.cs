namespace CTDS.Common.ExtensionMethods
{
    using System;
    using System.Linq;
    using System.Linq.Expressions;
    using System.Reflection;

    public static class OrderByExtension
    {
        public static IOrderedQueryable<T> CustomOrderBy<T>(this IQueryable<T> query, string memberName, string sortingOrder = "desc")
        {
            ParameterExpression[] typeParams = new ParameterExpression[] { Expression.Parameter(typeof(T), "") };

            PropertyInfo pi = typeof(T).GetProperty(memberName, BindingFlags.IgnoreCase | BindingFlags.Public | BindingFlags.Instance);

            return (IOrderedQueryable<T>)query.Provider.CreateQuery(
            Expression.Call(
             typeof(Queryable),
             sortingOrder == "asc" ? "OrderBy" : "OrderByDescending",
             new Type[] { typeof(T), pi.PropertyType },
             query.Expression,
             Expression.Lambda(Expression.Property(typeParams[0], pi), typeParams))
            );
        }
    }
}
