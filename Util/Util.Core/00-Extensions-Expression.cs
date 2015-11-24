using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using Util.Core.Lambdas;

namespace Util.Core
{
    public static partial class Extensions
    {
        internal static Expression<T> Compose<T>(this Expression<T> first, Expression<T> second, Func<Expression, Expression, Expression> merge)
        {
            Dictionary<ParameterExpression, ParameterExpression> map = first.Parameters.Select((f, i) => new {f, s = second.Parameters[i]}).ToDictionary(p => p.s, p => p.f);
            Expression secondBody = ParameterRebinder.ReplaceParameter(map, second.Body);

            return Expression.Lambda<T>(merge(first.Body, second.Body), first.Parameters);
        }

        public static Expression<Func<T, bool>> And<T>(this Expression<Func<T, bool>> left, Expression<Func<T, bool>> right)
        {
            if (left == null)
            {
                return right;
            }

            if (right == null)
            {
                return left;
            }

            return left.Compose(right, Expression.AndAlso);
        }
    }
}