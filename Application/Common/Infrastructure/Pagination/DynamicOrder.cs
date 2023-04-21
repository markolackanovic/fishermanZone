using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Application.Common.Infrastructure.Pagination
{
    public static class DynamicOrder
    {
        public static IQueryable<T> DynamicOrderBy<T>(this IQueryable<T> data, string requestSortColumnName, string requestSortColumnDirection)
        {
            if (string.IsNullOrEmpty(requestSortColumnName))
                return data;

            var parameter = Expression.Parameter(typeof(T), "");
            Expression selector = Expression.Property(parameter, requestSortColumnName);
            Expression.Lambda<Func<T, object>>(
                Expression.Convert(selector, typeof(object)),
                parameter
            ).Compile();

            var method = requestSortColumnDirection == "DESC"
                ? "OrderByDescending"
                : "OrderBy";

            var expression = data.Expression;

            var expressionCall = Expression.Call(
                typeof(Queryable),
                method,
                new[] { data.ElementType, selector.Type },
                expression,
                Expression.Quote(Expression.Lambda(selector, parameter)));

            return data.Provider.CreateQuery<T>(expressionCall);
        }
    }
}
