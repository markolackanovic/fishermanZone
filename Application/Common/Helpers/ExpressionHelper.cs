using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Application.Common.Helpers
{
    public static class ExpressionHelper
    {
        public static Expression<Func<TEntity, bool>> CreateExpression<TEntity>(string keyName, int Id)
        {
            var parameter = Expression.Parameter(typeof(TEntity), "x");
            var property = Expression.Equal(Expression.Property(parameter, keyName), Expression.Constant(Id));
            var expression = Expression.Lambda<Func<TEntity, bool>>(property, parameter);
            return expression;
        }
    }
}
